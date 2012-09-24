using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace)]
    public class PullItem {
        public PullItem() {
            this.Values = new List<XmlNode>();
        }
        [XmlAnyElement(Namespace = Constants.Rm.Namespace)]
        public List<XmlNode> Values;

    }
}
