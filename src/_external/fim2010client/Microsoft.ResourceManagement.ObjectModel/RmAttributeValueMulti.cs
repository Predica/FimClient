using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The value of a multi-valued attribute.
    /// </summary>
    [Serializable]
    public class RmAttributeValueMulti : RmAttributeValue {

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmAttributeValueMulti()
            : base(true) {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="values">The values.</param>
        public RmAttributeValueMulti(IEnumerable<IComparable> values)
            : this() {
            this.attributeValues.AddRange(values);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected RmAttributeValueMulti(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context, true) {
        }

    }
}
