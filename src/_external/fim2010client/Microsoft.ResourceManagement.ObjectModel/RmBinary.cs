using System;
using System.Text;

namespace Microsoft.ResourceManagement.ObjectModel {
    
    public partial class RmBinary : IComparable, IComparable<RmBinary> {
        
        byte[] value;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmBinary() {
            this.value = new byte[0];
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The value.</param>
        public RmBinary(String value) {
            this.Value = value;
        }

        /// <summary>
        /// The string must be supported by the DateTime class
        /// </summary>
        public String Value {
            get {
                return UnicodeEncoding.UTF8.GetString(this.value);
            }
            set {
                if (value != null) {
                    this.value = UnicodeEncoding.UTF8.GetBytes(value);
                } else {
                    this.value = new byte[0];
                }
            }
        }

        /// <summary>
        /// Gets the value as binary.
        /// </summary>
        /// <value>The value as binary.</value>
        public byte[] ValueAsBinary {
            get {
                return this.value;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj) {
            RmBinary other = obj as RmBinary;
            if (other as Object == null)
                return false;
            else
                return this.ToString().Equals(other.ToString());
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return this.Value;
        }

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance is less than <paramref name="obj"/>.
        /// Zero
        /// This instance is equal to <paramref name="obj"/>.
        /// Greater than zero
        /// This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="obj"/> is not the same type as this instance.
        /// </exception>
        public int CompareTo(object obj) {
            if (obj as Object == null)
                throw new ArgumentNullException("obj");
            return this.CompareTo(obj as RmBinary);
        }

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 as Object == null)
                return false;
            if (attrib2 as Object == null)
                return false;
            return attrib1.CompareTo(attrib2) == 0;
        }

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) != 0;
        }

        /// <summary>
        /// The operator &lt;.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) < 0;
        }

        /// <summary>
        /// The operator &gt;.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) > 0;
        }

        /// <summary>
        /// The operator &lt;=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) <= 0;
        }

        /// <summary>
        /// The operator &gt;=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(RmBinary attrib1, RmBinary attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) >= 0;
        }

        #endregion

        #region IComparable<RmBinary> Members

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This object is less than the <paramref name="other"/> parameter.
        /// Zero
        /// This object is equal to <paramref name="other"/>.
        /// Greater than zero
        /// This object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(RmBinary other) {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                return this.ToString().CompareTo(other.ToString());

        }

        #endregion
    }
}
