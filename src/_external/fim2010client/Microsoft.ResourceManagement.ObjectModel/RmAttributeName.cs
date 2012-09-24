using System;
using System.Globalization;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// The name of an attribute.
    /// </summary>
    public partial class RmAttributeName : IComparable, ICloneable {

        string name;
        CultureInfo culture;
        string key;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name.</param>
        public RmAttributeName(String name)
            : this(name, null) {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="culture">The culture.</param>
        public RmAttributeName(String name, CultureInfo culture) {
            if (String.IsNullOrEmpty(name)) {
                throw new ArgumentNullException("name");
            }
            this.name = name;
            this.culture = culture;
            ComputeKey();
        }

        /// <summary>
        /// The name of the attribute.
        /// </summary>
        public string Name {
            get {
                return this.name;
            }
            set {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("value");
                }
                this.name = value;
                ComputeKey();
            }
        }

        /// <summary>
        /// The <see cref="CultureInfo"/> of the attribute.
        /// </summary>
        public CultureInfo Culture {
            get {
                return this.culture;
            }
            set {
                this.culture = value;
                ComputeKey();
            }
        }

        void ComputeKey() {
            if (this.culture == null) {
                this.key = this.name;
            } else {
                this.key = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0};{1}", this.name, this.culture.ToString());
            }
        }

        #region Object
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
            RmAttributeName other = obj as RmAttributeName;
            if (other as Object == null) {
                return false;
            } else {
                return this.key.Equals(other.key);
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return this.key.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return this.key;
        }
        #endregion

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
            return String.Compare(key, obj as String, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RmAttributeName attrib1, RmAttributeName attrib2) {
            if (attrib1 as Object == null)
                return false;
            return attrib1.CompareTo(attrib2) == 0;
        }

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RmAttributeName attrib1, RmAttributeName attrib2) {
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
        public static bool operator <(RmAttributeName attrib1, RmAttributeName attrib2) {
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
        public static bool operator >(RmAttributeName attrib1, RmAttributeName attrib2) {
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
        public static bool operator <=(RmAttributeName attrib1, RmAttributeName attrib2) {
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
        public static bool operator >=(RmAttributeName attrib1, RmAttributeName attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) >= 0;
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone() {
            RmAttributeName newObject = new RmAttributeName(this.Name, this.Culture);
            return newObject;
        }

        #endregion
    }
}
