using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace, ElementName = Constants.WsEnumeration.Enumerate)]
    public class EnumerationRequest {
        public EnumerationRequest()
            : this(null) {

        }

        public EnumerationRequest(String filter) {
            this.MaxCharacters = Constants.WsEnumeration.DefaultMaxCharacters;

            int pageSize;
            string configPageSize = ConfigurationManager.AppSettings["FimEnumerationPageSize"];

            if (int.TryParse(configPageSize, out pageSize) == false)
            {
                pageSize = Constants.WsEnumeration.DefaultMaxElements;
            }

            this.MaxElements = pageSize;

            if (String.IsNullOrEmpty(filter) == false) {
                this.Filter = new EnumerationFilter(filter);
            }
        }

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public EnumerationFilter Filter;

        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public LocalePreferences LocalePreferences;

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public Int32 MaxElements;

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public Int32 MaxCharacters;

        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public Sorting Sorting;

        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public List<String> Selection;

        // Time should be in the ResourceManagement namespace
        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public String Time;
    }
}
