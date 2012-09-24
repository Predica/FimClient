using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// HomepageConfiguration resource.
    /// Automatically generated on 06/30/2010 10:06:46
    /// </summary>
    [Serializable]
    public partial class RmHomepageConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"HomepageConfiguration`";

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
        public RmHomepageConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmHomepageConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Image Url
        /// Image url for the a given element.
        /// </summary>
        public string ImageUrl {
            get { return GetString(AttributeNames.ImageUrl); }
            set { base[AttributeNames.ImageUrl].Value = value; }
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
        /// Navigation Url
        /// URL for navigation when user clicks this item.
        /// </summary>
        public string NavigationUrl {
            get { return GetString(AttributeNames.NavigationUrl); }
            set { base[AttributeNames.NavigationUrl].Value = value; }
        }

        /// <summary>
        /// Order
        /// Precedence of this item within a parent grouping
        /// </summary>
        public int? Order {
            get { return GetNullable<int>(AttributeNames.Order); }
            set { SetNullable (AttributeNames.Order, value); }
        }

        /// <summary>
        /// Parent Order
        /// Parent order attribute is used to group child elments with that number
        /// </summary>
        public int? ParentOrder {
            get { return GetNullable<int>(AttributeNames.ParentOrder); }
            set { SetNullable (AttributeNames.ParentOrder, value); }
        }

        /// <summary>
        /// Region
        /// Specifies where the item will be shown in the UI.
        /// </summary>
        public int? Region {
            get { return GetNullable<int>(AttributeNames.Region); }
            set { SetNullable (AttributeNames.Region, value); }
        }

        /// <summary>
        /// Resource Count
        /// Count resources associated with this item (optional)
        /// </summary>
        public string CountXPath {
            get { return GetString(AttributeNames.CountXPath); }
            set { base[AttributeNames.CountXPath].Value = value; }
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
            EnsureAttributeExists(AttributeNames.ImageUrl, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.NavigationUrl, false);
            EnsureAttributeExists(AttributeNames.Order, false);
            EnsureAttributeExists(AttributeNames.ParentOrder, false);
            EnsureAttributeExists(AttributeNames.Region, false);
            EnsureAttributeExists(AttributeNames.CountXPath, false);
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
        /// Names of HomepageConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Image Url
            /// Image url for the a given element.
            /// </summary>
            public static RmAttributeName ImageUrl = new RmAttributeName(@"ImageUrl");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// Navigation Url
            /// URL for navigation when user clicks this item.
            /// </summary>
            public static RmAttributeName NavigationUrl = new RmAttributeName(@"NavigationUrl");
            /// <summary>
            /// Order
            /// Precedence of this item within a parent grouping
            /// </summary>
            public static RmAttributeName Order = new RmAttributeName(@"Order");
            /// <summary>
            /// Parent Order
            /// Parent order attribute is used to group child elments with that number
            /// </summary>
            public static RmAttributeName ParentOrder = new RmAttributeName(@"ParentOrder");
            /// <summary>
            /// Region
            /// Specifies where the item will be shown in the UI.
            /// </summary>
            public static RmAttributeName Region = new RmAttributeName(@"Region");
            /// <summary>
            /// Resource Count
            /// Count resources associated with this item (optional)
            /// </summary>
            public static RmAttributeName CountXPath = new RmAttributeName(@"CountXPath");
            /// <summary>
            /// Usage Keyword
            /// UsageKeyword
            /// </summary>
            public static RmAttributeName UsageKeyword = new RmAttributeName(@"UsageKeyword");
        }
        
        #endregion
        
    }
}
        
