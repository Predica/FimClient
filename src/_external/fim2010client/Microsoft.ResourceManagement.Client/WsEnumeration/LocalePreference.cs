using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class LocalePreference {
        [XmlElement()]
        public String Locale;
        [XmlElement()]
        public int PreferenceValue;
    }
}
