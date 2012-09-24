using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ForestConfiguration resource.
    /// Automatically generated on 06/30/2010 10:06:23
    /// </summary>
    [Serializable]
    public partial class RmForestConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"ForestConfiguration`";

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
        public RmForestConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmForestConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Contact Set
        /// A reference to a set of all mail-enabled resources whose primary Active Directory resource does not reside in the Forest and therefore require a Contact in this Forest.
        /// </summary>
        public RmReference ContactSet {
            get { return GetReference(AttributeNames.ContactSet); }
            set { base[AttributeNames.ContactSet].Value = value; }
        }

        /// <summary>
        /// Distribution Group Domain
        /// Specifies the domain in which a DG will be created, for DGs created by users in that forest.
        /// </summary>
        public RmReference DistributionListDomain {
            get { return GetReference(AttributeNames.DistributionListDomain); }
            set { base[AttributeNames.DistributionListDomain].Value = value; }
        }

        /// <summary>
        /// Is Configuration Type
        /// This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType {
            get { return GetNullable<bool>(AttributeNames.IsConfigurationType); }
            set { SetNullable (AttributeNames.IsConfigurationType, value); }
        }

        RmList<RmReference> _trustedForest;
        
        /// <summary>
        /// Trusted Forest
        /// The list of Forest resources which are trusted by this Forest and for which an Incoming Trust for this Forest has been configured in Active Directory.
        /// </summary>
        public IList<RmReference> TrustedForest {
            get {
                if (_trustedForest == null) {
                    lock (base.attributes) {
                        _trustedForest = GetMultiValuedReference(AttributeNames.TrustedForest);
                    }
                }
                return _trustedForest;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ContactSet, false);
            EnsureAttributeExists(AttributeNames.DistributionListDomain, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.TrustedForest, true);
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
        /// Names of ForestConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Contact Set
            /// A reference to a set of all mail-enabled resources whose primary Active Directory resource does not reside in the Forest and therefore require a Contact in this Forest.
            /// </summary>
            public static RmAttributeName ContactSet = new RmAttributeName(@"ContactSet");
            /// <summary>
            /// Distribution Group Domain
            /// Specifies the domain in which a DG will be created, for DGs created by users in that forest.
            /// </summary>
            public static RmAttributeName DistributionListDomain = new RmAttributeName(@"DistributionListDomain");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// Trusted Forest
            /// The list of Forest resources which are trusted by this Forest and for which an Incoming Trust for this Forest has been configured in Active Directory.
            /// </summary>
            public static RmAttributeName TrustedForest = new RmAttributeName(@"TrustedForest");
        }
        
        #endregion
        
    }
}
        
