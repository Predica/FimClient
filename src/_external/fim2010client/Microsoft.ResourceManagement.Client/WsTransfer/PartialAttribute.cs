using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class PartialAttributeType {
        public PartialAttributeType() {
            this.Values = new List<XmlNode>();
        }
        [XmlAnyElement(Namespace = Constants.Rm.Namespace)]
        public List<XmlNode> Values;
    }
}
