using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class SortingAttribute {
        public SortingAttribute() {
            this.Ascending = true;
        }

        [XmlAttribute()]
        public bool Ascending;

        [XmlText()]
        public String Value;
    }
}
