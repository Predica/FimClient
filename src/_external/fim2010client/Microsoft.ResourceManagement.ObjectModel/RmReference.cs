using System;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// A reference, i.e. a value corresponding to the ObjectID of an <see cref="RmResource"/>.
    /// </summary>
    [Serializable]
    public class RmReference : IComparable, IComparable<RmReference> {
        Guid guidValue;
        String stringValue;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmReference() {
            this.Value = String.Empty;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The value.</param>
        public RmReference(String value) {
            this.Value = value;
        }

        static String RemoveReference(String input) {
            if (String.IsNullOrEmpty(input))
                return Guid.Empty.ToString();
            else
                return input.Replace(@"urn:uuid:", String.Empty);
        }

        static String AddReference(String input) {
            if (String.IsNullOrEmpty(input))
                return null;
            else
                //return String.Format(@"urn:uuid:{0}", this.value.ToString());
                return input;
        }

        /// <summary>
        /// The value of the reference.
        /// </summary>
        public String Value {
            get {
                return this.stringValue;
            }
            set {
                try {
                    string removeReference = RmReference.RemoveReference(value);
                    this.guidValue = new Guid(removeReference);
                    this.stringValue = RmReference.AddReference(this.guidValue.ToString());
                } catch (FormatException exc) {
                    throw new ArgumentException(
                        string.Format("The provided value '{0}' did not match the reference format of urn:uuid:{guid}", value),
                        exc);
                }
            }
        }

        /// <summary>
        /// Sets the value of the reference to a string in the format 
        /// "domain\username". Used only for password reset.
        /// </summary>
        public String DomainAndUserNameValue {
            get {
                return this.stringValue;
            }
            set {
                this.guidValue = Guid.Empty;
                this.stringValue = value;
            }
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return this.stringValue;
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
            RmReference other = obj as RmReference;
            if (other as Object == null || other.guidValue == null)
                return false;
            else
                return other.guidValue.Equals(this.guidValue);
        }
        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return this.guidValue.GetHashCode();
        }

        #region IComparable Members

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
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
            RmReference reference = obj as RmReference;
            if (reference as Object == null)
                throw new ArgumentNullException("obj");
            return this.CompareTo(reference);
        }

        /// <summary>
        /// operator ==.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RmReference attrib1, RmReference attrib2) {
            // PATCHED: comparison (null == object) made the code crash
            if (attrib1 as object == null)
                return (attrib2 as object == null);
            if (attrib2 as object == null)
                return false;
            return attrib1.CompareTo(attrib2) == 0;
        }

        /// <summary>
        /// operator !=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RmReference attrib1, RmReference attrib2) {
            // PATCHED: comparison (null != object) made the code crash
            if (attrib1 as object == null)
                return (attrib2 as object != null);
            if (attrib2 as object == null)
                return true;
            return attrib1.CompareTo(attrib2) != 0;
        }

        /// <summary>
        /// operator &lt;.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(RmReference attrib1, RmReference attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) < 0;
        }

        /// <summary>
        /// operator &gt;.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(RmReference attrib1, RmReference attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) > 0;
        }

        /// <summary>
        /// operator &lt;=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(RmReference attrib1, RmReference attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) <= 0;
        }

        /// <summary>
        /// operator &gt;=.
        /// </summary>
        /// <param name="attrib1">The attrib1.</param>
        /// <param name="attrib2">The attrib2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(RmReference attrib1, RmReference attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) >= 0;
        }

        #endregion

        #region IComparable<RmReference> Members

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// Less than zero
        /// This object is less than the <paramref name="other"/> parameter.
        /// Zero
        /// This object is equal to <paramref name="other"/>.
        /// Greater than zero
        /// This object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(RmReference other) {
            if (other as object == null)
                throw new ArgumentNullException("other");
            else
                return this.guidValue.CompareTo(other.guidValue);
        }

        #endregion
    }
}
