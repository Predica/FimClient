using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ConstantSpecifier resource.
    /// Automatically generated on 06/30/2010 10:06:00
    /// </summary>
    [Serializable]
    public partial class RmConstantSpecifier : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"ConstantSpecifier`";

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
        public RmConstantSpecifier()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmConstantSpecifier(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Attribute Type
        /// The binding's attribute type
        /// </summary>
        public RmReference BoundAttributeType {
            get { return GetReference(AttributeNames.BoundAttributeType); }
            set { base[AttributeNames.BoundAttributeType].Value = value; }
        }

        /// <summary>
        /// Constant Value Key
        /// It is a the constant key value.
        /// </summary>
        public string ConstantValueKey {
            get { return GetString(AttributeNames.ConstantValueKey); }
            set { base[AttributeNames.ConstantValueKey].Value = value; }
        }

        /// <summary>
        /// Resource Type
        /// The binding's resource type
        /// </summary>
        public RmReference BoundObjectType {
            get { return GetReference(AttributeNames.BoundObjectType); }
            set { base[AttributeNames.BoundObjectType].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.BoundAttributeType, false);
            EnsureAttributeExists(AttributeNames.ConstantValueKey, false);
            EnsureAttributeExists(AttributeNames.BoundObjectType, false);
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
        /// Names of ConstantSpecifier specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Attribute Type
            /// The binding's attribute type
            /// </summary>
            public static RmAttributeName BoundAttributeType = new RmAttributeName(@"BoundAttributeType");
            /// <summary>
            /// Constant Value Key
            /// It is a the constant key value.
            /// </summary>
            public static RmAttributeName ConstantValueKey = new RmAttributeName(@"ConstantValueKey");
            /// <summary>
            /// Resource Type
            /// The binding's resource type
            /// </summary>
            public static RmAttributeName BoundObjectType = new RmAttributeName(@"BoundObjectType");
        }
        
        #endregion
        
    }
}
        
