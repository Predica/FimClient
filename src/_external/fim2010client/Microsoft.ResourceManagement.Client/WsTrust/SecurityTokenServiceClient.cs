using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml11;

using Microsoft.ResourceManagement.WebServices.WSTrust;


namespace Microsoft.ResourceManagement.Client.WsTrust {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SecurityTokenServiceClient : System.ServiceModel.ClientBase<ISecurityTokenService>, ISecurityTokenService {

        private static long lockInt;

        public SecurityTokenServiceClient() :
            base() {
        }

        public SecurityTokenServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName) {
        }

        public SecurityTokenServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public SecurityTokenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public SecurityTokenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress) {
        }

        public Message RequestSecurityToken(System.ServiceModel.Channels.Message request) {
            return base.Channel.RequestSecurityToken(request);

        }

        public Message RequestSecurityTokenResponse(System.ServiceModel.Channels.Message request) {
            return base.Channel.RequestSecurityTokenResponse(request);
        }

        public Message BuildRequestSecurityTokenMessage(Guid contextGuid) {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] keyEntropy = new byte[256 / 8];
            rng.GetBytes(keyEntropy);
            BinarySecretSecurityToken token =
                new BinarySecretSecurityToken(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "uuid-{0}-{1}",
                        Guid.NewGuid().ToString(),
                        Interlocked.Increment(
                            ref lockInt).ToString(CultureInfo.InvariantCulture)),
                    keyEntropy);

            RequestSecurityToken rst = new RequestSecurityToken(Microsoft.IdentityModel.SecurityTokenService.RequestTypes.Issue);
            rst.TokenType = "http://schemas.xmlsoap.org/ws/2005/02/sc/sct";
            rst.RequestType = "http://schemas.xmlsoap.org/ws/2005/02/trust/Issue";
            rst.KeySizeInBits = 256;
            rst.Context = contextGuid.ToString();
            rst.Entropy = new Entropy(token.GetKeyBytes());


            WSTrustFeb2005RequestSerializer test = new WSTrustFeb2005RequestSerializer();
            WSTrustSerializationContext sc = new WSTrustSerializationContext();
            WSTrustRequestBodyWriter bw = new WSTrustRequestBodyWriter(rst, test, sc);

            MessageVersion mv = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressing10);

            Message request = Message.CreateMessage(mv, Constants.WsTrust.RequestSecurityTokenIssueAction, bw);
            request.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
            request.Headers.To = new Uri("http://localhost:5725/ResourceManagementService/Alternate");
            return request;
        }

        public Message BuildRequestSecurityTokenResponseMessage(RequestSecurityTokenResponse RSTR) {
            ClientSerializer RSTRSerializer = new ClientSerializer(typeof(Client.WsTrust.RequestSecurityTokenResponse));

            MessageVersion mv = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressing10);

            Message request = Message.CreateMessage(mv, Constants.WsTrust.RequestSecurityTokenResponseIssueAction, RSTR, RSTRSerializer);

            request.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
            return request;
        }
    }

}
