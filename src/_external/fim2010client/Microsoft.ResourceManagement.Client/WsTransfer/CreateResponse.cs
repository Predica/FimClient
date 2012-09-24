using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class CreateResponse {
        [XmlElement(Namespace = Constants.WsTransfer.Namespace)]
        public ResourceCreated ResourceCreated;
    }
}
