using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// WorkflowDefinition resource.
    /// Automatically generated on 06/30/2010 10:08:25
    /// </summary>
    [Serializable]
    public partial class RmWorkflowDefinition : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"WorkflowDefinition`";

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
        public RmWorkflowDefinition()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmWorkflowDefinition(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Clear Registration
        /// Modifying this attribute will clear the associated user registration data of this workflow
        /// </summary>
        public bool? ClearRegistration {
            get { return GetNullable<bool>(AttributeNames.ClearRegistration); }
            set { SetNullable (AttributeNames.ClearRegistration, value); }
        }

        /// <summary>
        /// Request Phase
        /// RequestPhase
        /// </summary>
        public string RequestPhase {
            get { return GetString(AttributeNames.RequestPhase); }
            set { base[AttributeNames.RequestPhase].Value = value; }
        }

        /// <summary>
        /// Rules
        /// Rules file for the workflow.
        /// </summary>
        public string Rules {
            get { return GetString(AttributeNames.Rules); }
            set { base[AttributeNames.Rules].Value = value; }
        }

        /// <summary>
        /// Run On Policy Update
        /// Specifies if the workflow should be applied to existing members of a Transition Set in the Set Transition Policy referencing this workflow when the policy is created, enabled or when selected changes are made to the policy.
        /// </summary>
        public bool? RunOnPolicyUpdate {
            get { return GetNullable<bool>(AttributeNames.RunOnPolicyUpdate); }
            set { SetNullable (AttributeNames.RunOnPolicyUpdate, value); }
        }

        /// <summary>
        /// XOML
        /// XOML
        /// </summary>
        public string XOML {
            get { return GetString(AttributeNames.XOML); }
            set { base[AttributeNames.XOML].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ClearRegistration, false);
            EnsureAttributeExists(AttributeNames.RequestPhase, false);
            EnsureAttributeExists(AttributeNames.Rules, false);
            EnsureAttributeExists(AttributeNames.RunOnPolicyUpdate, false);
            EnsureAttributeExists(AttributeNames.XOML, false);
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
        /// Names of WorkflowDefinition specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Clear Registration
            /// Modifying this attribute will clear the associated user registration data of this workflow
            /// </summary>
            public static RmAttributeName ClearRegistration = new RmAttributeName(@"ClearRegistration");
            /// <summary>
            /// Request Phase
            /// RequestPhase
            /// </summary>
            public static RmAttributeName RequestPhase = new RmAttributeName(@"RequestPhase");
            /// <summary>
            /// Rules
            /// Rules file for the workflow.
            /// </summary>
            public static RmAttributeName Rules = new RmAttributeName(@"Rules");
            /// <summary>
            /// Run On Policy Update
            /// Specifies if the workflow should be applied to existing members of a Transition Set in the Set Transition Policy referencing this workflow when the policy is created, enabled or when selected changes are made to the policy.
            /// </summary>
            public static RmAttributeName RunOnPolicyUpdate = new RmAttributeName(@"RunOnPolicyUpdate");
            /// <summary>
            /// XOML
            /// XOML
            /// </summary>
            public static RmAttributeName XOML = new RmAttributeName(@"XOML");
        }
        
        #endregion
        
    }
}
        
