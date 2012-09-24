using System;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// A change in an attribute.
    /// </summary>
    public class RmAttributeChange {

        private RmAttributeName name;
        private IComparable attributeValue;
        private RmAttributeChangeOperation operation;

        internal RmAttributeChange(RmAttributeName name, IComparable atomicValue, RmAttributeChangeOperation operation) {
            this.name = name;
            this.attributeValue = atomicValue;
            this.operation = operation;
        }

        /// <summary>
        /// The name of the attribute.
        /// </summary>
        public RmAttributeName Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        /// <summary>
        /// The value of the attribute.
        /// </summary>
        public IComparable Value {
            get {
                return this.attributeValue;
            }
            set {
                this.attributeValue = value;
            }
        }

        /// <summary>
        /// The operation (change type).
        /// </summary>
        public RmAttributeChangeOperation Operation {
            get {
                return this.operation;
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
            RmAttributeChange other = obj as RmAttributeChange;
            if (other == null) {
                return false;
            }
            if (this.Name == null) {
                return false;
            }
            if (this.Name.Equals(other.Name) == false) {
                return false;
            }
            if (this.Value == null) {
                return other.Value == null;
            } else {
                return this.Value.Equals(other.Value);
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            if (this.attributeValue != null) {
                return this.attributeValue.GetHashCode();
            } else {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}:{1}", this.Name.ToString(), this.Value.ToString());
        }
    }

}
