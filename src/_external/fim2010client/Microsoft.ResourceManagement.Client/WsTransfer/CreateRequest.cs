using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.WsTransfer.Namespace)]
    public class CreateRequest : ImdaRequest {
        [XmlElement(Namespace = Constants.Imda.Namespace)]
        public AddRequest AddRequest;

    }
}
