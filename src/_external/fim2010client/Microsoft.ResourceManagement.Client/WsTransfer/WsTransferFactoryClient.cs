using System;
using System.ServiceModel.Channels;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;


namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class WsTransferFactoryClient : System.ServiceModel.ClientBase<IResourceFactory>, IResourceFactory {
        public WsTransferFactoryClient()
            : base() {
        }

        public WsTransferFactoryClient(string endpointConfigurationName) :
            base(endpointConfigurationName) {
        }

        public WsTransferFactoryClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public WsTransferFactoryClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public WsTransferFactoryClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress) {
        }

        public Message Create(Message request) {
            return this.CallChannelMethod((channel) => channel.Create(request));
        }

        public CreateResponse Create(CreateRequest request) {
            if (request == null) {
                throw new ArgumentNullException("request");
            }
            if (request.AddRequest == null) {
                throw new ArgumentNullException("AddRequest");
            }
            Message createRequest = null;
            lock (request) {
                createRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.CreateAction, request.AddRequest, new ClientSerializer(typeof(AddRequest)));
                ClientHelper.AddImdaHeaders(request as ImdaRequest, createRequest);
            }
            Message createResponse = Create(createRequest);

            if (createResponse.IsFault) {
                ClientHelper.HandleFault(createResponse);
            }

            CreateResponse createResponseTyped = new CreateResponse();
            // for a reason which is not clear, this isn't working
            // createResponseTyped.ResourceCreated = createResponse.GetBody<ResourceCreated>(new ClientSerializer(typeof(ResourceCreated)));

            // alternative way to de-serialize the message...
            System.Xml.XmlNode body = createResponse.GetBody<System.Xml.XmlNode>(new ClientSerializer(typeof(System.Xml.XmlNode)));
            createResponseTyped.ResourceCreated = new ResourceCreated();
            createResponseTyped.ResourceCreated.EndpointReference = new EndpointReference();
            try {
                createResponseTyped.ResourceCreated.EndpointReference.Address = body["EndpointReference"]["Address"].InnerText;
                createResponseTyped.ResourceCreated.EndpointReference.ReferenceProperties = new ReferenceProperties();
                createResponseTyped.ResourceCreated.EndpointReference.ReferenceProperties.ResourceReferenceProperty = new ResourceReferenceProperty();
                createResponseTyped.ResourceCreated.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value = body["EndpointReference"]["ReferenceProperties"]["ResourceReferenceProperty"].InnerText;
            } catch (NullReferenceException) {
            }
            return createResponseTyped;
        }

        #region Approvals

        /// <summary>
        /// Submits an approval response message for the pending approval.
        /// </summary>
        /// <param name="approval">The approval object for which to submit an approval response.</param>
        /// <param name="isApproved">True when to approve the approval. False to reject it.</param>
        /// <returns>Returns true if the approval response was accepted.</returns>
        public void Approve(RmApproval approval, bool isApproved) {
            // the AuthZ endpoint does not use the MS-WSTIM extensions.
            // Rather than create a whole new object model or adapt the serializer, I construct the XML manually:
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlNamespaceManager nsManager = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsManager.AddNamespace(Constants.Rm.Prefix, Constants.Rm.Namespace);

            System.Xml.XmlElement approvalResponseElement = doc.CreateElement("rm:ApprovalResponse", Constants.Rm.Namespace);
            System.Xml.XmlElement approvalElement = doc.CreateElement("rm:Approval", Constants.Rm.Namespace);
            approvalElement.InnerText = approval.ObjectID.Value;
            approvalResponseElement.AppendChild(approvalElement);

            System.Xml.XmlElement approvalDecisionElement = doc.CreateElement("rm:Decision", Constants.Rm.Namespace);
            approvalDecisionElement.InnerText = isApproved ? @"Approved" : @"Rejected";
            approvalResponseElement.AppendChild(approvalDecisionElement);

            System.Xml.XmlElement objectTypenElement = doc.CreateElement("rm:ObjectType", Constants.Rm.Namespace);
            objectTypenElement.InnerText = "ApprovalResponse";
            approvalResponseElement.AppendChild(objectTypenElement);

            doc.AppendChild(approvalResponseElement);

            Message requestMessage = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.CreateAction, approvalResponseElement);

            if (String.IsNullOrEmpty(approval.WorkflowInstance.Value)) {
                throw new InvalidOperationException("The approval does not have an active workflow activity.");
            }

            ContextMessageHeader ctx = new ContextMessageHeader(approval.WorkflowInstance.Value);

            requestMessage.Headers.Add(ctx);

            // send the create request. If an error occurs, an exception is thrown.
            Message responseMessage = Create(requestMessage);
        }

        #endregion

    }
}
