using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// SupportedLocaleConfiguration resource.
    /// Automatically generated on 06/30/2010 10:07:58
    /// </summary>
    [Serializable]
    public partial class RmSupportedLocaleConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"SupportedLocaleConfiguration`";

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
        public RmSupportedLocaleConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSupportedLocaleConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Is Configuration Type
        /// This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType {
            get { return GetNullable<bool>(AttributeNames.IsConfigurationType); }
            set { SetNullable (AttributeNames.IsConfigurationType, value); }
        }

        RmList<string> _supportedLanguageCode;
        
        /// <summary>
        /// Supported Language Code
        /// This attribute lists language codes for all supported locales in FIM Portal.
        /// </summary>
        public IList<string> SupportedLanguageCode {
            get {
                if (_supportedLanguageCode == null) {
                    lock (base.attributes) {
                        _supportedLanguageCode = GetMultiValuedString(AttributeNames.SupportedLanguageCode);
                    }
                }
                return _supportedLanguageCode;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.SupportedLanguageCode, true);
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
        /// Names of SupportedLocaleConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// Supported Language Code
            /// This attribute lists language codes for all supported locales in FIM Portal.
            /// </summary>
            public static RmAttributeName SupportedLanguageCode = new RmAttributeName(@"SupportedLanguageCode");
        }
        
        #endregion
        
    }
}
        
