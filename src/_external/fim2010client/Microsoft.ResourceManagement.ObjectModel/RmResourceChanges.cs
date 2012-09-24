using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.ResourceManagement.ObjectModel {
    /// <summary>
    /// A transaction object monitors the changes made to an RmResource object.
    /// 
    /// Use this class to check for changes when updating the Resource Management Service.
    /// </summary>
    public class RmResourceChanges : IDisposable {
        private RmResource rmObject;
        private Dictionary<RmAttributeName, RmAttributeValue> originalAttributes;

        /// <summary>
        /// The <see cref="RmObject"/> for which changes are being monitored.
        /// </summary>
        public RmResource RmObject {
            get {
                return this.rmObject;
            }
        }

        /// <summary>
        /// Begins a transaction on the provided RmResource object.
        /// </summary>
        /// <param name="rmObject">The object to watch during the transaction.</param>
        public RmResourceChanges(RmResource rmObject) {
            if (rmObject == null) {
                throw new ArgumentNullException("rmObject");
            }
            this.rmObject = rmObject;
        }

        /// <summary>
        /// Returns a list of changes made to this object since the transaction began or the last call to AcceptChanges.
        /// </summary>
        /// <returns></returns>
        public IList<RmAttributeChange> GetChanges() {
            EnsureNotDisposed();
            lock (rmObject.Attributes) {
                // there was no original, so we just return an empty list
                if (originalAttributes == null) {
                    return new List<RmAttributeChange>();
                } else {
                    return RmResourceChanges.GetDifference(rmObject.Attributes, this.originalAttributes);
                }
            }
        }

        /// <summary>
        /// Starts tracking changes in the underlying <see cref="RmResource"/>.
        /// </summary>
        public void BeginChanges() {
            EnsureNotDisposed();
            lock (rmObject.attributes) {
                this.originalAttributes = new Dictionary<RmAttributeName, RmAttributeValue>();
                foreach (RmAttributeName key in rmObject.attributes.Keys) {
                    RmAttributeValue value = rmObject.attributes[key];
                    this.originalAttributes[key] = value.Clone() as RmAttributeValue;
                }
            }
        }

        /// <summary>
        /// Commits all of the changes made the RmResource object.
        /// 
        /// GetChanges() will return an empty list immediately after this call.
        /// </summary>
        public void AcceptChanges() {
            EnsureNotDisposed();
            lock (rmObject.attributes) {
                this.originalAttributes = null;
            }
        }

        /// <summary>
        /// Discards all of the changes made ot the RmResource object since the transaction began or a call to AcceptChanges()
        /// </summary>
        public void DiscardChanges() {
            EnsureNotDisposed();
            lock (rmObject.attributes) {
                rmObject.attributes = this.originalAttributes;
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            EnsureNotDisposed();
            lock (rmObject.attributes) {
                this.originalAttributes = null;
                GC.SuppressFinalize(this);
                this.rmObject = null;
            }
        }

        private void EnsureNotDisposed() {
            if (this.rmObject == null) {
                throw new ObjectDisposedException("RmObjectTransaction", "The RmObjectTransaction object has already been disposed");
            }
        }

        #endregion

        #region difference calculation

        /// <summary>
        /// Returns a list of changes to make to source in order for it to look like destination.
        /// </summary>
        /// <param name="source">The starting object state.</param>
        /// <param name="destination">The ending object state.</param>
        /// <returns>A list of RmAttributeChanges to apply to source for it to look like destination</returns>
        public static IList<RmAttributeChange> GetDifference(RmResource source, RmResource destination) {
            if (source == null) {
                throw new ArgumentNullException("source");
            }
            if (destination == null) {
                throw new ArgumentNullException("destination");
            }
            return GetDifference(source.attributes, destination.attributes);
        }

        /// <summary>
        /// Gets the differences from source and destination attributes.
        /// </summary>
        /// <param name="sourceAttributes">The source attributes.</param>
        /// <param name="destinationAttributes">The destination attributes.</param>
        /// <returns></returns>
        private static IList<RmAttributeChange> GetDifference(
            Dictionary<RmAttributeName, RmAttributeValue> sourceAttributes, 
            Dictionary<RmAttributeName, RmAttributeValue> destinationAttributes) {

            IList<RmAttributeChange> changedAttributes = new List<RmAttributeChange>();
            // iterate source attributes
            foreach (KeyValuePair<RmAttributeName, RmAttributeValue> sourceItem in sourceAttributes) {
                RmAttributeName sourceName = sourceItem.Key;
                RmAttributeValue sourceValue = sourceItem.Value;
                if (!destinationAttributes.ContainsKey(sourceName)) {
                    // the destination does not contain the attribute
                    if (sourceValue.IsMultiValue) {
                        // add all the values
                        foreach (IComparable value1 in sourceValue.Values) {
                            changedAttributes.Add(new RmAttributeChange(sourceName, value1, RmAttributeChangeOperation.Add));
                        }
                    } else {
                        changedAttributes.Add(new RmAttributeChange(sourceItem.Key, null, RmAttributeChangeOperation.Replace));
                    }
                } else {
                    // the destination contains the attribute
                    RmAttributeValue destinationValue = destinationAttributes[sourceItem.Key];
                    if (sourceValue.IsMultiValue) {
                        foreach (IComparable value1 in sourceValue.Values) {
                            if (destinationValue.Values.Contains(value1) == false) {
                                changedAttributes.Add(new RmAttributeChange(sourceItem.Key, value1, RmAttributeChangeOperation.Add));
                            }
                        }
                        foreach (IComparable value2 in destinationValue.Values) {
                            if (sourceItem.Value.Values.Contains(value2) == false) {
                                changedAttributes.Add(new RmAttributeChange(sourceItem.Key, value2, RmAttributeChangeOperation.Delete));
                            }
                        }
                    } else {
                        if (destinationValue.Value != sourceValue.Value) {
                            RmAttributeChangeOperation operation;
                            if (
                                (
                                // <[MA] change 24-11-2011> - cleared reference attributes require Delete operation
                                destinationValue.Value is RmReference
                                ||
                                // <[MA] change 05-03-2012> - cleared date attributes require Delete operation
                                destinationValue.Value is DateTime?
                                )
                                && sourceValue.Value == null
                                )
                            {
                                operation = RmAttributeChangeOperation.Delete;
                            }
                            else
                            {
                                operation = RmAttributeChangeOperation.Replace;
                            }
                            changedAttributes.Add(new RmAttributeChange(sourceItem.Key, sourceValue.Value, operation));
                            // </[MA]>
                        }
                    }
                }
            }
            // iterate destination attributes
            foreach (KeyValuePair<RmAttributeName, RmAttributeValue> destinationItem in destinationAttributes) {
                if (sourceAttributes.ContainsKey(destinationItem.Key) == false) {
                    foreach (IComparable value2 in destinationItem.Value.Values) {
                        changedAttributes.Add(new RmAttributeChange(destinationItem.Key, value2, RmAttributeChangeOperation.Delete));
                    }
                }
            }
            return changedAttributes;
        }
        #endregion
    }
}
