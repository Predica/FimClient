using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Configuration resource.
    /// Automatically generated on 06/30/2010 10:05:57
    /// </summary>
    [Serializable]
    public partial class RmConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"Configuration`";

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
        public RmConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Configuration Data
        /// It is a configurationData type.
        /// </summary>
        public string ConfigurationData {
            get { return GetString(AttributeNames.ConfigurationData); }
            set { base[AttributeNames.ConfigurationData].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ConfigurationData, false);
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
        /// Names of Configuration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Configuration Data
            /// It is a configurationData type.
            /// </summary>
            public static RmAttributeName ConfigurationData = new RmAttributeName(@"ConfigurationData");
        }
        
        #endregion
        
    }
}
        
