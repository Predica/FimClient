using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.WsTransfer.Namespace)]
    public class ResourceCreated {
        [XmlElement(Namespace = Constants.Addressing.Namespace)]
        public EndpointReference EndpointReference;
    }
}
