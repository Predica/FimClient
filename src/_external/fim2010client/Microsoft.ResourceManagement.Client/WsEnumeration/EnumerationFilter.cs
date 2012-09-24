using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace, ElementName = Constants.WsEnumeration.Filter)]
    public class EnumerationFilter {
        public EnumerationFilter()
            : this(String.Empty) {

        }
        public EnumerationFilter(String filter) {
            if (String.IsNullOrEmpty(filter))
                throw new ArgumentNullException("filter");
            this.Filter = filter;
            this.Dialect = Constants.Dialect.IdmXpathFilter;
        }
        [XmlText()]
        public String Filter;

        [XmlAttribute()]
        public String Dialect;
    }
}
