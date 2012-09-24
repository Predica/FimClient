using System;
using System.Globalization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class ResourceLocaleProperty {
        public ResourceLocaleProperty()
            : this(CultureInfo.CurrentCulture) {
        }

        public ResourceLocaleProperty(CultureInfo value) {
            this.value = value;
        }
        private CultureInfo value;

        public String Value {
            get {
                return this.value.ToString();
            }
            set {
                if (value != null) {
                    this.value = CultureInfo.GetCultureInfo(value);
                }
            }
        }
    }
}
