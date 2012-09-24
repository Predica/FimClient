using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// PortalUIConfiguration resource.
    /// Automatically generated on 06/30/2010 10:07:28
    /// </summary>
    [Serializable]
    public partial class RmPortalUIConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"PortalUIConfiguration`";

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
        public RmPortalUIConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmPortalUIConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Branding Center Text
        /// The centered branding text that used by branding control
        /// </summary>
        public string BrandingCenterText {
            get { return GetString(AttributeNames.BrandingCenterText); }
            set { base[AttributeNames.BrandingCenterText].Value = value; }
        }

        /// <summary>
        /// Branding Left Image
        /// The left url image that is used by branding control
        /// </summary>
        public string BrandingLeftImage {
            get { return GetString(AttributeNames.BrandingLeftImage); }
            set { base[AttributeNames.BrandingLeftImage].Value = value; }
        }

        /// <summary>
        /// Branding Right Image
        /// The right url image that used by branding control
        /// </summary>
        public string BrandingRightImage {
            get { return GetString(AttributeNames.BrandingRightImage); }
            set { base[AttributeNames.BrandingRightImage].Value = value; }
        }

        /// <summary>
        /// Global Cache Duration
        /// This time how long the UI configuration element will be kept on the cache
        /// </summary>
        public int? UICacheTime {
            get { return GetNullable<int>(AttributeNames.UICacheTime); }
            set { SetNullable (AttributeNames.UICacheTime, value); }
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
        /// ListView Cache Time Out
        /// Specify the amount of time for the ListView cache to time out and expire.
        /// </summary>
        public int? ListViewCacheTimeOut {
            get { return GetNullable<int>(AttributeNames.ListViewCacheTimeOut); }
            set { SetNullable (AttributeNames.ListViewCacheTimeOut, value); }
        }

        /// <summary>
        /// ListView Items per Page
        /// Specify the number of items to show per page in all ListViews.
        /// </summary>
        public int? ListViewPageSize {
            get { return GetNullable<int>(AttributeNames.ListViewPageSize); }
            set { SetNullable (AttributeNames.ListViewPageSize, value); }
        }

        /// <summary>
        /// ListView Pages to Cache
        /// Specify the number of pages to cache while retrieving ListView results.
        /// </summary>
        public int? ListViewPagesToCache {
            get { return GetNullable<int>(AttributeNames.ListViewPagesToCache); }
            set { SetNullable (AttributeNames.ListViewPagesToCache, value); }
        }

        /// <summary>
        /// Navigation Bar Resource Count Cache Duration
        /// This time how long the UI dynamic counts will stay on the cache before it expired
        /// </summary>
        public int? UICountCacheTime {
            get { return GetNullable<int>(AttributeNames.UICountCacheTime); }
            set { SetNullable (AttributeNames.UICountCacheTime, value); }
        }

        /// <summary>
        /// Per User Cache Duration
        /// This time for how long the UI user data will stay on the cache before it expired
        /// </summary>
        public int? UIUserCacheTime {
            get { return GetNullable<int>(AttributeNames.UIUserCacheTime); }
            set { SetNullable (AttributeNames.UIUserCacheTime, value); }
        }

        /// <summary>
        /// Time Zone
        /// Reference to timezone configuration
        /// </summary>
        public RmReference TimeZone {
            get { return GetReference(AttributeNames.TimeZone); }
            set { base[AttributeNames.TimeZone].Value = value; }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.BrandingCenterText, false);
            EnsureAttributeExists(AttributeNames.BrandingLeftImage, false);
            EnsureAttributeExists(AttributeNames.BrandingRightImage, false);
            EnsureAttributeExists(AttributeNames.UICacheTime, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.ListViewCacheTimeOut, false);
            EnsureAttributeExists(AttributeNames.ListViewPageSize, false);
            EnsureAttributeExists(AttributeNames.ListViewPagesToCache, false);
            EnsureAttributeExists(AttributeNames.UICountCacheTime, false);
            EnsureAttributeExists(AttributeNames.UIUserCacheTime, false);
            EnsureAttributeExists(AttributeNames.TimeZone, false);
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
        /// Names of PortalUIConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Branding Center Text
            /// The centered branding text that used by branding control
            /// </summary>
            public static RmAttributeName BrandingCenterText = new RmAttributeName(@"BrandingCenterText");
            /// <summary>
            /// Branding Left Image
            /// The left url image that is used by branding control
            /// </summary>
            public static RmAttributeName BrandingLeftImage = new RmAttributeName(@"BrandingLeftImage");
            /// <summary>
            /// Branding Right Image
            /// The right url image that used by branding control
            /// </summary>
            public static RmAttributeName BrandingRightImage = new RmAttributeName(@"BrandingRightImage");
            /// <summary>
            /// Global Cache Duration
            /// This time how long the UI configuration element will be kept on the cache
            /// </summary>
            public static RmAttributeName UICacheTime = new RmAttributeName(@"UICacheTime");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// ListView Cache Time Out
            /// Specify the amount of time for the ListView cache to time out and expire.
            /// </summary>
            public static RmAttributeName ListViewCacheTimeOut = new RmAttributeName(@"ListViewCacheTimeOut");
            /// <summary>
            /// ListView Items per Page
            /// Specify the number of items to show per page in all ListViews.
            /// </summary>
            public static RmAttributeName ListViewPageSize = new RmAttributeName(@"ListViewPageSize");
            /// <summary>
            /// ListView Pages to Cache
            /// Specify the number of pages to cache while retrieving ListView results.
            /// </summary>
            public static RmAttributeName ListViewPagesToCache = new RmAttributeName(@"ListViewPagesToCache");
            /// <summary>
            /// Navigation Bar Resource Count Cache Duration
            /// This time how long the UI dynamic counts will stay on the cache before it expired
            /// </summary>
            public static RmAttributeName UICountCacheTime = new RmAttributeName(@"UICountCacheTime");
            /// <summary>
            /// Per User Cache Duration
            /// This time for how long the UI user data will stay on the cache before it expired
            /// </summary>
            public static RmAttributeName UIUserCacheTime = new RmAttributeName(@"UIUserCacheTime");
            /// <summary>
            /// Time Zone
            /// Reference to timezone configuration
            /// </summary>
            public static RmAttributeName TimeZone = new RmAttributeName(@"TimeZone");
        }
        
        #endregion
        
    }
}
        
