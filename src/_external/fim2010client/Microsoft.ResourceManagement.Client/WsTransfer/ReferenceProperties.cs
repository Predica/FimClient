using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class ReferenceProperties {
        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public ResourceReferenceProperty ResourceReferenceProperty;
    }
}
