using System;
using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {

    /// <summary>
    /// Given an Xpath filter, the enumeration endpoint returns a collection of resources that match the filter.
    /// </summary>
    public class WsEnumerationClient : System.ServiceModel.ClientBase<IEnumerate>, IEnumerate {
        public WsEnumerationClient()
            : base() {
        }

        public WsEnumerationClient(string endpointConfigurationName) :
            base(endpointConfigurationName) {
        }

        public WsEnumerationClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public WsEnumerationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public WsEnumerationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress) {
        }

        public Message Enumerate(Message request) {
            // PATCHED: handle the channel's faulted state (avoid the using 
            // statement)
            return this.CallChannelMethod((channel) => channel.Enumerate(request));
        }

        public EnumerateResponse Enumerate(EnumerationRequest request) {
            if (request == null) {
                throw new ArgumentNullException("request");
            }

            Message enumerateRequest = null;
            lock (request) {
                enumerateRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsEnumeration.EnumerateAction, request, new ClientSerializer(typeof(EnumerationRequest)));
                // PATCHED: adding the "IncludeCount" header
                // Must add an "IncludeCount" message header to get the total
                // number of matching objects in the response.
                MessageHeader includeCount = MessageHeader.CreateHeader(
                    "IncludeCount", Constants.Rm.Namespace, null);
                enumerateRequest.Headers.Add(includeCount);
            }
            Message enumerateResponse = Enumerate(enumerateRequest);
            if (enumerateResponse.IsFault) {
                // handle fault will throw a .NET exception
                ClientHelper.HandleFault(enumerateResponse);
            }

            EnumerateResponse enumerateResponseTyped = enumerateResponse.GetBody<EnumerateResponse>(new ClientSerializer(typeof(EnumerateResponse)));
            return enumerateResponseTyped;
        }

        public Message Pull(Message request) {
            // PATCHED: handle the channel's faulted state (avoid the using 
            // statement)
            return this.CallChannelMethod((channel) => channel.Pull(request));
        }

        public PullResponse Pull(PullRequest request) {
            if (request == null) {
                throw new ArgumentNullException("request");
            }
            if (request.EnumerationContext == null) {
                throw new InvalidOperationException("EnumerationContext must be set in order to call Pull");
            }
            Message pullRequest;
            lock (request) {
                pullRequest = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, Constants.WsEnumeration.PullAction, request, new ClientSerializer(typeof(PullRequest)));
            }
            Message pullResponse = Pull(pullRequest);
            if (pullResponse.IsFault) {
                // handle fault will throw a .NET exception
                ClientHelper.HandleFault(pullResponse);
            }

            PullResponse pullResponseTyped = pullResponse.GetBody<PullResponse>(new ClientSerializer(typeof(PullResponse)));
            return pullResponseTyped;
        }
    }
}
