using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// FilterScope resource.
    /// Automatically generated on 06/30/2010 10:06:19
    /// </summary>
    [Serializable]
    public partial class RmFilterScope : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"FilterScope`";

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
        public RmFilterScope()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmFilterScope(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        RmList<RmReference> _allowedAttributes;
        
        /// <summary>
        /// Allowed Attributes
        /// Select the attributes permitted in the filter definition.
        /// </summary>
        public IList<RmReference> AllowedAttributes {
            get {
                if (_allowedAttributes == null) {
                    lock (base.attributes) {
                        _allowedAttributes = GetMultiValuedReference(AttributeNames.AllowedAttributes);
                    }
                }
                return _allowedAttributes;
            }
        }

        RmList<RmReference> _allowedMembershipReferences;
        
        /// <summary>
        /// Allowed Membership References
        /// Select a collection of groups or sets for which a filter may reference the members.
        /// </summary>
        public IList<RmReference> AllowedMembershipReferences {
            get {
                if (_allowedMembershipReferences == null) {
                    lock (base.attributes) {
                        _allowedMembershipReferences = GetMultiValuedReference(AttributeNames.AllowedMembershipReferences);
                    }
                }
                return _allowedMembershipReferences;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.AllowedAttributes, true);
            EnsureAttributeExists(AttributeNames.AllowedMembershipReferences, true);
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
        /// Names of FilterScope specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Allowed Attributes
            /// Select the attributes permitted in the filter definition.
            /// </summary>
            public static RmAttributeName AllowedAttributes = new RmAttributeName(@"AllowedAttributes");
            /// <summary>
            /// Allowed Membership References
            /// Select a collection of groups or sets for which a filter may reference the members.
            /// </summary>
            public static RmAttributeName AllowedMembershipReferences = new RmAttributeName(@"AllowedMembershipReferences");
        }
        
        #endregion
        
    }
}
        
