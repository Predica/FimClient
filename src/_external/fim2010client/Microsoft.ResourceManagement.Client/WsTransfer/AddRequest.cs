using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class AddRequest {
        private String dialect;
        private List<DirectoryAccessChange> attributeTypes;

        public AddRequest() {
            this.attributeTypes = new List<DirectoryAccessChange>();
            this.dialect = Constants.Dialect.IdmAttributeType;
        }

        [XmlAttribute(AttributeName = Constants.Imda.Dialect)]
        public String Dialect {
            get {
                return this.dialect;
            }
            set {
                this.dialect = value;
            }
        }

        // List so the serializer can add elements
        [XmlElement(ElementName = Constants.Imda.AttributeTypeAndValue)]
        public List<DirectoryAccessChange> AttributeTypeAndValues {
            get {
                return this.attributeTypes;
            }
            set {
                this.attributeTypes = value;
            }
        }
    }
}
