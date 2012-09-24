using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// WorkflowInstance resource.
    /// Automatically generated on 06/30/2010 10:08:29
    /// </summary>
    [Serializable]
    public partial class RmWorkflowInstance : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"WorkflowInstance`";

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
        public RmWorkflowInstance()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmWorkflowInstance(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


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
        /// Target
        /// Reference to the target of a request.
        /// </summary>
        public RmReference Target {
            get { return GetReference(AttributeNames.Target); }
            set { base[AttributeNames.Target].Value = value; }
        }

        /// <summary>
        /// Workflow Definition
        /// WorkflowDefinition
        /// </summary>
        public RmReference WorkflowDefinition {
            get { return GetReference(AttributeNames.WorkflowDefinition); }
            set { base[AttributeNames.WorkflowDefinition].Value = value; }
        }

        /// <summary>
        /// Workflow Status
        /// Enumeration representing the current status of a workflow instance.
        /// </summary>
        public string WorkflowStatus {
            get { return GetString(AttributeNames.WorkflowStatus); }
            set { base[AttributeNames.WorkflowStatus].Value = value; }
        }

        RmList<string> _workflowStatusDetail;
        
        /// <summary>
        /// Workflow Status Detail
        /// This attribute is used to track workflow instance exceptions to assist with troubleshooting and auditing workflow execution.
        /// </summary>
        public IList<string> WorkflowStatusDetail {
            get {
                if (_workflowStatusDetail == null) {
                    lock (base.attributes) {
                        _workflowStatusDetail = GetMultiValuedString(AttributeNames.WorkflowStatusDetail);
                    }
                }
                return _workflowStatusDetail;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Request, false);
            EnsureAttributeExists(AttributeNames.Requestor, false);
            EnsureAttributeExists(AttributeNames.Target, false);
            EnsureAttributeExists(AttributeNames.WorkflowDefinition, false);
            EnsureAttributeExists(AttributeNames.WorkflowStatus, false);
            EnsureAttributeExists(AttributeNames.WorkflowStatusDetail, true);
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
        /// Names of WorkflowInstance specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
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
            /// Target
            /// Reference to the target of a request.
            /// </summary>
            public static RmAttributeName Target = new RmAttributeName(@"Target");
            /// <summary>
            /// Workflow Definition
            /// WorkflowDefinition
            /// </summary>
            public static RmAttributeName WorkflowDefinition = new RmAttributeName(@"WorkflowDefinition");
            /// <summary>
            /// Workflow Status
            /// Enumeration representing the current status of a workflow instance.
            /// </summary>
            public static RmAttributeName WorkflowStatus = new RmAttributeName(@"WorkflowStatus");
            /// <summary>
            /// Workflow Status Detail
            /// This attribute is used to track workflow instance exceptions to assist with troubleshooting and auditing workflow execution.
            /// </summary>
            public static RmAttributeName WorkflowStatusDetail = new RmAttributeName(@"WorkflowStatusDetail");
        }
        
        #endregion
        
    }
}
        
