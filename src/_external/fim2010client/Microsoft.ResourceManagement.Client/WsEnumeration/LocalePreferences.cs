using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class LocalePreferences {
        public LocalePreferences() {
            this.localePreference = new List<LocalePreference>();
        }
        List<LocalePreference> localePreference;
        public List<LocalePreference> LocalePreference {
            get {
                if (this.localePreference == null || this.localePreference.Count == 0)
                    return null;
                else
                    return this.localePreference;
            }
            set {
                this.localePreference = value;
            }
        }
    }
}
