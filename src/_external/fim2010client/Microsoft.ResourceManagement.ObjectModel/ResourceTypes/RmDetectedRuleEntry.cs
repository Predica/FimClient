using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// DetectedRuleEntry resource.
    /// Automatically generated on 06/30/2010 10:06:04
    /// </summary>
    [Serializable]
    public partial class RmDetectedRuleEntry : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"DetectedRuleEntry";

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
        public RmDetectedRuleEntry()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmDetectedRuleEntry(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Connector
        /// The resource id of the connector space resource that this DRE was created for.
        /// </summary>
        public string Connector {
            get { return GetString(AttributeNames.Connector); }
            set { base[AttributeNames.Connector].Value = value; }
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
        /// Synchronization Rule ID
        /// This is a reference to a SynchronizationRule resource.
        /// </summary>
        public RmReference SynchronizationRuleID {
            get { return GetReference(AttributeNames.SynchronizationRuleID); }
            set { base[AttributeNames.SynchronizationRuleID].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Connector, false);
            EnsureAttributeExists(AttributeNames.ResourceParent, false);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleID, false);
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
        /// Names of DetectedRuleEntry specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Connector
            /// The resource id of the connector space resource that this DRE was created for.
            /// </summary>
            public static RmAttributeName Connector = new RmAttributeName(@"Connector");
            /// <summary>
            /// Resource Parent
            /// This is a reference to the container resource.
            /// </summary>
            public static RmAttributeName ResourceParent = new RmAttributeName(@"ResourceParent");
            /// <summary>
            /// Synchronization Rule ID
            /// This is a reference to a SynchronizationRule resource.
            /// </summary>
            public static RmAttributeName SynchronizationRuleID = new RmAttributeName(@"SynchronizationRuleID");
        }
        
        #endregion
        
    }
}
        
