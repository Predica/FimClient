using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;

namespace Microsoft.ResourceManagement.Client {

    public sealed class ContextMessageHeader : MessageHeader {
        // Fields
        public const string ContextHeaderName = "Context";
        public const string ContextHeaderNamespace = "http://schemas.microsoft.com/ws/2006/05/context";
        public const string ContextPropertyElement = "Property";
        public const string ContextPropertyNameAttribute = "name";


        public string Value {
            get;
            private set;
        }

        // Methods
        public ContextMessageHeader(string value) {
            this.Value = value;
        }

        protected override void OnWriteHeaderContents(
            XmlDictionaryWriter writer, 
            MessageVersion messageVersion) {
            if (null == writer) {
                throw new ArgumentNullException("writer");
            }
            writer.WriteStartElement("Property", this.Namespace);
            writer.WriteAttributeString("name", null, "instanceId");
            writer.WriteValue(Value);
            writer.WriteEndElement();

        }

        // Properties
        public override string Name {
            get {
                return ContextHeaderName;
            }
        }

        public override string Namespace {
            get {
                return ContextHeaderNamespace;
            }
        }
    }
}
