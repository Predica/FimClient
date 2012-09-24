using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    internal class ClientMultipleTokenBinding : Binding
    {
        TransportBindingElement tranportBindingElement;

        public ClientMultipleTokenBinding()
            : base("ClientMultipleTokenBinding", "http://schemas.microsoft.com/2006/11/ResourceManagement")
        {
            this.tranportBindingElement = new HttpTransportBindingElement();
        }

        public override BindingElementCollection CreateBindingElements()
        {
            WSHttpContextBinding binding = new WSHttpContextBinding();

            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Message.NegotiateServiceCredential = true;

            BindingElementCollection bindingElements = binding.CreateBindingElements();
            bindingElements.Find<SecurityBindingElement>().OptionalEndpointSupportingTokenParameters.Endorsing.Add(
                new CustomSecurityTokenParameters());
            return bindingElements;
        }

        public override string Scheme
        {
            get { return this.tranportBindingElement.Scheme; }
        }

        class CustomSecurityTokenParameters : IssuedSecurityTokenParameters
        {
            public CustomSecurityTokenParameters()
                : base()
            {
                this.TokenType = "RequestedSecurityToken";
            }
        }
    }

    public class TokenAndClientCredentials : ClientCredentials
    {
        private SecurityToken Token { get; set; }

        public TokenAndClientCredentials(SecurityToken token)
        {
            this.Token = token;
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new TokenAndClientCredentialsSecurityTokenManager(this);
        }

        protected override ClientCredentials CloneCore()
        {
            return new TokenAndClientCredentials(this.Token);
        }

        private class TokenAndClientCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
        {
            private TokenAndClientCredentials Credentials { get; set; }

            public TokenAndClientCredentialsSecurityTokenManager(TokenAndClientCredentials credentials)
                : base(credentials)
            {
                this.Credentials = credentials;
            }

            public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
            {
                if (tokenRequirement.TokenType == "RequestedSecurityToken")
                {
                    return new RequestedSecurityTokenProvider(this.Credentials);
                }

                return base.CreateSecurityTokenProvider(tokenRequirement);
            }

            private class RequestedSecurityTokenProvider : SecurityTokenProvider
            {
                private TokenAndClientCredentials Credentials { get; set; }

                internal RequestedSecurityTokenProvider(TokenAndClientCredentials credentials)
                    : base()
                {
                    this.Credentials = credentials;
                }

                protected override SecurityToken GetTokenCore(TimeSpan timeout)
                {
                    return this.Credentials.Token;
                }
            }
        }
    }
}