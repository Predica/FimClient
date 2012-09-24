using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ObjectVisualizationConfiguration resource.
    /// Automatically generated on 06/30/2010 10:07:44
    /// </summary>
    [Serializable]
    public partial class RmObjectVisualizationConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"ObjectVisualizationConfiguration`";

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
        public RmObjectVisualizationConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmObjectVisualizationConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Applies to Create
        /// The configuration applies to create mode of the target resource type
        /// </summary>
        public bool? AppliesToCreate {
            get { return GetNullable<bool>(AttributeNames.AppliesToCreate); }
            set { SetNullable (AttributeNames.AppliesToCreate, value); }
        }

        /// <summary>
        /// Applies to Edit
        /// The configuration applies to edit mode of the target resource type
        /// </summary>
        public bool? AppliesToEdit {
            get { return GetNullable<bool>(AttributeNames.AppliesToEdit); }
            set { SetNullable (AttributeNames.AppliesToEdit, value); }
        }

        /// <summary>
        /// Applies to View
        /// The configuration applies to view mode of the target resource type
        /// </summary>
        public bool? AppliesToView {
            get { return GetNullable<bool>(AttributeNames.AppliesToView); }
            set { SetNullable (AttributeNames.AppliesToView, value); }
        }

        /// <summary>
        /// Configuration Data
        /// It is a configurationData type.
        /// </summary>
        public string ConfigurationData {
            get { return GetString(AttributeNames.ConfigurationData); }
            set { base[AttributeNames.ConfigurationData].Value = value; }
        }

        /// <summary>
        /// Is Configuration Type
        /// This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType {
            get { return GetNullable<bool>(AttributeNames.IsConfigurationType); }
            set { SetNullable (AttributeNames.IsConfigurationType, value); }
        }

        /// <summary>
        /// String Resources
        /// This attribute contains the localized value of the string resources for the selected language.
        /// </summary>
        public string StringResources {
            get { return GetString(AttributeNames.StringResources); }
            set { base[AttributeNames.StringResources].Value = value; }
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
            EnsureAttributeExists(AttributeNames.AppliesToCreate, false);
            EnsureAttributeExists(AttributeNames.AppliesToEdit, false);
            EnsureAttributeExists(AttributeNames.AppliesToView, false);
            EnsureAttributeExists(AttributeNames.ConfigurationData, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.StringResources, false);
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
        /// Names of ObjectVisualizationConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Applies to Create
            /// The configuration applies to create mode of the target resource type
            /// </summary>
            public static RmAttributeName AppliesToCreate = new RmAttributeName(@"AppliesToCreate");
            /// <summary>
            /// Applies to Edit
            /// The configuration applies to edit mode of the target resource type
            /// </summary>
            public static RmAttributeName AppliesToEdit = new RmAttributeName(@"AppliesToEdit");
            /// <summary>
            /// Applies to View
            /// The configuration applies to view mode of the target resource type
            /// </summary>
            public static RmAttributeName AppliesToView = new RmAttributeName(@"AppliesToView");
            /// <summary>
            /// Configuration Data
            /// It is a configurationData type.
            /// </summary>
            public static RmAttributeName ConfigurationData = new RmAttributeName(@"ConfigurationData");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// String Resources
            /// This attribute contains the localized value of the string resources for the selected language.
            /// </summary>
            public static RmAttributeName StringResources = new RmAttributeName(@"StringResources");
            /// <summary>
            /// Target Resource Type
            /// Which resource type this configuration applies to
            /// </summary>
            public static RmAttributeName TargetObjectType = new RmAttributeName(@"TargetObjectType");
        }
        
        #endregion
        
    }
}
        
