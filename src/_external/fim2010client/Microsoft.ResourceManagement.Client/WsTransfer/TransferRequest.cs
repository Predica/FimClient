using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class TransferRequest {
        public TransferRequest() {
        }

        [XmlIgnore()]
        public ResourceReferenceProperty ResourceReferenceProperty;

        [XmlIgnore()]
        public ResourceLocaleProperty ResourceLocaleProperty;

        [XmlIgnore()]
        public ResourceTimeProperty ResourceTimeProperty;
    }
}
