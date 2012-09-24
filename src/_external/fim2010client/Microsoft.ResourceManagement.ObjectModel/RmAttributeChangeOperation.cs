using System;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The type of the operation associated to a change in an attribute value.
    /// </summary>
    public enum RmAttributeChangeOperation {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Add a value to a multi valued attribute.
        /// </summary>
        Add = 1,
        /// <summary>
        /// Remove a value from a multi valued attribute.
        /// </summary>
        Delete = 2,
        /// <summary>
        /// Replace the value of a single valued attribute.
        /// </summary>
        Replace = 3
    }

}
