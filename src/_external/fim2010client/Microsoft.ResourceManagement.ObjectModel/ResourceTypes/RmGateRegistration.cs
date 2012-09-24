using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// GateRegistration resource.
    /// Automatically generated on 06/30/2010 10:06:32
    /// </summary>
    [Serializable]
    public partial class RmGateRegistration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"GateRegistration`";

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
        public RmGateRegistration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmGateRegistration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Gate Data
        /// GateData
        /// </summary>
        public int? GateData {
            get { return GetNullable<int>(AttributeNames.GateData); }
            set { SetNullable (AttributeNames.GateData, value); }
        }

        /// <summary>
        /// Gate ID
        /// GateID
        /// </summary>
        public string GateID {
            get { return GetString(AttributeNames.GateID); }
            set { base[AttributeNames.GateID].Value = value; }
        }

        /// <summary>
        /// Gate Type
        /// GateTypeId
        /// </summary>
        public string GateTypeId {
            get { return GetString(AttributeNames.GateTypeId); }
            set { base[AttributeNames.GateTypeId].Value = value; }
        }

        /// <summary>
        /// User ID
        /// UserID
        /// </summary>
        public RmReference UserID {
            get { return GetReference(AttributeNames.UserID); }
            set { base[AttributeNames.UserID].Value = value; }
        }

        /// <summary>
        /// Workflow Definition
        /// WorkflowDefinition
        /// </summary>
        public RmReference WorkflowDefinition {
            get { return GetReference(AttributeNames.WorkflowDefinition); }
            set { base[AttributeNames.WorkflowDefinition].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.GateData, false);
            EnsureAttributeExists(AttributeNames.GateID, false);
            EnsureAttributeExists(AttributeNames.GateTypeId, false);
            EnsureAttributeExists(AttributeNames.UserID, false);
            EnsureAttributeExists(AttributeNames.WorkflowDefinition, false);
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
        /// Names of GateRegistration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Gate Data
            /// GateData
            /// </summary>
            public static RmAttributeName GateData = new RmAttributeName(@"GateData");
            /// <summary>
            /// Gate ID
            /// GateID
            /// </summary>
            public static RmAttributeName GateID = new RmAttributeName(@"GateID");
            /// <summary>
            /// Gate Type
            /// GateTypeId
            /// </summary>
            public static RmAttributeName GateTypeId = new RmAttributeName(@"GateTypeId");
            /// <summary>
            /// User ID
            /// UserID
            /// </summary>
            public static RmAttributeName UserID = new RmAttributeName(@"UserID");
            /// <summary>
            /// Workflow Definition
            /// WorkflowDefinition
            /// </summary>
            public static RmAttributeName WorkflowDefinition = new RmAttributeName(@"WorkflowDefinition");
        }
        
        #endregion
        
    }
}
        
