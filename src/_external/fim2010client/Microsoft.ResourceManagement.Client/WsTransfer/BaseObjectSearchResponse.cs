using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class BaseObjectSearchResponse {
        private List<PartialAttributeType> partialAttributes;
        public BaseObjectSearchResponse() {
            this.partialAttributes = new List<PartialAttributeType>();
        }

        [XmlElement(ElementName = Constants.Imda.PartialAttribute)]
        public List<PartialAttributeType> PartialAttributes {
            get {
                return this.partialAttributes;
            }
            set {
                this.partialAttributes = value;
            }
        }
    }
}
