using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
//using Microsoft.IdentityModel.Protocols.WSTrust;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Policy;
using Microsoft.ResourceManagement.WebServices.Client;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    [XmlRoot(Namespace = Constants.WsTrust.Namespace, ElementName = "RequestSecurityTokenResponse",  DataType="FIMRequestSecurityTokenResponse")]
    public class RequestSecurityTokenResponse
    {
        [XmlAnyElement]
        public XmlElement[] OtherElements;

        [XmlElement()]
        public XmlElement RequestedProofToken;
        
        [XmlElement()]
        public String TokenType;

        [XmlElement]
        public XmlElement RequestedSecurityToken;


        [XmlElement]
        public XmlElement RequestedAttachedReference;

        [XmlElement]
        public XmlElement RequestedUnattachedReference;
 

        public Microsoft.ResourceManagement.WebServices.Client.ContextualSecurityToken GetContextTokenFromResponse(ContextMessageProperty context)
        {
            Microsoft.ResourceManagement.WebServices.Client.ContextualSecurityToken returnToken = null;
            if (RequestedSecurityToken != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(new XmlNodeReader(RequestedSecurityToken));
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                nsManager.AddNamespace("saml", "urn:oasis:names:tc:SAML:1.0:assertion");

                DateTime effectiveTime = DateTime.Parse(
                    RequestedSecurityToken.SelectSingleNode(
                        "saml:Conditions/@NotBefore",
                        nsManager
                        ).Value);
                DateTime expirationTime = DateTime.Parse(
                    RequestedSecurityToken.SelectSingleNode(
                        "saml:Conditions/@NotOnOrAfter",
                        nsManager
                        ).Value);
                WSSecurityTokenSerializer serializer = new WSSecurityTokenSerializer();
                SecurityToken requestedProofToken =
                    serializer.ReadToken(
                        new XmlNodeReader(this.RequestedProofToken),
                        new SecurityContextSecurityTokenResolver(Int32.MaxValue, false));
                SecurityKeyIdentifierClause requestedUnattachedReference =
                    serializer.ReadKeyIdentifierClause(new XmlNodeReader(RequestedUnattachedReference));
                SecurityKeyIdentifierClause requestedAttachedReference =
                    serializer.ReadKeyIdentifierClause(new XmlNodeReader(RequestedAttachedReference));

                returnToken = new ContextualSecurityToken(
                        new GenericXmlSecurityToken(
                                RequestedSecurityToken,
                                requestedProofToken,
                                effectiveTime,
                                expirationTime,
                                requestedUnattachedReference,
                                requestedAttachedReference,
                                new ReadOnlyCollection<IAuthorizationPolicy>(new List<IAuthorizationPolicy>())
                            ), context);


            }
            return returnToken;
        }

        [XmlElement (ElementName="AuthenticationChallenge",Namespace="http://schemas.microsoft.com/2006/11/ResourceManagement")]
        public AuthenticationChallenge Authchallenge;

        [XmlElement(ElementName = "AuthenticationChallengeResponse", Namespace = "http://schemas.microsoft.com/2006/11/ResourceManagement")]
        public AuthenticationChallengeResponse AuthChallengeResponse;

      
        [XmlAttribute (AttributeName = "Context")]
        public String Context;



        public String GateName
        {
            get
            {
                return Authchallenge.challenge.workflowAuthChallenge.Name;
            }
        }

        public RequestSecurityTokenResponse()
        {
            this.AuthChallengeResponse = new AuthenticationChallengeResponse();
        }

        public RequestSecurityTokenResponse(Dictionary<int, String> answers)
        {
            this.AuthChallengeResponse = new AuthenticationChallengeResponse(answers);
        }

    }

}
