using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class DirectoryAccessChange {
        private String operation;
        private string attributeType;
        private PartialAttributeType attributeValue;
        public DirectoryAccessChange() {
            this.attributeType = String.Empty;
            this.attributeValue = new PartialAttributeType();
        }


        [XmlAttribute(AttributeName = Constants.Imda.Operation)]
        public String Operation {
            get {
                return this.operation;
            }
            set {
                this.operation = value;
            }
        }

        [XmlElement()]
        public String AttributeType {
            get {
                return this.attributeType;
            }
            set {
                this.attributeType = value;
            }
        }

        [XmlElement()]
        public PartialAttributeType AttributeValue {
            get {
                return this.attributeValue;
            }
            set {
                this.attributeValue = value;
            }
        }
    }
}
