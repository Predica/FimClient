using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// SynchronizationFilter resource.
    /// Automatically generated on 06/30/2010 10:08:01
    /// </summary>
    [Serializable]
    public partial class RmSynchronizationFilter : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"SynchronizationFilter`";

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
        public RmSynchronizationFilter()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSynchronizationFilter(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        RmList<RmReference> _synchronizeObjectType;
        
        /// <summary>
        /// Synchronize ObjectTypeDescription
        /// The list of resource types that are allowed to be synced.
        /// </summary>
        public IList<RmReference> SynchronizeObjectType {
            get {
                if (_synchronizeObjectType == null) {
                    lock (base.attributes) {
                        _synchronizeObjectType = GetMultiValuedReference(AttributeNames.SynchronizeObjectType);
                    }
                }
                return _synchronizeObjectType;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.SynchronizeObjectType, true);
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
        /// Names of SynchronizationFilter specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Synchronize ObjectTypeDescription
            /// The list of resource types that are allowed to be synced.
            /// </summary>
            public static RmAttributeName SynchronizeObjectType = new RmAttributeName(@"SynchronizeObjectType");
        }
        
        #endregion
        
    }
}
        
