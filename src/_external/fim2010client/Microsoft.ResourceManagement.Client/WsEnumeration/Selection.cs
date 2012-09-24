using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class Selection {
        public Selection() {
            this.@string = new List<string>();
        }
        private List<String> stringList;
        [XmlElement()]
        public List<String> @string {
            get {
                return stringList;
            }
            set {
                stringList = value;
            }
        }
    }
}
