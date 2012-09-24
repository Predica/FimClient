using System;
using System.Collections.Generic;

namespace Microsoft.ResourceManagement.ObjectModel {
    /// <summary>
    /// Represents the base Resource object type.
    /// 
    /// This class is a weakly-typed property bag implemented as a dictionary.
    /// Some attributes like ObjectId, DisplayName, and ObjectType have been 
    /// propomoted to .NET properties.
    /// 
    /// Derived object types like RmUser can promote other properties which are 
    /// specific to those object types.
    /// 
    /// Use a RmResourceTransaction to monitor changes made to resource objects.
    /// </summary>
    public partial class RmResource :
        IDictionary<RmAttributeName, RmAttributeValue>,
        IDisposable {

        /// <summary>
        /// The attributes dictionary
        /// </summary>
        protected internal Dictionary<RmAttributeName, RmAttributeValue> attributes;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmResource() {
            attributes = new Dictionary<RmAttributeName, RmAttributeValue>();
            EnsureAllAttributesExist();
            ObjectType = GetResourceType();
        }

        /// <summary>
        /// Gets the type of the wrapped resource (FIM type name).
        /// </summary>
        /// <returns></returns>
        public virtual string GetResourceType() {
            return @"Resource";
        }

        /// <summary>
        /// Gets the attributes dictionary.
        /// </summary>
        /// <value>The attributes dictionary.</value>
        public Dictionary<RmAttributeName, RmAttributeValue> Attributes {
            get { return attributes; }
        }

        #region promoted properties

        // PATCHED : added Creator property
        /// <summary>
        /// A reference attribute that refers to the resource that directly 
        /// created the resource in the FIM service database. This attribute 
        /// is assigned its value by the FIM service. 
        /// It cannot be modified by any user.
        /// </summary>
        public RmReference Creator {
            get {
                return GetReference(AttributeNames.Creator);
            }
        }

        // PATCHED : added CreatedTime property
        /// <summary>
        /// The time when the resource is created in the FIM service database.
        /// </summary>
        public DateTime? CreatedTime {
            get {
                return GetNullable<DateTime>(AttributeNames.CreatedTime);
            }
        }

        // PATCHED : added DeletedTime property
        /// <summary>
        /// The time when the current resource is deleted from the FIM service database.
        /// </summary>
        public DateTime? DeletedTime {
            get {
                return GetNullable<DateTime>(AttributeNames.DeletedTime);
            }
        }

        /// <summary>
        /// Resource description.
        /// </summary>
        public string Description {
            get {
                return GetString(AttributeNames.Description);
            }
            set {
                this[AttributeNames.Description].Value = value;
            }
        }

        /// <summary>
        /// Resource display name.
        /// </summary>
        public string DisplayName {
            get {
                return GetString(AttributeNames.DisplayName);
            }
            set {
                this[AttributeNames.DisplayName].Value = value;
            }
        }

        // PATCHED : added ExpirationTime property
        /// <summary>
        /// The date and time when the resource expires.
        /// </summary>
        public DateTime? ExpirationTime {
            get {
                return GetNullable<DateTime>(AttributeNames.ExpirationTime);
            }
        }

        // PATCHED : added MVObjectID property
        /// <summary>
        /// The GUID of an entry in the FIM metaverse corresponding to this resource.
        /// </summary>
        public string MVObjectID {
            get {
                return GetString(AttributeNames.MVObjectID);
            }
        }

        /// <summary>
        /// Globally unique identifier (GUID) assigned by FIM to each resource 
        /// when it is created.
        /// </summary>
        public RmReference ObjectID {
            get {
                return GetReference(AttributeNames.ObjectID);
            }
            set {
                attributes[AttributeNames.ObjectID].Value = value;
            }
        }

        /// <summary>
        /// The resource type of a resource. 
        /// </summary>
        public string ObjectType {
            get {
                return GetString(AttributeNames.ObjectType);
            }
            set {
                this[AttributeNames.ObjectType].Value = value;
            }
        }

        /// <summary>
        /// The region and language for which the representation of a resource 
        /// has been adapted.
        /// </summary>
        public string Locale {
            get {
                return GetString(AttributeNames.Locale);
            }
            set {
                this[AttributeNames.Locale].Value = value;
            }
        }


        // PATCHED : added ResourceTime property
        /// <summary>
        /// The date and time of a representation of a resource.
        /// </summary>
        public DateTime? ResourceTime {
            get {
                return GetNullable<DateTime>(AttributeNames.ResourceTime);
            }
        }

        #endregion

        #region Helper methods for attribute getters

        /// <summary>
        /// Gets the value of an attribute as a string.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        protected string GetString(RmAttributeName attributeName) {
            object o = null;
            RmAttributeValue rma = null;
            TryGetValue(attributeName, out rma);
            if (rma != null)
                o = rma.Value;
            if (o == null) {
                return string.Empty;
            } else {
                return (string)o;
            }
        }

        /// <summary>
        /// Gets the value of an attribute as a reference.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        protected RmReference GetReference(RmAttributeName attributeName) {
            IComparable o = null;
            RmAttributeValue rma = null;
            attributes.TryGetValue(attributeName, out rma);
            if (rma != null && rma.Value != null)
                o = rma.Value;
            return o as RmReference;
        }

        /// <summary>
        /// Gets the value of an attribute as a nullable type.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        protected Nullable<TValue> GetNullable<TValue>(RmAttributeName attributeName)
            where TValue : struct {
            RmAttributeValue rma = null;
            if (attributes.TryGetValue(attributeName, out rma)) {
                if (null != rma.Value) {
                    try {
                        return (TValue)rma.Value;
                    } catch (InvalidCastException exc) {
                        // This happens if the schema was not read correctly.
                        // Add some information and use original exception as
                        // inner exception.
                        throw new InvalidCastException(
                            string.Format(
                                "Cannot cast attribute '{0}' ({1}) to {2}.",
                                attributeName.Name, 
                                rma.Value.GetType(), 
                                typeof(TValue)),
                            exc); 
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Sets the value of a nullable attribute.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="value">The value.</param>
        protected void SetNullable<TValue>(RmAttributeName attributeName, Nullable<TValue> value)
            where TValue : struct, IComparable  {
            if (value.HasValue) {
                this[attributeName].Value = value.Value;
            } else {
                this[attributeName] = new RmAttributeValueSingle();
            }
        }

        /// <summary>
        /// Gets the value of a multi-valued string attribute.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        protected RmList<string> GetMultiValuedString(RmAttributeName attributeName) {
            IList<IComparable> o = null;
            RmAttributeValue rma = null;
            attributes.TryGetValue(attributeName, out rma);
            if (rma == null) {
                rma = new RmAttributeValueMulti();
                attributes[attributeName] = rma;
            }
            o = rma.Values;
            if (o == null) {
                return null;
            } else {
                return new RmList<string>(o);
            }
        }

        /// <summary>
        /// Gets the value of a multi-valued reference attribute.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        protected RmList<RmReference> GetMultiValuedReference(RmAttributeName attributeName) {
            IList<IComparable> o = null;
            RmAttributeValue rma = null;
            attributes.TryGetValue(attributeName, out rma);
            if (rma == null) {
                rma = new RmAttributeValueMulti();
                attributes[attributeName] = rma;
            }
            o = rma.Values;
            if (o == null) {
                return null;
            } else {
                return new RmList<RmReference>(o);
            }
        }

        #endregion

        /// <summary>
        /// Ensure that all base resource attributes are present in the internal 
        /// dictionary.
        /// </summary>
        protected void EnsureAllAttributesExist() {
            EnsureAttributeExists(AttributeNames.CreatedTime,       false);
            EnsureAttributeExists(AttributeNames.Creator,           false);
            EnsureAttributeExists(AttributeNames.DeletedTime,       false);
            EnsureAttributeExists(AttributeNames.Description,       false);
            EnsureAttributeExists(AttributeNames.DetectedRulesList, true);
            EnsureAttributeExists(AttributeNames.DisplayName,       false);
            EnsureAttributeExists(AttributeNames.ExpectedRulesList, true);
            EnsureAttributeExists(AttributeNames.ExpirationTime,    false);
            EnsureAttributeExists(AttributeNames.Locale,            false);
            EnsureAttributeExists(AttributeNames.MVObjectID,        false);
            EnsureAttributeExists(AttributeNames.ObjectID,          false);
            EnsureAttributeExists(AttributeNames.ObjectType,        false);
            EnsureAttributeExists(AttributeNames.ResourceTime,      false);
            EnsureSpecificAttributesExist();
        }

        /// <summary>
        /// To be overridden by derived classes to ensure that all resource 
        /// specific attributes are present in the internal dictionary.
        /// </summary>
        protected virtual void EnsureSpecificAttributesExist() {         
        }

        /// <summary>
        /// Ensures that the attribute is present in the dictionary.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="multiValued">Indicates if the attribute is multi valued.</param>
        protected void EnsureAttributeExists(RmAttributeName attributeName,bool multiValued) {
            EnsureNotDisposed();
            lock (attributes) {
                if (attributeName == null) {
                    throw new ArgumentNullException("attributeName");
                }
                if (attributes.ContainsKey(attributeName)) {
                    return;
                } else {
                    attributes.Add(attributeName, multiValued ? (RmAttributeValue)new RmAttributeValueMulti() : (RmAttributeValue)new RmAttributeValueSingle());
                }
            }
        }

        /// <summary>
        /// The operator ==.
        /// </summary>
        /// <param name="res1">The res1.</param>
        /// <param name="res2">The res2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(RmResource res1, RmResource res2) {
            if (res1 as object == null)
                return (res2 as object == null);
            if (res2 as object == null)
                return false;
            return res1.Equals(res2);
        }

        /// <summary>
        /// The operator !=.
        /// </summary>
        /// <param name="res1">The res1.</param>
        /// <param name="res2">The res2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(RmResource res1, RmResource res2) {
            if (res1 as object == null)
                return (res2 as object != null);
            if (res2 as object == null)
                return true;
            return !res1.Equals(res2);
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
            RmResource other = obj as RmResource;
            if (other == null) {
                return false;
            } else {
                if (attributes.Count != other.attributes.Count) {
                    return false;
                }
                foreach (KeyValuePair<RmAttributeName, RmAttributeValue> item in attributes) {
                    RmAttributeValue otherValue = null;
                    other.TryGetValue(item.Key, out otherValue);
                    if (otherValue == null)
                        return false;
                    if (item.Value.Equals(otherValue) == false)
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return ObjectID.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return string.Format("{0} '{1}' [{2}]",
                ObjectType,
                DisplayName,
                ObjectID
            );
        }

        #endregion

        #region IDictionary<RmAttributeName,RmAttributeValue> Members

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.
        /// </exception>
        public void Add(RmAttributeName key, RmAttributeValue value) {
            EnsureNotDisposed();
            attributes.Add(key, value);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        public bool ContainsKey(RmAttributeName key) {
            EnsureNotDisposed();
            return attributes.ContainsKey(key);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public ICollection<RmAttributeName> Keys {
            get {
                EnsureNotDisposed();
                return attributes.Keys;
            }
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.
        /// </exception>
        public bool Remove(RmAttributeName key) {
            EnsureNotDisposed();
            return attributes.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param>
        /// <returns>
        /// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="key"/> is null.
        /// </exception>
        public bool TryGetValue(RmAttributeName key, out RmAttributeValue value) {
            EnsureNotDisposed();
            return attributes.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public ICollection<RmAttributeValue> Values {
            get {
                EnsureNotDisposed();
                return attributes.Values;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Microsoft.ResourceManagement.ObjectModel.RmAttributeValue"/> with the specified key.
        /// </summary>
        /// <value></value>
        public RmAttributeValue this[string key] {
            get {
                EnsureNotDisposed();
                return attributes[new RmAttributeName(key)];
            }
            set {
                EnsureNotDisposed();
                RmAttributeName myKey = new RmAttributeName(key);
                attributes[myKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Microsoft.ResourceManagement.ObjectModel.RmAttributeValue"/> with the specified key.
        /// </summary>
        /// <value></value>
        public RmAttributeValue this[RmAttributeName key] {
            get {
                EnsureNotDisposed();
                return attributes[key];
            }
            set {
                EnsureNotDisposed();
                attributes[key] = value;
            }
        }

        #endregion

        #region ICollection<KeyValuePair<RmAttributeName,RmAttributeValue>> Members

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </exception>
        public void Add(KeyValuePair<RmAttributeName, RmAttributeValue> item) {
            EnsureNotDisposed();
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </exception>
        public void Clear() {
            EnsureNotDisposed();
            attributes.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        public bool Contains(KeyValuePair<RmAttributeName, RmAttributeValue> item) {
            EnsureNotDisposed();
            return attributes.ContainsKey(item.Key) && attributes[item.Key].Value.Equals(item.Value);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="arrayIndex"/> is less than 0.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="array"/> is multidimensional.
        /// -or-
        /// <paramref name="arrayIndex"/> is equal to or greater than the length of <paramref name="array"/>.
        /// -or-
        /// The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
        /// -or-
        /// Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(KeyValuePair<RmAttributeName, RmAttributeValue>[] array, int arrayIndex) {
            EnsureNotDisposed();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count {
            get {
                EnsureNotDisposed();
                return attributes.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </exception>
        public bool Remove(KeyValuePair<RmAttributeName, RmAttributeValue> item) {
            EnsureNotDisposed();
            return attributes.Remove(item.Key);
        }

        #endregion

        #region IEnumerable<KeyValuePair<RmAttributeName,RmAttributeValue>> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<RmAttributeName, RmAttributeValue>> GetEnumerator() {
            EnsureNotDisposed();
            return attributes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            EnsureNotDisposed();
            return attributes.GetEnumerator();
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            EnsureNotDisposed();
            lock (attributes) {
                attributes.Clear();
                attributes = null;
                GC.SuppressFinalize(this);
            }
        }

        private void EnsureNotDisposed() {
            if (attributes == null) {
                throw new ObjectDisposedException("RmObject", "The RmObject object has already been disposed");
            }
        }

        #endregion

        /// <summary>
        /// Class with attribute names as RmAttributeName objects.
        /// </summary>
        public sealed class AttributeNames {
            /// <summary>
            /// Created Time
            /// The time when the resource is created in the FIM service database. 
            /// This attribute is assigned its value by the FIM service. 
            /// It cannot be modified by any user.
            /// </summary>
            public static RmAttributeName CreatedTime = new RmAttributeName(@"CreatedTime");
            /// <summary>
            /// Creator
            /// This is a reference attribute that refers to the resource that 
            /// directly created the resource in the FIM service database. This 
            /// attribute is assigned its value by the FIM service. It cannot be 
            /// modified by any user.
            /// </summary>
            public static RmAttributeName Creator = new RmAttributeName(@"Creator");
            /// <summary>
            /// Deleted Time
            /// The time when the current resource is deleted from the FIM 
            /// service database. This attribute is assigned its value by the 
            /// FIM service. It cannot be modified by any user.
            /// </summary>
            public static RmAttributeName DeletedTime = new RmAttributeName(@"DeletedTime");
            /// <summary>
            /// Description
            /// Description
            /// </summary>
            public static RmAttributeName Description = new RmAttributeName(@"Description");
            /// <summary>
            /// Detected Rules List
            /// The synchronization rules detected for resources in external 
            /// systems.
            /// </summary>
            public static RmAttributeName DetectedRulesList = new RmAttributeName(@"DetectedRulesList");
            /// <summary>
            /// Display Name
            /// DisplayName
            /// </summary>
            public static RmAttributeName DisplayName = new RmAttributeName(@"DisplayName");
            /// <summary>
            /// Expected Rules List
            /// This resource has been added to these Synchronization Rules and 
            /// will be manifested in external systems according to the 
            /// Synchronization Rule definitions.
            /// </summary>
            public static RmAttributeName ExpectedRulesList = new RmAttributeName(@"ExpectedRulesList");
            /// <summary>
            /// Expiration Time
            /// The date and time when the resource expires. The appropriate 
            /// Management Policy Rule will delete the resource when the current 
            /// date and time is later than the date and time specified in this 
            /// attribute.
            /// </summary>
            public static RmAttributeName ExpirationTime = new RmAttributeName(@"ExpirationTime");
            /// <summary>
            /// Locale
            /// The region and language for which the representation of a 
            /// resource has been adapted.
            /// </summary>
            public static RmAttributeName Locale = new RmAttributeName(@"Locale");
            /// <summary>
            /// MV Resource ID
            /// The GUID of an entry in the FIM metaverse corresponding to this 
            /// resource.
            /// </summary>
            public static RmAttributeName MVObjectID = new RmAttributeName(@"MVObjectID");
            /// <summary>
            /// Resource ID
            /// The value of the attribute is a globally unique identifier (GUID) 
            /// assigned by FIM to each resource when it is created.
            /// </summary>
            public static RmAttributeName ObjectID = new RmAttributeName(@"ObjectID");
            /// <summary>
            /// Resource Time
            /// The date and time of a representation of a resource. This 
            /// attribute is updated by the FIM service. This attribute can be 
            /// used to define time triggered Management Policy Rules.
            /// </summary>
            public static RmAttributeName ResourceTime = new RmAttributeName(@"ResourceTime");
            /// <summary>
            /// Resource Type
            /// The resource type of a resource. This attribute is assigned its 
            /// value when the resource is created in the FIM service database 
            /// by the FIM service. It cannot be modified by any user.
            /// </summary>
            public static RmAttributeName ObjectType = new RmAttributeName(@"ObjectType");
        }

    }
}
