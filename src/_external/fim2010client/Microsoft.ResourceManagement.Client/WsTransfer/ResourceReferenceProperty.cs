using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class ResourceReferenceProperty {
        public ResourceReferenceProperty()
            : this(null) {
        }

        public ResourceReferenceProperty(String value) {
            this.value = value;
        }
        private String value;
        [XmlText(Type = typeof(String))]
        public String Value {
            get {
                return this.value;
            }
            set {
                this.value = value;
            }
        }
    }
}
