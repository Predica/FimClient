using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ResourceManagement.ObjectModel {

    public partial class RmAttributeValue : ICloneable {

        /// <summary>
        /// The values of the attribute.
        /// </summary>
        protected List<IComparable> attributeValues;

        /// <summary>
        /// Indicates if this attribute is multi-valued.
        /// </summary>
        public bool IsMultiValue {
            get;
            protected set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="isMultiValue">if set to true is multi value.</param>
        protected RmAttributeValue(bool isMultiValue) {
            IsMultiValue = isMultiValue;
            this.attributeValues = new List<IComparable>();
        }

        /// <summary>
        /// The values of the attribute.
        /// </summary>
        public List<IComparable> Values {
            get {
                return this.attributeValues;
            }
        }

        /// <summary>
        /// The value of the attribute.
        /// </summary>
        public IComparable Value {
            get {
                if (this.attributeValues.Count > 0) {
                    return this.attributeValues[this.attributeValues.Count - 1];
                } else {
                    return null;
                }
            }
            set {
                lock (this.attributeValues) {
                    this.attributeValues.Clear();
                    if (value != null) {
                        this.attributeValues.Add(value);
                    }
                }
            }
        }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone() {
            RmAttributeValue newValue = new RmAttributeValue(IsMultiValue);
            newValue.attributeValues = new List<IComparable>();
            foreach (IComparable value in this.attributeValues) {
                ICloneable cloneValue = value as ICloneable;
                if (cloneValue == null) {
                    newValue.attributeValues.Add(value);
                } else {
                    IComparable cloneInsert = cloneValue.Clone() as IComparable;
                    if (cloneInsert == null)
                        throw new InvalidOperationException("A comparable, when cloned, returned a non-comparable: " + cloneValue.ToString());
                    newValue.attributeValues.Add(cloneInsert);
                }
            }
            return newValue;
        }

        #endregion

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
            RmAttributeValue other = obj as RmAttributeValue;
            if (other == null)
                return false;
            lock (this.attributeValues) {
                lock (other.attributeValues) {
                    if (this.attributeValues.Count != other.attributeValues.Count)
                        return false;
                    this.attributeValues.Sort();
                    other.attributeValues.Sort();
                    for (int i = 0; i < this.attributeValues.Count; i++) {
                        if (this.attributeValues[i].Equals(other.attributeValues[i]) == false)
                            return false;
                    }
                }
            }
            return true;
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
            lock (this.attributeValues) {
                if (this.attributeValues.Count == 0) {
                    return @"RmAttributeValue.Null";
                } else if (this.attributeValues.Count == 1) {
                    return this.attributeValues[0].ToString();
                } else {
                    StringBuilder sb = new StringBuilder(this.attributeValues.Count);
                    foreach (Object v in this.attributeValues) {
                        sb.Append("{");
                        sb.Append(v);
                        sb.Append("}");
                        sb.Append(@" ");
                    }
                    // take off the last space
                    if (sb.Length > 0) {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
