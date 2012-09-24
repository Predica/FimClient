using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class GetRequest : ImdaRequest {
        [XmlElement(Namespace = Constants.Imda.Namespace)]
        public BaseObjectSearchRequest BaseObjectSearchRequest;
    }
}
