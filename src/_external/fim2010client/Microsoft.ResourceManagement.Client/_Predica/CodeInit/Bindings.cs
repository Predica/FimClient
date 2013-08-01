using System;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Microsoft.ResourceManagement.Client.CodeInit
{
    public static class Bindings
    {
        public static WSHttpBinding MetadataExchangeHttpBinding_IMetadataExchange(TimeSpan? receiveTimeout = null, int? maxReceivedMessageSize = null)
        {
            return new WSHttpBinding(SecurityMode.None)
            {
                ReceiveTimeout = receiveTimeout ?? new TimeSpan(0, 10, 0),
                MaxReceivedMessageSize = maxReceivedMessageSize ?? 2048576
            };
        }

        public static WSHttpContextBinding ServiceMultipleTokenBinding_Common(TimeSpan? receiveTimeout = null, int? maxReceivedMessageSize = null)
        {
            var binding = new WSHttpContextBinding(SecurityMode.Message)
            {
                ReceiveTimeout = receiveTimeout ?? new TimeSpan(0, 10, 0),
                MaxReceivedMessageSize = maxReceivedMessageSize ?? 2048576
            };
            binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;
            binding.Security.Message.EstablishSecurityContext = false;

            return binding;
        }        
    }
}