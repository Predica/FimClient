using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema;
using Microsoft.ResourceManagement.Client.CodeInit;
using Microsoft.ResourceManagement.Client.WsEnumeration;
using System.ServiceModel;
using Microsoft.ResourceManagement.Client;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using System.ServiceModel.Channels;
using Microsoft.ResourceManagement.Client.WsTrust;
//using Microsoft.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Runtime.Serialization;
using System.Threading;
using Microsoft.ResourceManagement.WebServices.Client;
using Microsoft.ResourceManagement.Client.Faults;

namespace Microsoft.ResourceManagement.Client {
    /// <summary>
    /// The DefaultClient is a thin wrapper over the the following clients: 
    /// WsTransfer, WsTransferFactory, WsEnumeration , Alternate, STS
    /// 
    /// It is intended to be useful only for common scenarios. For more advanced 
    /// scenarios, please use the other clients.
    /// </summary>
    /// <remarks>
    /// Please note that you should call <see cref="RefreshSchema"/> before
    /// using the client for the first time, as otherwise the request and 
    /// resource factories will use (incorrect) default information.
    /// </remarks>
    public class DefaultClient : IDisposable {

        #region Members

        // underlying clients
        WsTransferClient wsTransferClient;
        WsTransferFactoryClient wsTransferFactoryClient;
        MexClient mexClient;
        WsEnumerationClient wsEnumerationClient;
        AlternateClient alternateClient;

        // factories used to construct resources and requests
        RmResourceFactory resourceFactory;
        RmRequestFactory requestFactory;
        public QAGateQuestionsHandler questionHandler;

        bool schemaCached;

        #endregion

        #region Constructors

        public DefaultClient(string fimUrl)
        {
            this.wsTransferClient = new WsTransferClient(Bindings.ServiceMultipleTokenBinding_Common, DefaultEndpoints.WsTransfer(fimUrl));
            this.wsTransferFactoryClient = new WsTransferFactoryClient(Bindings.ServiceMultipleTokenBinding_Common, DefaultEndpoints.WsTransferFactory(fimUrl));
            this.wsEnumerationClient = new WsEnumerationClient(Bindings.ServiceMultipleTokenBinding_Common, DefaultEndpoints.WsEnumeration(fimUrl));
            this.mexClient = new MexClient(Bindings.MetadataExchangeHttpBinding_IMetadataExchange, DefaultEndpoints.Mex(fimUrl));
            this.alternateClient = new AlternateClient(Bindings.ServiceMultipleTokenBinding_Common, DefaultEndpoints.Alternate(fimUrl));
            this.resourceFactory = new RmResourceFactory();
            this.requestFactory = new RmRequestFactory();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DefaultClient() {
            this.wsTransferClient = new WsTransferClient();
            this.wsTransferFactoryClient = new WsTransferFactoryClient();
            this.wsEnumerationClient = new WsEnumerationClient();
            this.mexClient = new MexClient();
            this.alternateClient = new AlternateClient();
            this.resourceFactory = new RmResourceFactory();
            this.requestFactory = new RmRequestFactory();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wsTransferConfigurationName">Name of the ws transfer endpoint configuration.</param>
        /// <param name="wsTransferFactoryConfigurationName">Name of the ws transfer factory endpoint configuration.</param>
        /// <param name="wsEnumerationConfigurationName">Name of the ws enumeration endpoint configuration.</param>
        /// <param name="mexConfigurationName">Name of the mex endpoint configuration.</param>
        public DefaultClient(
            String wsTransferConfigurationName,
            String wsTransferFactoryConfigurationName,
            String wsEnumerationConfigurationName,
            String mexConfigurationName,
            String alternateClientConfigurationName
            ) {
            this.wsTransferClient = new WsTransferClient(wsTransferConfigurationName);
            this.wsTransferFactoryClient = new WsTransferFactoryClient(wsTransferFactoryConfigurationName);
            this.wsEnumerationClient = new WsEnumerationClient(wsEnumerationConfigurationName);
            this.mexClient = new MexClient(mexConfigurationName);
            this.alternateClient = new AlternateClient(alternateClientConfigurationName);

            this.resourceFactory = new RmResourceFactory();
            this.requestFactory = new RmRequestFactory();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wsTransferConfigurationName">Name of the ws transfer endpoint configuration.</param>
        /// <param name="wsTransferEndpointAddress">The ws transfer endpoint address.</param>
        /// <param name="wsTransferFactoryConfigurationName">Name of the ws transfer factory endpoint configuration.</param>
        /// <param name="wsTransferFactoryEndpointAddress">The ws transfer factory endpoint address.</param>
        /// <param name="wsEnumerationConfigurationName">Name of the ws enumeration endpoint configuration.</param>
        /// <param name="wsEnumerationEndpointAddress">The ws enumeration endpoint address.</param>
        /// <param name="mexConfigurationName">Name of the mex endpoint configuration.</param>
        /// <param name="mexEndpointAddress">The mex endpoint address.</param>
        public DefaultClient(
            String wsTransferConfigurationName,
            String wsTransferEndpointAddress,
            String wsTransferFactoryConfigurationName,
            String wsTransferFactoryEndpointAddress,
            String wsEnumerationConfigurationName,
            String wsEnumerationEndpointAddress,
            String mexConfigurationName,
            String mexEndpointAddress,
            String alternateClientConfigurationName,
            String alternamteClientConfigurationAddress
            ) {
            this.wsTransferClient = new WsTransferClient(wsTransferConfigurationName, wsTransferEndpointAddress);
            this.wsTransferFactoryClient = new WsTransferFactoryClient(wsTransferFactoryConfigurationName, wsTransferFactoryEndpointAddress);
            this.wsEnumerationClient = new WsEnumerationClient(wsEnumerationConfigurationName, wsEnumerationEndpointAddress);
            this.mexClient = new MexClient(mexConfigurationName, mexEndpointAddress);
            this.alternateClient = new AlternateClient(alternateClientConfigurationName, alternamteClientConfigurationAddress);

            this.resourceFactory = new RmResourceFactory();
            this.requestFactory = new RmRequestFactory();
        }

        #endregion

        /// <summary>
        /// Refreshes the metadata from the service.
        /// </summary>
        public XmlSchemaSet RefreshSchema() {
            XmlSchemaSet metadata = this.mexClient.Get();
            lock (this.requestFactory) {
                this.requestFactory = new RmRequestFactory(metadata);
            }
            lock (this.resourceFactory) {
                this.resourceFactory = new RmResourceFactory(metadata);
            }
            this.schemaCached = true;
            return metadata;
        }

        #region WsTransfer
        private ContextualSecurityToken HandleAuthNFault(String stsEndpointAddress, ContextMessageProperty responseContext) {
            ContextualSecurityToken returnToken = null;

            //create new client to talk to the STS
            SecurityTokenServiceClient stsClient = new SecurityTokenServiceClient("ServiceMultipleTokenBinding_SecurityTokenService", stsEndpointAddress);

            Guid contextGuid = new Guid(responseContext.Context["instanceId"]);

            Message RST;  //The Request for Security Token
            Message RSTR;  //The Request for Security Token Response
            ClientSerializer RSTRSerializer = new ClientSerializer(typeof(Client.WsTrust.RequestSecurityTokenResponse));
            Client.WsTrust.RequestSecurityTokenResponse serializedRSTR;
            Dictionary<int, String> answers = new Dictionary<int, string>();

            //Initial RST, RSTR


            RST = stsClient.BuildRequestSecurityTokenMessage(contextGuid);

            RSTR = stsClient.RequestSecurityToken(RST);

            //We will continue asking for RSTR untill we get a Security Token (or get a fault)
            do {
                serializedRSTR = (Client.WsTrust.RequestSecurityTokenResponse)RSTRSerializer.ReadObject(RSTR.GetReaderAtBodyContents());
                if (serializedRSTR != null) {
                    if (serializedRSTR.Authchallenge != null) {
                        if (serializedRSTR.Authchallenge.challenge.workflowAuthChallenge.Name == "QAGate") {
                            answers = questionHandler.Invoke(serializedRSTR.Authchallenge.challenge.workflowAuthChallenge);
                            Client.WsTrust.RequestSecurityTokenResponse RSTRrequest = new Client.WsTrust.RequestSecurityTokenResponse();
                            RSTRrequest.Context = serializedRSTR.Context;
                            RSTRrequest.AuthChallengeResponse = new AuthenticationChallengeResponse(answers);

                            RSTR = stsClient.BuildRequestSecurityTokenResponseMessage(RSTRrequest);
                            RSTR = stsClient.RequestSecurityTokenResponse(RSTR);
                        }
                    } else if (serializedRSTR.RequestedSecurityToken != null) {
                        returnToken = serializedRSTR.GetContextTokenFromResponse(responseContext);
                    } else {
                        throw new Exception("The STS returned a response that is neither an AuthChallenge nor a Security Response.");
                    }
                } else
                    throw new Exception("Received a response from the STS that we do not understand.");

            } while (returnToken == null);

            return returnToken;

        }

        /// <summary>
        /// Creates the given resource and returns its ObjectId.
        /// This method does not set the ObjectId of newResource.
        /// </summary>
        /// <param name="newResource">The resource to create.</param>
        /// <returns>The ObjectId of the resource.</returns>
        public RmReference Create(RmResource newResource) {
            if (newResource == null)
                throw new ArgumentNullException("newResource");
            CreateRequest request = this.requestFactory.CreateCreateRequest(newResource);
            CreateResponse response = this.wsTransferFactoryClient.Create(request);
            try {
                RmReference reference = new RmReference(response.ResourceCreated.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value);
                newResource.ObjectID = reference;
                return reference;
            } catch (NullReferenceException) {
                return new RmReference();
            } catch (FormatException) {
                return new RmReference();
            }
        }

        /// <summary>
        /// Retrieves the object with the given ObjectId
        /// </summary>
        /// <param name="objectId">The ObjectId of the requested object.</param>
        /// <returns>The object or null if not found</returns>
        /// <exception cref="System.ServiceModel.FaultException">System.ServiceModel.FaultException thrown when failures occur.</exception>
        public RmResource Get(RmReference objectId) {
            return Get(objectId, null, null);
        }

        /// <summary>
        /// Retrieves the representation of an object with the given ObjectId in the given culture.
        /// </summary>
        /// <param name="objectId">The ObjectId of the requested object.</param>
        /// <param name="culture">The requested culture representation of the object.</param>
        /// <returns>The object or null if not found.</returns>
        public RmResource Get(RmReference objectId, CultureInfo culture) {
            return Get(objectId, culture, null);
        }

        /// <summary>
        /// Retrieves the object and the specified attributes with the given ObjectId.
        /// </summary>
        /// <param name="objectId">The ObjectId of the requested object.</param>
        /// <param name="attributes">The list of attributes on the object to return.</param>
        /// <returns></returns>
        public RmResource Get(RmReference objectId, String[] attributes) {
            return Get(objectId, null, attributes);
        }

        protected RmResource Get(RmReference objectId, CultureInfo culture, String[] attributes) {
            GetRequest request = this.requestFactory.CreateGetRequest(objectId, culture, attributes);
            GetResponse response = this.wsTransferClient.Get(request);
            return this.resourceFactory.CreateResource(response);
        }

        /// <summary>
        /// Saves changes made to an object recorded by the transaction to the service.
        /// </summary>
        /// <param name="transaction">The transaction object which recorded changes made to a Resource object.</param>
        /// <returns>True upon successful operation.</returns>
        public bool Put(RmResourceChanges transaction) {
            return Put(transaction, false);
        }

        public bool Put(RmResourceChanges transaction, bool useAlternateEndpoint) {
            PutResponse response;
            return Put(transaction, useAlternateEndpoint, out response, null, null);
        }
        public bool Put(RmResourceChanges transaction, bool useAlternateEndpoint, out PutResponse response, SecurityToken token, ContextMessageProperty context) {
            response = null;
            if (transaction == null) {
                throw new ArgumentNullException("transaction");
            }

            if (!useAlternateEndpoint) {
                PutRequest resourceEPrequest = this.requestFactory.CreatePutRequest(transaction);
                try {

                    this.wsTransferClient.Put(resourceEPrequest, out response);

                }
                    //catch AuthN Fault here so we have the original transaction so we can re-submit later
                catch (System.ServiceModel.FaultException<Microsoft.ResourceManagement.Client.Faults.AuthenticationRequiredFault> authNFault) {
                    String STSEndpoinAddresst = authNFault.Detail.SecurityTokenServiceAddress;
                    ContextMessageProperty responseContext;
                    //TODO: Add AuthNLogicHere. For now, only support QA gates on the Authernate Endpoint
                }

                if (response == null)
                    return false;
                else
                    return true;
            } else {
                //TODO:Verify that the ObjectID is in the form Domain\User.
                PutRequest alternateEPrequest = this.requestFactory.CreatePutRequest(transaction);
                response = null;

                try {
                    this.alternateClient.Put(alternateEPrequest, out response, token, context);
                } catch (System.ServiceModel.FaultException<Microsoft.ResourceManagement.Client.Faults.AuthenticationRequiredFault> authNFault) {
                    String STSEndpointAddress = authNFault.Detail.SecurityTokenServiceAddress;
                    ContextMessageProperty responseContext;

                    if (ContextMessageProperty.TryGet(response.Message, out responseContext)) {
                        ContextualSecurityToken userToken = HandleAuthNFault(STSEndpointAddress, responseContext);
                        Put(transaction, true, out response, userToken, responseContext);
                    } else {
                        throw new Exception("Could not get security context from Put.");
                    }
                }

                if (response == null)
                    return false;
                else
                    return true;
            }
        }


        /// <summary>
        /// Deletes the object with the given ObjectId.
        /// </summary>
        /// <param name="objectId">The ObjectId of the object to delete.</param>
        /// <returns>True upon successful deletion.</returns>
        public bool Delete(RmReference objectId) {
            DeleteRequest request = this.requestFactory.CreateDeleteRequest(objectId);
            DeleteResponse response = this.wsTransferClient.Delete(request);
            if (response == null)
                return false;
            else
                return true;
        }

        public void ResetPassword(String domainAndUserName) {
            // Create Anonymouse RmPerson and set ObjectID to Domain\User
            // The ObjectID attribute will become ResourceReferenceProperty in the message header
            RmPerson user = new RmPerson();
            RmReference domainAndUsernameReference = new RmReference();
            domainAndUsernameReference.DomainAndUserNameValue = domainAndUserName;
            user.ObjectID = domainAndUsernameReference;
            PutResponse putResponse;
            putResponse = new PutResponse();
            string STSEndpoint = String.Empty;

            // Set ResetPassword to true
            // Need a transaction to watch changes to the user
            using (RmResourceChanges transaction = new RmResourceChanges(user)) {
                transaction.BeginChanges();
                user.ResetPassword = "True";
                try {
                    // We commit the change to the server
                    Put(transaction, true, out putResponse, null, null);
                } catch (FaultException<AnonymousInteractionRequiredFault> exc) {
                    // Now we must set the new password in the endpoint contained
                    // in the exception
                    string endpoint = exc.Detail.AnonymousInteractionEndpointAddress;
#warning "MUST ADD A CREATE MESSAGE WITH THE NEW PASSWORD."
                }
            }
        }

        protected virtual Dictionary<int, String> AskQAGateQuestions(QAGateQuestionsHandler gateHandler) {
            if (gateHandler != null) {

                //Invokes the delegates.
                //AskPasswordResetQuestion(this, e);
            } else {
                throw new Exception("We have encountered a QA gate but nobody has registered to present QA challenges. Please register with the AskQAGateQuestionsHandler");
            }
            return null;
        }

        #endregion

        #region Enumeration

        /// <summary>
        /// Returns an enumerator that can traverse all objects matching the given filter.
        /// </summary>
        /// <param name="filter">The XPath filter of which objects to select.</param>
        /// <returns>An enumerator object which can be consumed in foreach statements.</returns>
        public IEnumerable<RmResource> Enumerate(String filter) {
            return this.Enumerate(filter, null);
        }

        /// <summary>
        /// Returns an enumerator that can traverse all objects matching the given filter.
        /// 
        /// Each object only contains the specified attributes.
        /// </summary>
        /// <param name="filter">The XPath filter of which objects to select.</param>
        /// <param name="attributes">A list of attribute names to include in returned objects.</param>
        /// <returns>An enumerator object which can be consumed in foreach statements.</returns>
        public IEnumerable<RmResource> Enumerate(String filter, String[] attributes) {
            if (String.IsNullOrEmpty(filter)) {
                throw new ArgumentNullException("filter");
            }

            //return new EnumerationResultEnumerator(this.wsEnumerationClient, this.resourceFactory, filter, attributes);
            return this.requestFactory.CreateEnumeration(this.wsEnumerationClient, this.resourceFactory, filter, attributes);
        }

        #endregion

        #region Approvals

        /// <summary>
        /// The default configuration for approval endpoint addresses.
        /// </summary>
        public const string DefaultApprovalConfiguration = @"ServiceMultipleTokenBinding_ResourceFactory";

        /// <summary>
        /// Submits an approval response message for the pending approval using
        /// the default approval endpoint configuration name 
        /// (ServiceMultipleTokenBinding_ResourceFactory).
        /// </summary>
        /// <param name="approval">The approval object for which to submit an approval response.</param>
        /// <param name="isApproved">True when to approve the approval. False to reject it.</param>
        /// <returns>Returns true if the approval response was accepted.</returns>
        public void Approve(
            RmApproval approval,
            bool isApproved) {
            Approve(approval, isApproved, DefaultApprovalConfiguration);
        }

        /// <summary>
        /// Submits an approval response message for the pending approval using
        /// the specified approval endpoint configuration name.
        /// </summary>
        /// <param name="approval">The approval object for which to submit an approval response.</param>
        /// <param name="isApproved">True when to approve the approval. False to reject it.</param>
        /// <param name="approvalConfiguration">The approval endpoint configuration name.</param>
        public void Approve(
            RmApproval approval,
            bool isApproved,
            string approvalConfiguration) {
            // Create a transfer client specifying the configuration name and 
            // the approval endpoint address
            WsTransferFactoryClient approvalClient = new WsTransferFactoryClient(
                approvalConfiguration,
                approval.ApprovalEndpointAddress);
            // set the credentials in the new client
            approvalClient.ClientCredentials.Windows.ClientCredential = this.ClientCredential;
            // approve the request
            approvalClient.Approve(approval, isApproved);
        }

        /// <summary>
        /// Submits an approval response message for the pending approval using
        /// the specified endpoint address and the default approval endpoint 
        /// configuration name (ServiceMultipleTokenBinding_ResourceFactory). 
        /// Use this overload e.g. if you need to specify explicitly a service 
        /// principal name.
        /// </summary>
        /// <param name="approval">The approval object for which to submit an approval response.</param>
        /// <param name="isApproved">True when to approve the approval. False to reject it.</param>
        /// <param name="approvalConfiguration">The approval endpoint.</param>
        public void Approve(
            RmApproval approval,
            bool isApproved,
            EndpointAddress address) {
            Approve(approval, isApproved, address, DefaultApprovalConfiguration);
        }

        /// <summary>
        /// Submits an approval response message for the pending approval using
        /// the specified endpoint address and the specified approval endpoint 
        /// configuration name.
        /// Use this overload e.g. if you need to specify explicitly a service 
        /// principal name.
        /// </summary>
        /// <param name="approval">The approval object for which to submit an approval response.</param>
        /// <param name="isApproved">True when to approve the approval. False to reject it.</param>
        /// <param name="approvalConfiguration">The approval endpoint.</param>
        public void Approve(
            RmApproval approval,
            bool isApproved,
            EndpointAddress address,
            string approvalConfiguration) {
            // Create a transfer client specifying the configuration name and 
            // the approval endpoint
            WsTransferFactoryClient approvalClient = new WsTransferFactoryClient(
                approvalConfiguration,
                address);
            // set the credentials in the new client
            approvalClient.ClientCredentials.Windows.ClientCredential = this.ClientCredential;
            // approve the request
            approvalClient.Approve(approval, isApproved);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            this.wsTransferClient.Close();
            this.wsTransferFactoryClient.Close();
            this.mexClient.Close();
            this.wsEnumerationClient.Close();

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Promoted Properties

        /// <summary>
        /// Gets or Sets the credential with which the underlying clients use to communicate with the service.
        /// </summary>
        public System.Net.NetworkCredential ClientCredential {
            get {
                return this.wsTransferClient.ClientCredentials.Windows.ClientCredential;
            }
            set {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }
                this.wsTransferClient.ClientCredentials.Windows.ClientCredential = value;
                this.wsTransferFactoryClient.ClientCredentials.Windows.ClientCredential = value;
                this.wsEnumerationClient.ClientCredentials.Windows.ClientCredential = value;
                this.mexClient.ClientCredentials.Windows.ClientCredential = value;
            }
        }

        /// <summary>
        /// Gets or Sets the RmResourceFactory object used to construct resources returned.
        /// </summary>
        public RmResourceFactory ResourceFactory {
            get {
                return this.resourceFactory;
            }
            set {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.resourceFactory = value;
            }
        }

        /// <summary>
        /// Gets or Sets the RmRequestFactory object used to construct request messages.
        /// </summary>
        public RmRequestFactory RequestFactory {
            get {
                return this.requestFactory;
            }
            set {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.requestFactory = value;
            }
        }

        /// <summary>
        /// Returns true if the schema has been cached for this client.
        /// </summary>
        public bool SchemaCached {
            get {
                return this.schemaCached;
            }
        }

        #endregion
    }
}
