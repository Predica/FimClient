using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Imda.Namespace)]
    public class BaseObjectSearchRequest {
        public BaseObjectSearchRequest()
            : this(new String[0] { }) {

        }

        public BaseObjectSearchRequest(String[] attributeNames) {
            if (attributeNames == null)
                throw new ArgumentNullException("attributeNames");
            this.AttributeTypes = new List<string>();
            this.AttributeTypes.AddRange(attributeNames);
            this.Dialect = Constants.Dialect.IdmAttributeType;
        }

        [XmlAttribute(AttributeName = Constants.Imda.Dialect)]
        public String Dialect;

        [XmlElement(ElementName = "AttributeType")]
        public List<String> AttributeTypes;
    }
}
