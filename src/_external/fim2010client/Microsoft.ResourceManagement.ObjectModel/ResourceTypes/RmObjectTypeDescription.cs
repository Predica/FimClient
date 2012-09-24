using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ObjectTypeDescription resource.
    /// Automatically generated on 06/30/2010 10:07:46
    /// </summary>
    [Serializable]
    public partial class RmObjectTypeDescription : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"ObjectTypeDescription";

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
        public RmObjectTypeDescription()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmObjectTypeDescription(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Name
        /// Name
        /// </summary>
        public string Name {
            get { return GetString(AttributeNames.Name); }
            set { base[AttributeNames.Name].Value = value; }
        }

        RmList<string> _usageKeyword;
        
        /// <summary>
        /// Usage Keyword
        /// UsageKeyword
        /// </summary>
        public IList<string> UsageKeyword {
            get {
                if (_usageKeyword == null) {
                    lock (base.attributes) {
                        _usageKeyword = GetMultiValuedString(AttributeNames.UsageKeyword);
                    }
                }
                return _usageKeyword;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Name, false);
            EnsureAttributeExists(AttributeNames.UsageKeyword, true);
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
        /// Names of ObjectTypeDescription specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Name
            /// Name
            /// </summary>
            public static RmAttributeName Name = new RmAttributeName(@"Name");
            /// <summary>
            /// Usage Keyword
            /// UsageKeyword
            /// </summary>
            public static RmAttributeName UsageKeyword = new RmAttributeName(@"UsageKeyword");
        }
        
        #endregion
        
    }
}
        
