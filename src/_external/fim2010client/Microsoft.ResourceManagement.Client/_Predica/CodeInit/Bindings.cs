using System;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Microsoft.ResourceManagement.Client.CodeInit
{
    public static class Bindings
    {
        public static WSHttpBinding MetadataExchangeHttpBinding_IMetadataExchange
        {
            get
            {
                return new WSHttpBinding(SecurityMode.None)
                {
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    MaxReceivedMessageSize = 2048576
                };
            }

        }

        public static WSHttpContextBinding ServiceMultipleTokenBinding_Common
        {
            get
            {
                var binding = new WSHttpContextBinding(SecurityMode.Message)
                {
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    MaxReceivedMessageSize = 2048576
                };
                binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;
                binding.Security.Message.EstablishSecurityContext = false;

                return binding;
            }
        }
    }
}