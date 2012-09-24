using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client {
    /// <summary>
    /// XmlObjectSerializer-based Serializer, wraps XMLSerializer
    /// </summary>
    public class ClientSerializer : XmlObjectSerializer {
        // My private serialzer and my internal type
        XmlSerializer privateSerializer;

        /// <summary>
        /// Constructor to set type
        /// </summary>
        /// <param name="type"></param>
        public ClientSerializer(Type type) {
            privateSerializer = new XmlSerializer(type);
        }

        /// <summary>
        /// IsStartObject returns true if the object found in the read can be deserialized.  We use CanDeserialize to get the answer.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override bool IsStartObject(System.Xml.XmlDictionaryReader reader) {
            return privateSerializer.CanDeserialize(reader);
        }

        /// <summary>
        /// ReadObject is used to read and object from the reader.  Deserialize will do the work.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="verifyObjectName"></param>
        /// <returns></returns>
        public override object ReadObject(System.Xml.XmlDictionaryReader reader, bool verifyObjectName) {
            object result = null;

            if (!verifyObjectName || this.IsStartObject(reader)) {
                result = privateSerializer.Deserialize(reader);
            }

            return result;
        }

        /// <summary>
        /// WriteStartObject is used to start off the object.  Since the XMLSerialzer does all the work, nothing is needed here.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="graph"></param>
        public override void WriteStartObject(System.Xml.XmlDictionaryWriter writer, object graph) {
        }

        /// <summary>
        /// WriteEndObject is used to close up the object.  Since the XMLSerialzer does all the work, nothing is needed here.
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteEndObject(System.Xml.XmlDictionaryWriter writer) {
        }

        /// <summary>
        /// WriteObjectContent is called to serialze the object to writer.  Serialze will do the work here.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="graph"></param>

        public override void WriteObjectContent(System.Xml.XmlDictionaryWriter writer, object graph) {
            if (null != graph) {
                ICollection objectList = graph as ICollection;
                if (objectList != null) {
                    // handle the list case
                    foreach (object currentObject in objectList) {
                        privateSerializer.Serialize(writer, currentObject);
                    }
                } else {
                    // handle the scalar case
                    privateSerializer.Serialize(writer, graph);
                }
            }
        }
    }
}
