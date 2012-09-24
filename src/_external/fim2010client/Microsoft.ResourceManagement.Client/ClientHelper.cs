using System;
using System.ServiceModel.Channels;
using Microsoft.ResourceManagement.Client.Faults;

namespace Microsoft.ResourceManagement.Client {
    public class ClientHelper {
        private ClientHelper() {
        }

        public static void HandleFault(Message message) {
            MessageFault fault = MessageFault.CreateFault(message, Int32.MaxValue);
            throw System.ServiceModel.FaultException.CreateFault(fault,
                typeof(PermissionDeniedFault),
                typeof(AuthenticationRequiredFault),
                typeof(AuthorizationRequiredFault),
                typeof(EndpointUnavailable),
                typeof(FragmentDialectNotSupported),
                typeof(InvalidRepresentationFault),
                typeof(UnwillingToPerformFault),
                typeof(CannotProcessFilter),
                typeof(FilterDialectRequestedUnavailable),
                typeof(UnsupportedExpiration),
                typeof(AnonymousInteractionRequiredFault)
            );
        }

        public static void AddRmHeaders(WsTransfer.TransferRequest transferRequest, Message message) {
            if (transferRequest == null)
                return;

            if (transferRequest.ResourceLocaleProperty != null && String.IsNullOrEmpty(transferRequest.ResourceLocaleProperty.Value) == false) {
                if (message.Headers.FindHeader(Constants.Rm.ResourceLocaleProperty, Constants.Rm.Namespace) < 0) {
                    MessageHeader newHeader = MessageHeader.CreateHeader(Constants.Rm.ResourceLocaleProperty, Constants.Rm.Namespace, transferRequest.ResourceLocaleProperty.Value);
                    message.Headers.Add(newHeader);
                }
            }

            if (transferRequest.ResourceReferenceProperty != null && String.IsNullOrEmpty(transferRequest.ResourceReferenceProperty.Value) == false) {
                if (message.Headers.FindHeader(Constants.Rm.ResourceReferenceProperty, Constants.Rm.Namespace) < 0) {
                    MessageHeader newHeader = MessageHeader.CreateHeader(Constants.Rm.ResourceReferenceProperty, Constants.Rm.Namespace, transferRequest.ResourceReferenceProperty.Value);
                    message.Headers.Add(newHeader);
                }
            }

            if (transferRequest.ResourceTimeProperty != null && String.IsNullOrEmpty(transferRequest.ResourceTimeProperty.Value) == false) {
                if (message.Headers.FindHeader(Constants.Rm.ResourceTimeProperty, Constants.Rm.Namespace) < 0) {
                    MessageHeader newHeader = MessageHeader.CreateHeader(Constants.Rm.ResourceTimeProperty, Constants.Rm.Namespace, transferRequest.ResourceTimeProperty.Value);
                    message.Headers.Add(newHeader);
                }
            }
        }

        public static void AddImdaHeaders(WsTransfer.ImdaRequest imdaRequest, Message message) {
            if (imdaRequest == null)
                return;
            if (message == null) {
                throw new ArgumentNullException("message");
            }
            if (message.Headers.FindHeader(Constants.Imda.ExtensionHeaderName, Constants.Imda.Namespace) < 0) {
                MessageHeader newHeader = MessageHeader.CreateHeader(Constants.Imda.ExtensionHeaderName, Constants.Imda.Namespace, String.Empty, true);
                message.Headers.Add(newHeader);
            }
        }
    }
}
