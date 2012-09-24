using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The value of a binary attribute.
    /// </summary>
    [Serializable]
    partial class RmBinary : ISerializable {

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected RmBinary(
            SerializationInfo info,
            StreamingContext context) {
            this.value = (byte[])info.GetValue("value", typeof(byte[]));
        }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        public void GetObjectData(
            SerializationInfo info,
            StreamingContext context) {
            info.AddValue("value", this.value);
        }

    }

}
