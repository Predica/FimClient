using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// DomainConfiguration resource.
    /// Automatically generated on 06/30/2010 10:06:07
    /// </summary>
    [Serializable]
    public partial class RmDomainConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"DomainConfiguration";

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
        public RmDomainConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmDomainConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Domain
        /// Choose the domain where you want to create the user account for this user
        /// </summary>
        public string Domain {
            get { return GetString(AttributeNames.Domain); }
            set { base[AttributeNames.Domain].Value = value; }
        }

        /// <summary>
        /// Foreign Security Principal Set
        /// A reference to a set of all security resources whose primary Active Directory resource does not reside in the Forest and therefore require a Foreign Security Principal in this Forest.
        /// </summary>
        public RmReference ForeignSecurityPrincipalSet {
            get { return GetReference(AttributeNames.ForeignSecurityPrincipalSet); }
            set { base[AttributeNames.ForeignSecurityPrincipalSet].Value = value; }
        }

        /// <summary>
        /// Forest Configuration
        /// A reference to a the parent Forest resource for this Domain.
        /// </summary>
        public RmReference ForestConfiguration {
            get { return GetReference(AttributeNames.ForestConfiguration); }
            set { base[AttributeNames.ForestConfiguration].Value = value; }
        }

        /// <summary>
        /// Is Configuration Type
        /// This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType {
            get { return GetNullable<bool>(AttributeNames.IsConfigurationType); }
            set { SetNullable (AttributeNames.IsConfigurationType, value); }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.Domain, false);
            EnsureAttributeExists(AttributeNames.ForeignSecurityPrincipalSet, false);
            EnsureAttributeExists(AttributeNames.ForestConfiguration, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
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
        /// Names of DomainConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Domain
            /// Choose the domain where you want to create the user account for this user
            /// </summary>
            public static RmAttributeName Domain = new RmAttributeName(@"Domain");
            /// <summary>
            /// Foreign Security Principal Set
            /// A reference to a set of all security resources whose primary Active Directory resource does not reside in the Forest and therefore require a Foreign Security Principal in this Forest.
            /// </summary>
            public static RmAttributeName ForeignSecurityPrincipalSet = new RmAttributeName(@"ForeignSecurityPrincipalSet");
            /// <summary>
            /// Forest Configuration
            /// A reference to a the parent Forest resource for this Domain.
            /// </summary>
            public static RmAttributeName ForestConfiguration = new RmAttributeName(@"ForestConfiguration");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
        }
        
        #endregion
        
    }
}
        
