using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Set resource.
    /// Automatically generated on 06/30/2010 10:07:55
    /// </summary>
    [Serializable]
    public partial class RmSet : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"Set";

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
        public RmSet()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSet(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        RmList<RmReference> _computedMember;
        
        /// <summary>
        /// Computed Member
        /// Resources in the set that are computed from the membership filter
        /// </summary>
        public IList<RmReference> ComputedMember {
            get {
                if (_computedMember == null) {
                    lock (base.attributes) {
                        _computedMember = GetMultiValuedReference(AttributeNames.ComputedMember);
                    }
                }
                return _computedMember;
            }
        }

        /// <summary>
        /// Filter
        /// A predicate defining a subset of the resources.
        /// </summary>
        public string Filter {
            get { return GetString(AttributeNames.Filter); }
            set { base[AttributeNames.Filter].Value = value; }
        }

        RmList<RmReference> _explicitMember;
        
        /// <summary>
        /// Manually-managed Membership
        /// ExplicitMember
        /// </summary>
        public IList<RmReference> ExplicitMember {
            get {
                if (_explicitMember == null) {
                    lock (base.attributes) {
                        _explicitMember = GetMultiValuedReference(AttributeNames.ExplicitMember);
                    }
                }
                return _explicitMember;
            }
        }

        /// <summary>
        /// Temporal
        /// Defined by a filter that matches resources based on date and time attributes
        /// </summary>
        public bool? Temporal {
            get { return GetNullable<bool>(AttributeNames.Temporal); }
            set { SetNullable (AttributeNames.Temporal, value); }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ComputedMember, true);
            EnsureAttributeExists(AttributeNames.Filter, false);
            EnsureAttributeExists(AttributeNames.ExplicitMember, true);
            EnsureAttributeExists(AttributeNames.Temporal, false);
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
        /// Names of Set specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Computed Member
            /// Resources in the set that are computed from the membership filter
            /// </summary>
            public static RmAttributeName ComputedMember = new RmAttributeName(@"ComputedMember");
            /// <summary>
            /// Filter
            /// A predicate defining a subset of the resources.
            /// </summary>
            public static RmAttributeName Filter = new RmAttributeName(@"Filter");
            /// <summary>
            /// Manually-managed Membership
            /// ExplicitMember
            /// </summary>
            public static RmAttributeName ExplicitMember = new RmAttributeName(@"ExplicitMember");
            /// <summary>
            /// Temporal
            /// Defined by a filter that matches resources based on date and time attributes
            /// </summary>
            public static RmAttributeName Temporal = new RmAttributeName(@"Temporal");
        }
        
        #endregion
        
    }
}
        
