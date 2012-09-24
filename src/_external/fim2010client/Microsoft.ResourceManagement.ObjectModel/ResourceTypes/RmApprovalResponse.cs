using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ApprovalResponse resource.
    /// Automatically generated on 06/30/2010 10:05:44
    /// </summary>
    [Serializable]
    public partial class RmApprovalResponse : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"ApprovalResponse";

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
        public RmApprovalResponse()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmApprovalResponse(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Approval
        /// Approval
        /// </summary>
        public RmReference Approval {
            get { return GetReference(AttributeNames.Approval); }
            set { base[AttributeNames.Approval].Value = value; }
        }

        RmList<RmReference> _computedActor;
        
        /// <summary>
        /// Computed Actor
        /// This attribute is intended to be used to setup rights as appropriate.
        /// </summary>
        public IList<RmReference> ComputedActor {
            get {
                if (_computedActor == null) {
                    lock (base.attributes) {
                        _computedActor = GetMultiValuedReference(AttributeNames.ComputedActor);
                    }
                }
                return _computedActor;
            }
        }

        /// <summary>
        /// Decision
        /// Decision
        /// </summary>
        public string Decision {
            get { return GetString(AttributeNames.Decision); }
            set { base[AttributeNames.Decision].Value = value; }
        }

        /// <summary>
        /// Reason
        /// Reason
        /// </summary>
        public string Reason {
            get { return GetString(AttributeNames.Reason); }
            set { base[AttributeNames.Reason].Value = value; }
        }

        /// <summary>
        /// Requestor
        /// This attribute is intended to be used to setup rights as appropriate.
        /// </summary>
        public RmReference Requestor {
            get { return GetReference(AttributeNames.Requestor); }
            set { base[AttributeNames.Requestor].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Approval, false);
            EnsureAttributeExists(AttributeNames.ComputedActor, true);
            EnsureAttributeExists(AttributeNames.Decision, false);
            EnsureAttributeExists(AttributeNames.Reason, false);
            EnsureAttributeExists(AttributeNames.Requestor, false);
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
        /// Names of ApprovalResponse specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Approval
            /// Approval
            /// </summary>
            public static RmAttributeName Approval = new RmAttributeName(@"Approval");
            /// <summary>
            /// Computed Actor
            /// This attribute is intended to be used to setup rights as appropriate.
            /// </summary>
            public static RmAttributeName ComputedActor = new RmAttributeName(@"ComputedActor");
            /// <summary>
            /// Decision
            /// Decision
            /// </summary>
            public static RmAttributeName Decision = new RmAttributeName(@"Decision");
            /// <summary>
            /// Reason
            /// Reason
            /// </summary>
            public static RmAttributeName Reason = new RmAttributeName(@"Reason");
            /// <summary>
            /// Requestor
            /// This attribute is intended to be used to setup rights as appropriate.
            /// </summary>
            public static RmAttributeName Requestor = new RmAttributeName(@"Requestor");
        }
        
        #endregion
        
    }
}
        
