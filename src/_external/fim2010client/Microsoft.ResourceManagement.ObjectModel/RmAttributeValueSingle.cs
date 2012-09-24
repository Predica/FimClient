using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The value of a single-valued attribute.
    /// </summary>
    [Serializable]
    public class RmAttributeValueSingle : RmAttributeValue {

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmAttributeValueSingle()
            : base(false) {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The value.</param>
        public RmAttributeValueSingle(IComparable value) 
            : this() {
            if (value != null)
                this.attributeValues.Add(value);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected RmAttributeValueSingle(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context, false) {
        }

    }

}
