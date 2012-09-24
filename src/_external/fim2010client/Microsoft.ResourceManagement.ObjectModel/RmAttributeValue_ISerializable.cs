using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The value of an attribute.
    /// </summary>
    [Serializable]
    partial class RmAttributeValue : ISerializable {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        /// <param name="multiValue">if set to true multi value.</param>
        protected RmAttributeValue(
            SerializationInfo info,
            StreamingContext context,
            bool multiValue)
            : this(multiValue) {
            int count = info.GetInt32("count");
            for (int i = 0; i < count; ++i) {
                IComparable value = (IComparable)info.GetValue(
                    string.Format("values[{0}]", i),
                    typeof(IComparable));
                attributeValues.Add(value);
            }
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
            info.AddValue("count", attributeValues.Count);
            for (int i = 0; i < attributeValues.Count; ++i) {
                info.AddValue(string.Format("values[{0}]", i), attributeValues[i]);
            }
        }

    }
}
