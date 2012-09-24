using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class Sorting {

        List<SortingAttribute> sorting;

        public Sorting() {
            this.Dialect = Constants.Rm.Namespace;
            this.SortingAttribute = new List<SortingAttribute>();
        }
        [XmlAttribute()]
        public String Dialect;

        [XmlElement()]
        public List<SortingAttribute> SortingAttribute {
            get {
                if (sorting.Count == 0)
                    return null;
                else
                    return sorting;
            }
            set {
                this.sorting = value;
            }
        }
    }
}
