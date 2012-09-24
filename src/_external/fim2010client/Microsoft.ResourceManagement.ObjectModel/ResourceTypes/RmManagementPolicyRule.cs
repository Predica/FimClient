using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ManagementPolicyRule resource.
    /// Automatically generated on 06/30/2010 10:07:13
    /// </summary>
    [Serializable]
    public partial class RmManagementPolicyRule : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"ManagementPolicyRule`";

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
        public RmManagementPolicyRule()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmManagementPolicyRule(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        RmList<string> _actionParameter;
        
        /// <summary>
        /// Action Parameter
        /// The attribute names the policy works for (used for READ/UPDATE action)
        /// </summary>
        public IList<string> ActionParameter {
            get {
                if (_actionParameter == null) {
                    lock (base.attributes) {
                        _actionParameter = GetMultiValuedString(AttributeNames.ActionParameter);
                    }
                }
                return _actionParameter;
            }
        }

        RmList<string> _actionType;
        
        /// <summary>
        /// Action Type
        /// String representing the action associated with the management policy rule (Create, Delete, Read, Add, Remove, Modify, Transition In, Transition Out)
        /// </summary>
        public IList<string> ActionType {
            get {
                if (_actionType == null) {
                    lock (base.attributes) {
                        _actionType = GetMultiValuedString(AttributeNames.ActionType);
                    }
                }
                return _actionType;
            }
        }

        RmList<RmReference> _actionWorkflowDefinition;
        
        /// <summary>
        /// Action Workflows
        /// These workflows are applied as part of the policy. Read operations do not trigger workflows.
        /// </summary>
        public IList<RmReference> ActionWorkflowDefinition {
            get {
                if (_actionWorkflowDefinition == null) {
                    lock (base.attributes) {
                        _actionWorkflowDefinition = GetMultiValuedReference(AttributeNames.ActionWorkflowDefinition);
                    }
                }
                return _actionWorkflowDefinition;
            }
        }

        RmList<RmReference> _authenticationWorkflowDefinition;
        
        /// <summary>
        /// Authentication Workflows
        /// These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
        /// </summary>
        public IList<RmReference> AuthenticationWorkflowDefinition {
            get {
                if (_authenticationWorkflowDefinition == null) {
                    lock (base.attributes) {
                        _authenticationWorkflowDefinition = GetMultiValuedReference(AttributeNames.AuthenticationWorkflowDefinition);
                    }
                }
                return _authenticationWorkflowDefinition;
            }
        }

        RmList<RmReference> _authorizationWorkflowDefinition;
        
        /// <summary>
        /// Authorization Workflows
        /// These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
        /// </summary>
        public IList<RmReference> AuthorizationWorkflowDefinition {
            get {
                if (_authorizationWorkflowDefinition == null) {
                    lock (base.attributes) {
                        _authorizationWorkflowDefinition = GetMultiValuedReference(AttributeNames.AuthorizationWorkflowDefinition);
                    }
                }
                return _authorizationWorkflowDefinition;
            }
        }

        /// <summary>
        /// Disabled
        /// Determines if resource is disabled or enabled
        /// </summary>
        public bool? Disabled {
            get { return GetNullable<bool>(AttributeNames.Disabled); }
            set { SetNullable (AttributeNames.Disabled, value); }
        }

        /// <summary>
        /// Grant Right
        /// GrantRight
        /// </summary>
        public bool? GrantRight {
            get { return GetNullable<bool>(AttributeNames.GrantRight); }
            set { SetNullable (AttributeNames.GrantRight, value); }
        }

        /// <summary>
        /// Management Policy Rule Type
        /// Indicates the type of this policy rule.
        /// </summary>
        public string ManagementPolicyRuleType {
            get { return GetString(AttributeNames.ManagementPolicyRuleType); }
            set { base[AttributeNames.ManagementPolicyRuleType].Value = value; }
        }

        /// <summary>
        /// Principal Set
        /// Reference to the set the principal resource should belongs to.
        /// </summary>
        public RmReference PrincipalSet {
            get { return GetReference(AttributeNames.PrincipalSet); }
            set { base[AttributeNames.PrincipalSet].Value = value; }
        }

        /// <summary>
        /// Principal Set Relative To Resource
        /// PrincipalRelativeToResource
        /// </summary>
        public string PrincipalRelativeToResource {
            get { return GetString(AttributeNames.PrincipalRelativeToResource); }
            set { base[AttributeNames.PrincipalRelativeToResource].Value = value; }
        }

        /// <summary>
        /// Resource Current Set
        /// ResourceCurrentSet
        /// </summary>
        public RmReference ResourceCurrentSet {
            get { return GetReference(AttributeNames.ResourceCurrentSet); }
            set { base[AttributeNames.ResourceCurrentSet].Value = value; }
        }

        /// <summary>
        /// Resource Final Set
        /// ResourceFinalSet
        /// </summary>
        public RmReference ResourceFinalSet {
            get { return GetReference(AttributeNames.ResourceFinalSet); }
            set { base[AttributeNames.ResourceFinalSet].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ActionParameter, true);
            EnsureAttributeExists(AttributeNames.ActionType, true);
            EnsureAttributeExists(AttributeNames.ActionWorkflowDefinition, true);
            EnsureAttributeExists(AttributeNames.AuthenticationWorkflowDefinition, true);
            EnsureAttributeExists(AttributeNames.AuthorizationWorkflowDefinition, true);
            EnsureAttributeExists(AttributeNames.Disabled, false);
            EnsureAttributeExists(AttributeNames.GrantRight, false);
            EnsureAttributeExists(AttributeNames.ManagementPolicyRuleType, false);
            EnsureAttributeExists(AttributeNames.PrincipalSet, false);
            EnsureAttributeExists(AttributeNames.PrincipalRelativeToResource, false);
            EnsureAttributeExists(AttributeNames.ResourceCurrentSet, false);
            EnsureAttributeExists(AttributeNames.ResourceFinalSet, false);
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
        /// Names of ManagementPolicyRule specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Action Parameter
            /// The attribute names the policy works for (used for READ/UPDATE action)
            /// </summary>
            public static RmAttributeName ActionParameter = new RmAttributeName(@"ActionParameter");
            /// <summary>
            /// Action Type
            /// String representing the action associated with the management policy rule (Create, Delete, Read, Add, Remove, Modify, Transition In, Transition Out)
            /// </summary>
            public static RmAttributeName ActionType = new RmAttributeName(@"ActionType");
            /// <summary>
            /// Action Workflows
            /// These workflows are applied as part of the policy. Read operations do not trigger workflows.
            /// </summary>
            public static RmAttributeName ActionWorkflowDefinition = new RmAttributeName(@"ActionWorkflowDefinition");
            /// <summary>
            /// Authentication Workflows
            /// These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
            /// </summary>
            public static RmAttributeName AuthenticationWorkflowDefinition = new RmAttributeName(@"AuthenticationWorkflowDefinition");
            /// <summary>
            /// Authorization Workflows
            /// These workflows will not be applied to Requests created by the Built-in Synchronization Account or Forefront Identity Manager Workflow Activities. Read operations do not trigger workflows.
            /// </summary>
            public static RmAttributeName AuthorizationWorkflowDefinition = new RmAttributeName(@"AuthorizationWorkflowDefinition");
            /// <summary>
            /// Disabled
            /// Determines if resource is disabled or enabled
            /// </summary>
            public static RmAttributeName Disabled = new RmAttributeName(@"Disabled");
            /// <summary>
            /// Grant Right
            /// GrantRight
            /// </summary>
            public static RmAttributeName GrantRight = new RmAttributeName(@"GrantRight");
            /// <summary>
            /// Management Policy Rule Type
            /// Indicates the type of this policy rule.
            /// </summary>
            public static RmAttributeName ManagementPolicyRuleType = new RmAttributeName(@"ManagementPolicyRuleType");
            /// <summary>
            /// Principal Set
            /// Reference to the set the principal resource should belongs to.
            /// </summary>
            public static RmAttributeName PrincipalSet = new RmAttributeName(@"PrincipalSet");
            /// <summary>
            /// Principal Set Relative To Resource
            /// PrincipalRelativeToResource
            /// </summary>
            public static RmAttributeName PrincipalRelativeToResource = new RmAttributeName(@"PrincipalRelativeToResource");
            /// <summary>
            /// Resource Current Set
            /// ResourceCurrentSet
            /// </summary>
            public static RmAttributeName ResourceCurrentSet = new RmAttributeName(@"ResourceCurrentSet");
            /// <summary>
            /// Resource Final Set
            /// ResourceFinalSet
            /// </summary>
            public static RmAttributeName ResourceFinalSet = new RmAttributeName(@"ResourceFinalSet");
        }
        
        #endregion
        
    }
}
        
