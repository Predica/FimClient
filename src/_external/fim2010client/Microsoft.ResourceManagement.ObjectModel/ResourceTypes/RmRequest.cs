using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Request resource.
    /// Automatically generated on 06/30/2010 10:07:37
    /// </summary>
    [Serializable]
    public partial class RmRequest : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"Request";

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
        public RmRequest()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmRequest(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        RmList<RmReference> _actionWorkflowInstance;
        
        /// <summary>
        /// Action Workflow Instance
        /// A reference to a workflow instance executed during the action phase of request processing.
        /// </summary>
        public IList<RmReference> ActionWorkflowInstance {
            get {
                if (_actionWorkflowInstance == null) {
                    lock (base.attributes) {
                        _actionWorkflowInstance = GetMultiValuedReference(AttributeNames.ActionWorkflowInstance);
                    }
                }
                return _actionWorkflowInstance;
            }
        }

        RmList<RmReference> _authenticationWorkflowInstance;
        
        /// <summary>
        /// Authentication Workflow Instance
        /// A reference to a workflow instance executed during the authentication phase of request processing.
        /// </summary>
        public IList<RmReference> AuthenticationWorkflowInstance {
            get {
                if (_authenticationWorkflowInstance == null) {
                    lock (base.attributes) {
                        _authenticationWorkflowInstance = GetMultiValuedReference(AttributeNames.AuthenticationWorkflowInstance);
                    }
                }
                return _authenticationWorkflowInstance;
            }
        }

        RmList<RmReference> _authorizationWorkflowInstance;
        
        /// <summary>
        /// Authorization Workflow Instance
        /// A reference to a workflow instance executed during the authorization phase of request processing.
        /// </summary>
        public IList<RmReference> AuthorizationWorkflowInstance {
            get {
                if (_authorizationWorkflowInstance == null) {
                    lock (base.attributes) {
                        _authorizationWorkflowInstance = GetMultiValuedReference(AttributeNames.AuthorizationWorkflowInstance);
                    }
                }
                return _authorizationWorkflowInstance;
            }
        }

        /// <summary>
        /// Committed Time
        /// CommittedTime
        /// </summary>
        public DateTime? CommittedTime {
            get { return GetNullable<DateTime>(AttributeNames.CommittedTime); }
            set { SetNullable (AttributeNames.CommittedTime, value); }
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
        /// Has Collateral Request
        /// This request requires action workflows to be run on alternate targets and must wait for these collateral requests to finish before it can be completed.
        /// </summary>
        public bool? HasCollateralRequest {
            get { return GetNullable<bool>(AttributeNames.HasCollateralRequest); }
            set { SetNullable (AttributeNames.HasCollateralRequest, value); }
        }

        RmList<RmReference> _managementPolicy;
        
        /// <summary>
        /// Management Policy Rule
        /// A reference to a management policy resource triggered by a request.
        /// </summary>
        public IList<RmReference> ManagementPolicy {
            get {
                if (_managementPolicy == null) {
                    lock (base.attributes) {
                        _managementPolicy = GetMultiValuedReference(AttributeNames.ManagementPolicy);
                    }
                }
                return _managementPolicy;
            }
        }

        /// <summary>
        /// Operation
        /// Operation
        /// </summary>
        public string Operation {
            get { return GetString(AttributeNames.Operation); }
            set { base[AttributeNames.Operation].Value = value; }
        }

        /// <summary>
        /// Parent Request
        /// The Request that created this Request.  If this Request was not created by a workflow, this attribute will not have a value.
        /// </summary>
        public RmReference ParentRequest {
            get { return GetReference(AttributeNames.ParentRequest); }
            set { base[AttributeNames.ParentRequest].Value = value; }
        }

        /// <summary>
        /// Request Control
        /// Used to alter normal processing of a Request.
        /// </summary>
        public string RequestControl {
            get { return GetString(AttributeNames.RequestControl); }
            set { base[AttributeNames.RequestControl].Value = value; }
        }

        RmList<string> _requestParameter;
        
        /// <summary>
        /// Request Parameters
        /// Serialized strongly typed request parameter that describes the details of an operation associated with a request.
        /// </summary>
        public IList<string> RequestParameter {
            get {
                if (_requestParameter == null) {
                    lock (base.attributes) {
                        _requestParameter = GetMultiValuedString(AttributeNames.RequestParameter);
                    }
                }
                return _requestParameter;
            }
        }

        /// <summary>
        /// Request Status
        /// This is a request status type Enum
        /// </summary>
        public string RequestStatus {
            get { return GetString(AttributeNames.RequestStatus); }
            set { base[AttributeNames.RequestStatus].Value = value; }
        }

        RmList<string> _requestStatusDetail;
        
        /// <summary>
        /// Request Status Detail
        /// Additional request information generated during the processing of this request. This may contain information messages or details of errors.
        /// </summary>
        public IList<string> RequestStatusDetail {
            get {
                if (_requestStatusDetail == null) {
                    lock (base.attributes) {
                        _requestStatusDetail = GetMultiValuedString(AttributeNames.RequestStatusDetail);
                    }
                }
                return _requestStatusDetail;
            }
        }

        /// <summary>
        /// Target
        /// Reference to the target of a request.
        /// </summary>
        public RmReference Target {
            get { return GetReference(AttributeNames.Target); }
            set { base[AttributeNames.Target].Value = value; }
        }

        /// <summary>
        /// Target Resource Type
        /// Which resource type this configuration applies to
        /// </summary>
        public string TargetObjectType {
            get { return GetString(AttributeNames.TargetObjectType); }
            set { base[AttributeNames.TargetObjectType].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ActionWorkflowInstance, true);
            EnsureAttributeExists(AttributeNames.AuthenticationWorkflowInstance, true);
            EnsureAttributeExists(AttributeNames.AuthorizationWorkflowInstance, true);
            EnsureAttributeExists(AttributeNames.CommittedTime, false);
            EnsureAttributeExists(AttributeNames.ComputedActor, true);
            EnsureAttributeExists(AttributeNames.HasCollateralRequest, false);
            EnsureAttributeExists(AttributeNames.ManagementPolicy, true);
            EnsureAttributeExists(AttributeNames.Operation, false);
            EnsureAttributeExists(AttributeNames.ParentRequest, false);
            EnsureAttributeExists(AttributeNames.RequestControl, false);
            EnsureAttributeExists(AttributeNames.RequestParameter, true);
            EnsureAttributeExists(AttributeNames.RequestStatus, false);
            EnsureAttributeExists(AttributeNames.RequestStatusDetail, true);
            EnsureAttributeExists(AttributeNames.Target, false);
            EnsureAttributeExists(AttributeNames.TargetObjectType, false);
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
        /// Names of Request specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Action Workflow Instance
            /// A reference to a workflow instance executed during the action phase of request processing.
            /// </summary>
            public static RmAttributeName ActionWorkflowInstance = new RmAttributeName(@"ActionWorkflowInstance");
            /// <summary>
            /// Authentication Workflow Instance
            /// A reference to a workflow instance executed during the authentication phase of request processing.
            /// </summary>
            public static RmAttributeName AuthenticationWorkflowInstance = new RmAttributeName(@"AuthenticationWorkflowInstance");
            /// <summary>
            /// Authorization Workflow Instance
            /// A reference to a workflow instance executed during the authorization phase of request processing.
            /// </summary>
            public static RmAttributeName AuthorizationWorkflowInstance = new RmAttributeName(@"AuthorizationWorkflowInstance");
            /// <summary>
            /// Committed Time
            /// CommittedTime
            /// </summary>
            public static RmAttributeName CommittedTime = new RmAttributeName(@"CommittedTime");
            /// <summary>
            /// Computed Actor
            /// This attribute is intended to be used to setup rights as appropriate.
            /// </summary>
            public static RmAttributeName ComputedActor = new RmAttributeName(@"ComputedActor");
            /// <summary>
            /// Has Collateral Request
            /// This request requires action workflows to be run on alternate targets and must wait for these collateral requests to finish before it can be completed.
            /// </summary>
            public static RmAttributeName HasCollateralRequest = new RmAttributeName(@"HasCollateralRequest");
            /// <summary>
            /// Management Policy Rule
            /// A reference to a management policy resource triggered by a request.
            /// </summary>
            public static RmAttributeName ManagementPolicy = new RmAttributeName(@"ManagementPolicy");
            /// <summary>
            /// Operation
            /// Operation
            /// </summary>
            public static RmAttributeName Operation = new RmAttributeName(@"Operation");
            /// <summary>
            /// Parent Request
            /// The Request that created this Request.  If this Request was not created by a workflow, this attribute will not have a value.
            /// </summary>
            public static RmAttributeName ParentRequest = new RmAttributeName(@"ParentRequest");
            /// <summary>
            /// Request Control
            /// Used to alter normal processing of a Request.
            /// </summary>
            public static RmAttributeName RequestControl = new RmAttributeName(@"RequestControl");
            /// <summary>
            /// Request Parameters
            /// Serialized strongly typed request parameter that describes the details of an operation associated with a request.
            /// </summary>
            public static RmAttributeName RequestParameter = new RmAttributeName(@"RequestParameter");
            /// <summary>
            /// Request Status
            /// This is a request status type Enum
            /// </summary>
            public static RmAttributeName RequestStatus = new RmAttributeName(@"RequestStatus");
            /// <summary>
            /// Request Status Detail
            /// Additional request information generated during the processing of this request. This may contain information messages or details of errors.
            /// </summary>
            public static RmAttributeName RequestStatusDetail = new RmAttributeName(@"RequestStatusDetail");
            /// <summary>
            /// Target
            /// Reference to the target of a request.
            /// </summary>
            public static RmAttributeName Target = new RmAttributeName(@"Target");
            /// <summary>
            /// Target Resource Type
            /// Which resource type this configuration applies to
            /// </summary>
            public static RmAttributeName TargetObjectType = new RmAttributeName(@"TargetObjectType");
        }
        
        #endregion
        
    }
}
        
