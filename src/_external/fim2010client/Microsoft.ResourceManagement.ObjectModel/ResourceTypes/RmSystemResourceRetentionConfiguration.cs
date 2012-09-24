using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// SystemResourceRetentionConfiguration resource.
    /// Automatically generated on 06/30/2010 10:08:14
    /// </summary>
    [Serializable]
    public partial class RmSystemResourceRetentionConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"SystemResourceRetentionConfiguration`";

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
        public RmSystemResourceRetentionConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSystemResourceRetentionConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Retention Period in Days
        /// The number of days after completion a Request, Approval, Approval Response or Workflow Instance is retained before being deleted.
        /// </summary>
        public int? RetentionPeriod {
            get { return GetNullable<int>(AttributeNames.RetentionPeriod); }
            set { SetNullable (AttributeNames.RetentionPeriod, value); }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.RetentionPeriod, false);
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
        /// Names of SystemResourceRetentionConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Retention Period in Days
            /// The number of days after completion a Request, Approval, Approval Response or Workflow Instance is retained before being deleted.
            /// </summary>
            public static RmAttributeName RetentionPeriod = new RmAttributeName(@"RetentionPeriod");
        }
        
        #endregion
        
    }
}
        
