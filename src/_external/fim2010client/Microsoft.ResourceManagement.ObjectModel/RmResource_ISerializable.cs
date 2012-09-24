using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Microsoft.ResourceManagement.ObjectModel {

    [Serializable]
    partial class RmResource : ISerializable {

        /// <summary>
        /// Serialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <remarks>The call to the base constructor ensures that the 
        /// dictionary is created and filled with attribute names.</remarks>
        protected RmResource(
            SerializationInfo info,
            StreamingContext context)
            : this() {
            // must make a deep copy of attribute keys to avoid modifying the
            // collection being iterated
            List<RmAttributeName> keysCopy = new List<RmAttributeName>(Keys);
            foreach (RmAttributeName name in keysCopy) {
                this[name] = (RmAttributeValue)info.GetValue(name.Name, typeof(RmAttributeValue));
            }
        }

        /// <summary>
        /// Populate the SerializationInfo data needed to serialize the object.
        /// </summary>
        public void GetObjectData(
            SerializationInfo info,
            StreamingContext context) {
            foreach (RmAttributeName name in Keys) {
                info.AddValue(name.Name, this[name]);
            }
        }

    }
}
