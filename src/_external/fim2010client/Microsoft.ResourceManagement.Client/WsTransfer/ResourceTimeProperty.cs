using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(ElementName = Constants.Rm.ResourceTimeProperty, Namespace = Constants.Rm.Namespace)]
    public class ResourceTimeProperty {
        public ResourceTimeProperty()
            : this(DateTime.Now) {
        }

        public ResourceTimeProperty(DateTime value) {
            this.value = value;
        }
        private DateTime value;
        [XmlText(Type = typeof(String))]
        public String Value {
            get {
                return this.value.ToString();
            }
            set {
                if (value != null) {
                    try {
                        this.value = DateTime.Parse(value);
                    } catch (FormatException) {
                        throw;
                    }
                }
            }
        }
    }
}
