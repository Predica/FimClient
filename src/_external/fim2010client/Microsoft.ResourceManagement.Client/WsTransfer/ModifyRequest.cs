using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class ModifyRequest {
        private String dialect;
        private List<DirectoryAccessChange> changes;

        public ModifyRequest() {
            this.changes = new List<DirectoryAccessChange>();
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

        [XmlElement(ElementName = Constants.Imda.Change)]
        public List<DirectoryAccessChange> Changes {
            get {
                return this.changes;
            }
            set {
                this.changes = value;
            }
        }
    }
}
