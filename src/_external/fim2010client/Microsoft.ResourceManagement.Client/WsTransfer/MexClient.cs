using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml.Schema;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    /// <summary>
    /// Communicates with the Metadata Exchange (MEX) endpoint to return Resource Management metadata.
    /// </summary>
    public class MexClient : System.ServiceModel.ClientBase<IMEX>, IMEX {
        public MexClient()
            : base() {
        }
        public MexClient(string endpointConfigurationName) :
            base(endpointConfigurationName) {
        }

        public MexClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public MexClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress) {
        }

        public MexClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress) {
        }

        #region IMetadataExchange Members

        public IAsyncResult BeginGet(Message request, AsyncCallback callback, object state) {
            throw new NotImplementedException();
        }

        public Message EndGet(IAsyncResult result) {
            throw new NotImplementedException();
        }

        public Message Get(Message request) {
            IMEX channel = base.ChannelFactory.CreateChannel();
            return channel.Get(request);
        }

        public XmlSchemaSet Get() {
            Message getRequest = Message.CreateMessage(MessageVersion.Default, Constants.WsTransfer.GetAction);
            Message getResponse = Get(getRequest);
            MetadataSet set = MetadataSet.ReadFrom(getResponse.GetReaderAtBodyContents());
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            foreach (MetadataSection section in set.MetadataSections) {
                if (section.Dialect.Equals(Constants.Xsd.Namespace) && section.Identifier.Equals(":")) {
                    XmlSchema schema = section.Metadata as System.Xml.Schema.XmlSchema;
                    if (schema != null) {
                        schemaSet.Add(schema);
                    }
                }
            }
            schemaSet.Compile();
            return schemaSet;
        }

        #endregion
    }
}
