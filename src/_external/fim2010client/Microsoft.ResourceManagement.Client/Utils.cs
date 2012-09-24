using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client {
    /// <summary>
    /// Helper (extension) methods for ClientBase-derived classes
    /// </summary>
    static class ClientBaseExtension {
        /// <summary>
        /// Call a method on a <typeparamref name="TChannel"/> object, handling
        /// the channel's faulted state.
        /// </summary>
        public static Message CallChannelMethod<TChannel>(
            this ClientBase<TChannel> client,
            Func<TChannel, Message> method) where TChannel : class {
            TChannel channel = client.ChannelFactory.CreateChannel();
            try {
                Message ret = method(channel);
                ((IDisposable)channel).Dispose();
                return ret;
            } catch (Exception) {
                ICommunicationObject communicationObject = channel as ICommunicationObject;
                if (communicationObject.State == CommunicationState.Faulted) {
                    communicationObject.Abort();
                } else {
                    ((IDisposable)channel).Dispose();
                }
                throw;
            }
        }
    }

}
