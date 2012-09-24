using System;

namespace Microsoft.ResourceManagement.ObjectModel {

    /// <summary>
    /// A <see cref="DateTime"/> value.
    /// </summary>
    public class RmDateTime : 
        IComparable, 
        IComparable<RmDateTime> {

        DateTime value;
        String stringValue;
        public RmDateTime() {
            this.Value = String.Empty;
        }
        public RmDateTime(String value) {
            this.Value = value;
        }
        /// <summary>
        /// The string must be supported by the DateTime class
        /// </summary>
        public String Value {
            get {
                return this.stringValue;
            }
            set {
                if (value != null) {
                    this.value = DateTime.Parse(value);
                    this.stringValue = this.value.ToString();
                } else {
                    this.value = DateTime.MinValue;
                    this.stringValue = null;
                }
            }
        }

        public DateTime ValueAsDateTime {
            get {
                return this.value;
            }
        }

        public override bool Equals(object obj) {
            RmDateTime other = obj as RmDateTime;
            if (other as Object == null)
                return false;
            else
                return this.value.Equals(other.value);
        }

        public override int GetHashCode() {
            return this.value.GetHashCode();
        }

        public override string ToString() {
            return this.stringValue;
        }



        #region IComparable Members

        public int CompareTo(object obj) {
            if (obj as Object == null)
                throw new ArgumentNullException("obj");
            RmDateTime datetime = obj as RmDateTime;
            if (datetime as Object == null)
                throw new ArgumentNullException("obj");
            return this.CompareTo(datetime);
        }

        public static bool operator ==(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 as Object == null)
                return false;
            if (attrib2 as Object == null)
                return false;
            return attrib1.CompareTo(attrib2) == 0;
        }

        public static bool operator !=(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) != 0;
        }

        public static bool operator <(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) < 0;
        }

        public static bool operator >(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) > 0;
        }

        public static bool operator <=(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) <= 0;
        }

        public static bool operator >=(RmDateTime attrib1, RmDateTime attrib2) {
            if (attrib1 == null)
                return false;
            return attrib1.CompareTo(attrib2) >= 0;
        }

        #endregion

        #region IComparable<RmDateTime> Members

        public int CompareTo(RmDateTime other) {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                return this.value.CompareTo(other.value);

        }

        #endregion
    }
}
