using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Approval resource.
    /// Automatically generated on 06/30/2010 10:05:40
    /// </summary>
    [Serializable]
    public partial class RmApproval : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"Approval";

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
        public RmApproval()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmApproval(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Approval Duration
        /// ApprovalDuration
        /// </summary>
        public DateTime? ApprovalDuration {
            get { return GetNullable<DateTime>(AttributeNames.ApprovalDuration); }
            set { SetNullable (AttributeNames.ApprovalDuration, value); }
        }

        RmList<RmReference> _approvalResponse;
        
        /// <summary>
        /// Approval Response
        /// This is a reference type to ApprovalResponse resource
        /// </summary>
        public IList<RmReference> ApprovalResponse {
            get {
                if (_approvalResponse == null) {
                    lock (base.attributes) {
                        _approvalResponse = GetMultiValuedReference(AttributeNames.ApprovalResponse);
                    }
                }
                return _approvalResponse;
            }
        }

        /// <summary>
        /// Approval Status
        /// ApprovalStatus
        /// </summary>
        public string ApprovalStatus {
            get { return GetString(AttributeNames.ApprovalStatus); }
            set { base[AttributeNames.ApprovalStatus].Value = value; }
        }

        /// <summary>
        /// Approval Threshold
        /// ApprovalThreshold
        /// </summary>
        public int? ApprovalThreshold {
            get { return GetNullable<int>(AttributeNames.ApprovalThreshold); }
            set { SetNullable (AttributeNames.ApprovalThreshold, value); }
        }

        RmList<RmReference> _approver;
        
        /// <summary>
        /// Approver
        /// The set of approvers.
        /// </summary>
        public IList<RmReference> Approver {
            get {
                if (_approver == null) {
                    lock (base.attributes) {
                        _approver = GetMultiValuedReference(AttributeNames.Approver);
                    }
                }
                return _approver;
            }
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

        RmList<string> _endpointAddress;
        
        /// <summary>
        /// Endpoint Address
        /// The endpoint address on which a workflow instance is listening.
        /// </summary>
        public IList<string> EndpointAddress {
            get {
                if (_endpointAddress == null) {
                    lock (base.attributes) {
                        _endpointAddress = GetMultiValuedString(AttributeNames.EndpointAddress);
                    }
                }
                return _endpointAddress;
            }
        }

        /// <summary>
        /// Request
        /// The Request associated with the given Approval.
        /// </summary>
        public RmReference Request {
            get { return GetReference(AttributeNames.Request); }
            set { base[AttributeNames.Request].Value = value; }
        }

        /// <summary>
        /// Requestor
        /// This attribute is intended to be used to setup rights as appropriate.
        /// </summary>
        public RmReference Requestor {
            get { return GetReference(AttributeNames.Requestor); }
            set { base[AttributeNames.Requestor].Value = value; }
        }

        /// <summary>
        /// Workflow Instance
        /// WorkflowInstance
        /// </summary>
        public RmReference WorkflowInstance {
            get { return GetReference(AttributeNames.WorkflowInstance); }
            set { base[AttributeNames.WorkflowInstance].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ApprovalDuration, false);
            EnsureAttributeExists(AttributeNames.ApprovalResponse, true);
            EnsureAttributeExists(AttributeNames.ApprovalStatus, false);
            EnsureAttributeExists(AttributeNames.ApprovalThreshold, false);
            EnsureAttributeExists(AttributeNames.Approver, true);
            EnsureAttributeExists(AttributeNames.ComputedActor, true);
            EnsureAttributeExists(AttributeNames.EndpointAddress, true);
            EnsureAttributeExists(AttributeNames.Request, false);
            EnsureAttributeExists(AttributeNames.Requestor, false);
            EnsureAttributeExists(AttributeNames.WorkflowInstance, false);
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
        /// Names of Approval specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Approval Duration
            /// ApprovalDuration
            /// </summary>
            public static RmAttributeName ApprovalDuration = new RmAttributeName(@"ApprovalDuration");
            /// <summary>
            /// Approval Response
            /// This is a reference type to ApprovalResponse resource
            /// </summary>
            public static RmAttributeName ApprovalResponse = new RmAttributeName(@"ApprovalResponse");
            /// <summary>
            /// Approval Status
            /// ApprovalStatus
            /// </summary>
            public static RmAttributeName ApprovalStatus = new RmAttributeName(@"ApprovalStatus");
            /// <summary>
            /// Approval Threshold
            /// ApprovalThreshold
            /// </summary>
            public static RmAttributeName ApprovalThreshold = new RmAttributeName(@"ApprovalThreshold");
            /// <summary>
            /// Approver
            /// The set of approvers.
            /// </summary>
            public static RmAttributeName Approver = new RmAttributeName(@"Approver");
            /// <summary>
            /// Computed Actor
            /// This attribute is intended to be used to setup rights as appropriate.
            /// </summary>
            public static RmAttributeName ComputedActor = new RmAttributeName(@"ComputedActor");
            /// <summary>
            /// Endpoint Address
            /// The endpoint address on which a workflow instance is listening.
            /// </summary>
            public static RmAttributeName EndpointAddress = new RmAttributeName(@"EndpointAddress");
            /// <summary>
            /// Request
            /// The Request associated with the given Approval.
            /// </summary>
            public static RmAttributeName Request = new RmAttributeName(@"Request");
            /// <summary>
            /// Requestor
            /// This attribute is intended to be used to setup rights as appropriate.
            /// </summary>
            public static RmAttributeName Requestor = new RmAttributeName(@"Requestor");
            /// <summary>
            /// Workflow Instance
            /// WorkflowInstance
            /// </summary>
            public static RmAttributeName WorkflowInstance = new RmAttributeName(@"WorkflowInstance");
        }
        
        #endregion
        
    }
}
        
