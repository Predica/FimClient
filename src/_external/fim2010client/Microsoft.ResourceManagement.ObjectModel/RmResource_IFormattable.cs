using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.ObjectModel {
    
    /// <summary>
    /// IFormattable implementation of RmResource
    /// </summary>
    partial class RmResource : IFormattable {

        #region IFormattable Members

        /// <summary>
        /// Return a string with the value of the attribute whose name is passed 
        /// as format.
        /// If the attribute is multi valued, returns a string with the 
        /// concatenation of the values separated by ';'
        /// </summary>
        /// <example>
        /// obj.ToString("DisplayName") -> returns DisplayName of the object.
        /// string.Format("{0:DisplayName}",obj) -> returns DisplayName of the object.
        /// </example>
        public string ToString(
            string format, 
            IFormatProvider formatProvider) {
            if (string.IsNullOrEmpty(format)) {
                return this.ToString();
            }
            RmAttributeName key = new RmAttributeName(format);
            if (!attributes.ContainsKey(key)) {
                return string.Empty;
            }
            RmAttributeValue value = attributes[key];
            if (value.IsMultiValue) {
                // make an array of string values
                string[] values = value.Values.ConvertAll<string>(x => GetString(x)).ToArray();
                return string.Join("; ", values);
            }
            return GetString(value.Value);
        }

        /// <summary>
        /// Get string checking if object is null.
        /// </summary>
        private string GetString(object x) {
            return x == null ? string.Empty : x.ToString();
        }

        #endregion

    }
}
