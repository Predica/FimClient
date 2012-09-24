using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsTransfer
{
    public class PutResponse
    {
        private Message message;

        public Message Message
        {
            get { return message; }
        }

        public PutResponse() { }

        public PutResponse(Message responseMessage)
        {
            message = responseMessage;
        }

    }
}
