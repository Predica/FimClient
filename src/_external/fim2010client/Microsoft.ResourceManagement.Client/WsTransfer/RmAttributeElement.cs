using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    public class RmAttributeElement {
        private String value;
        private String permission;
        private bool isNull;

        [XmlAttribute(AttributeName = Constants.Rm.PermissionHints, Namespace = Constants.Rm.Namespace)]
        public String PermissionHints {
            get {
                return this.permission;
            }
            set {
                this.permission = value;
            }
        }

        [XmlAttribute(AttributeName = Constants.Xsi.Nil, Namespace = Constants.Xsi.Namespace)]
        public bool IsNull {
            get {
                return this.isNull;
            }
            set {
                this.isNull = value;
            }
        }

        [XmlText()]
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
