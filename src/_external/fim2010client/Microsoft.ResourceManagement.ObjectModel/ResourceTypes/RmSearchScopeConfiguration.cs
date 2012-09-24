using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// SearchScopeConfiguration resource.
    /// Automatically generated on 06/30/2010 10:07:52
    /// </summary>
    [Serializable]
    public partial class RmSearchScopeConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"SearchScopeConfiguration`";

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
        public RmSearchScopeConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSearchScopeConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Attribute
        /// System name (case sensitive) of the type of attribute to be shown in search results.
        /// </summary>
        public string SearchScopeColumn {
            get { return GetString(AttributeNames.SearchScopeColumn); }
            set { base[AttributeNames.SearchScopeColumn].Value = value; }
        }

        RmList<string> _searchScopeContext;
        
        /// <summary>
        /// Attribute Searched
        /// System name (case sensitive) of the attributes that will be used to match against the search string supplied by the user.
        /// </summary>
        public IList<string> SearchScopeContext {
            get {
                if (_searchScopeContext == null) {
                    lock (base.attributes) {
                        _searchScopeContext = GetMultiValuedString(AttributeNames.SearchScopeContext);
                    }
                }
                return _searchScopeContext;
            }
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
        /// Navigation Page
        /// NavigationPage
        /// </summary>
        public string NavigationPage {
            get { return GetString(AttributeNames.NavigationPage); }
            set { base[AttributeNames.NavigationPage].Value = value; }
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
        /// Redirecting URL
        /// Relative path for the page where search results are to be show for searches from the home page.
        /// </summary>
        public string SearchScopeTargetURL {
            get { return GetString(AttributeNames.SearchScopeTargetURL); }
            set { base[AttributeNames.SearchScopeTargetURL].Value = value; }
        }

        /// <summary>
        /// Resource Type
        /// System name of the type of resource that the search scope returns.
        /// </summary>
        public string SearchScopeResultObjectType {
            get { return GetString(AttributeNames.SearchScopeResultObjectType); }
            set { base[AttributeNames.SearchScopeResultObjectType].Value = value; }
        }

        /// <summary>
        /// Search Scope Filter
        /// XPath expression of which resources are to be returned by the search scope.
        /// </summary>
        public string SearchScope {
            get { return GetString(AttributeNames.SearchScope); }
            set { base[AttributeNames.SearchScope].Value = value; }
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
            EnsureAttributeExists(AttributeNames.SearchScopeColumn, false);
            EnsureAttributeExists(AttributeNames.SearchScopeContext, true);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.NavigationPage, false);
            EnsureAttributeExists(AttributeNames.Order, false);
            EnsureAttributeExists(AttributeNames.SearchScopeTargetURL, false);
            EnsureAttributeExists(AttributeNames.SearchScopeResultObjectType, false);
            EnsureAttributeExists(AttributeNames.SearchScope, false);
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
        /// Names of SearchScopeConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Attribute
            /// System name (case sensitive) of the type of attribute to be shown in search results.
            /// </summary>
            public static RmAttributeName SearchScopeColumn = new RmAttributeName(@"SearchScopeColumn");
            /// <summary>
            /// Attribute Searched
            /// System name (case sensitive) of the attributes that will be used to match against the search string supplied by the user.
            /// </summary>
            public static RmAttributeName SearchScopeContext = new RmAttributeName(@"SearchScopeContext");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// Navigation Page
            /// NavigationPage
            /// </summary>
            public static RmAttributeName NavigationPage = new RmAttributeName(@"NavigationPage");
            /// <summary>
            /// Order
            /// Precedence of this item within a parent grouping
            /// </summary>
            public static RmAttributeName Order = new RmAttributeName(@"Order");
            /// <summary>
            /// Redirecting URL
            /// Relative path for the page where search results are to be show for searches from the home page.
            /// </summary>
            public static RmAttributeName SearchScopeTargetURL = new RmAttributeName(@"SearchScopeTargetURL");
            /// <summary>
            /// Resource Type
            /// System name of the type of resource that the search scope returns.
            /// </summary>
            public static RmAttributeName SearchScopeResultObjectType = new RmAttributeName(@"SearchScopeResultObjectType");
            /// <summary>
            /// Search Scope Filter
            /// XPath expression of which resources are to be returned by the search scope.
            /// </summary>
            public static RmAttributeName SearchScope = new RmAttributeName(@"SearchScope");
            /// <summary>
            /// Usage Keyword
            /// UsageKeyword
            /// </summary>
            public static RmAttributeName UsageKeyword = new RmAttributeName(@"UsageKeyword");
        }
        
        #endregion
        
    }
}
        
