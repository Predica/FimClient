using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ExpectedRuleEntry resource.
    /// Automatically generated on 06/30/2010 10:06:16
    /// </summary>
    [Serializable]
    public partial class RmExpectedRuleEntry : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"ExpectedRuleEntry";

        /// <summary>
        /// Gets the FIM name of the wrapped resource type.
        /// </summary>
        /// <returns>The FIM name of the wrapped resource type.</returns>
        public override string GetResourceType() {
            return ResourceType;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmExpectedRuleEntry()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmExpectedRuleEntry(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Expected Rule Entry Action
        /// Indicates whether to apply or stop applying a sync rule.
        /// </summary>
        public string ExpectedRuleEntryAction {
            get { return GetString(AttributeNames.ExpectedRuleEntryAction); }
            set { base[AttributeNames.ExpectedRuleEntryAction].Value = value; }
        }

        /// <summary>
        /// Resource Parent
        /// This is a reference to the container resource.
        /// </summary>
        public RmReference ResourceParent {
            get { return GetReference(AttributeNames.ResourceParent); }
            set { base[AttributeNames.ResourceParent].Value = value; }
        }

        /// <summary>
        /// Status Error
        /// Sync rule error details upon failure.
        /// </summary>
        public string StatusError {
            get { return GetString(AttributeNames.StatusError); }
            set { base[AttributeNames.StatusError].Value = value; }
        }

        RmList<string> _synchronizationRuleData;
        
        /// <summary>
        /// Synchronization Rule Data
        /// Xml describing the values of workflow parameters.
        /// </summary>
        public IList<string> SynchronizationRuleData {
            get {
                if (_synchronizationRuleData == null) {
                    lock (base.attributes) {
                        _synchronizationRuleData = GetMultiValuedString(AttributeNames.SynchronizationRuleData);
                    }
                }
                return _synchronizationRuleData;
            }
        }

        /// <summary>
        /// Synchronization Rule ID
        /// This is a reference to a SynchronizationRule resource.
        /// </summary>
        public RmReference SynchronizationRuleID {
            get { return GetReference(AttributeNames.SynchronizationRuleID); }
            set { base[AttributeNames.SynchronizationRuleID].Value = value; }
        }

        /// <summary>
        /// Synchronization Rule Name
        /// This is the name of a SynchronizationRule
        /// </summary>
        public string SynchronizationRuleName {
            get { return GetString(AttributeNames.SynchronizationRuleName); }
            set { base[AttributeNames.SynchronizationRuleName].Value = value; }
        }

        /// <summary>
        /// Synchronization Rule Status
        /// Indicates Applied, Not Applied, or Pending.
        /// </summary>
        public string SynchronizationRuleStatus {
            get { return GetString(AttributeNames.SynchronizationRuleStatus); }
            set { base[AttributeNames.SynchronizationRuleStatus].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ExpectedRuleEntryAction, false);
            EnsureAttributeExists(AttributeNames.ResourceParent, false);
            EnsureAttributeExists(AttributeNames.StatusError, false);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleData, true);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleID, false);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleName, false);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleStatus, false);
            // ensure custom (non FIM-standard) attributes exist.
            EnsureCustomAttributesExist();
        }
        
        /// <summary>
        /// Implement this method to ensure that custom attributes, i.e.
        /// attributes not defined in the default FIM schema, exist.
        /// </summary>
        partial void EnsureCustomAttributesExist();
        
        #endregion
        
        #region AttributeNames
        
        /// <summary>
        /// Names of ExpectedRuleEntry specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Expected Rule Entry Action
            /// Indicates whether to apply or stop applying a sync rule.
            /// </summary>
            public static RmAttributeName ExpectedRuleEntryAction = new RmAttributeName(@"ExpectedRuleEntryAction");
            /// <summary>
            /// Resource Parent
            /// This is a reference to the container resource.
            /// </summary>
            public static RmAttributeName ResourceParent = new RmAttributeName(@"ResourceParent");
            /// <summary>
            /// Status Error
            /// Sync rule error details upon failure.
            /// </summary>
            public static RmAttributeName StatusError = new RmAttributeName(@"StatusError");
            /// <summary>
            /// Synchronization Rule Data
            /// Xml describing the values of workflow parameters.
            /// </summary>
            public static RmAttributeName SynchronizationRuleData = new RmAttributeName(@"SynchronizationRuleData");
            /// <summary>
            /// Synchronization Rule ID
            /// This is a reference to a SynchronizationRule resource.
            /// </summary>
            public static RmAttributeName SynchronizationRuleID = new RmAttributeName(@"SynchronizationRuleID");
            /// <summary>
            /// Synchronization Rule Name
            /// This is the name of a SynchronizationRule
            /// </summary>
            public static RmAttributeName SynchronizationRuleName = new RmAttributeName(@"SynchronizationRuleName");
            /// <summary>
            /// Synchronization Rule Status
            /// Indicates Applied, Not Applied, or Pending.
            /// </summary>
            public static RmAttributeName SynchronizationRuleStatus = new RmAttributeName(@"SynchronizationRuleStatus");
        }
        
        #endregion
        
    }
}
        
