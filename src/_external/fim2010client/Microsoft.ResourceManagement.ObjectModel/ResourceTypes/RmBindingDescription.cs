using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// BindingDescription resource.
    /// Automatically generated on 06/30/2010 10:05:54
    /// </summary>
    [Serializable]
    public partial class RmBindingDescription : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"BindingDescription";

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
        public RmBindingDescription()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmBindingDescription(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Attribute Is Required
        /// Required
        /// </summary>
        public bool? Required {
            get { return GetNullable<bool>(AttributeNames.Required); }
            set { SetNullable (AttributeNames.Required, value); }
        }

        /// <summary>
        /// Attribute Type
        /// The binding's attribute type
        /// </summary>
        public RmReference BoundAttributeType {
            get { return GetReference(AttributeNames.BoundAttributeType); }
            set { base[AttributeNames.BoundAttributeType].Value = value; }
        }

        /// <summary>
        /// Integer Maximum
        /// For an Integer attribute, this is the maximum value, inclusive.
        /// </summary>
        public int? IntegerMaximum {
            get { return GetNullable<int>(AttributeNames.IntegerMaximum); }
            set { SetNullable (AttributeNames.IntegerMaximum, value); }
        }

        /// <summary>
        /// Integer Minimum
        /// For an Integer attribute, this is the minimum value, inclusive.
        /// </summary>
        public int? IntegerMinimum {
            get { return GetNullable<int>(AttributeNames.IntegerMinimum); }
            set { SetNullable (AttributeNames.IntegerMinimum, value); }
        }

        /// <summary>
        /// Localizable
        /// A true indicates this attribute can be localized.  Only allowed for String DataTypes.
        /// </summary>
        public bool? Localizable {
            get { return GetNullable<bool>(AttributeNames.Localizable); }
            set { SetNullable (AttributeNames.Localizable, value); }
        }

        /// <summary>
        /// Resource Type
        /// The binding's resource type
        /// </summary>
        public RmReference BoundObjectType {
            get { return GetReference(AttributeNames.BoundObjectType); }
            set { base[AttributeNames.BoundObjectType].Value = value; }
        }

        /// <summary>
        /// String Regular Expression
        /// This is a .Net Regex pattern that defines what string values are allowed.
        /// </summary>
        public string StringRegex {
            get { return GetString(AttributeNames.StringRegex); }
            set { base[AttributeNames.StringRegex].Value = value; }
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
            EnsureAttributeExists(AttributeNames.Required, false);
            EnsureAttributeExists(AttributeNames.BoundAttributeType, false);
            EnsureAttributeExists(AttributeNames.IntegerMaximum, false);
            EnsureAttributeExists(AttributeNames.IntegerMinimum, false);
            EnsureAttributeExists(AttributeNames.Localizable, false);
            EnsureAttributeExists(AttributeNames.BoundObjectType, false);
            EnsureAttributeExists(AttributeNames.StringRegex, false);
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
        /// Names of BindingDescription specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Attribute Is Required
            /// Required
            /// </summary>
            public static RmAttributeName Required = new RmAttributeName(@"Required");
            /// <summary>
            /// Attribute Type
            /// The binding's attribute type
            /// </summary>
            public static RmAttributeName BoundAttributeType = new RmAttributeName(@"BoundAttributeType");
            /// <summary>
            /// Integer Maximum
            /// For an Integer attribute, this is the maximum value, inclusive.
            /// </summary>
            public static RmAttributeName IntegerMaximum = new RmAttributeName(@"IntegerMaximum");
            /// <summary>
            /// Integer Minimum
            /// For an Integer attribute, this is the minimum value, inclusive.
            /// </summary>
            public static RmAttributeName IntegerMinimum = new RmAttributeName(@"IntegerMinimum");
            /// <summary>
            /// Localizable
            /// A true indicates this attribute can be localized.  Only allowed for String DataTypes.
            /// </summary>
            public static RmAttributeName Localizable = new RmAttributeName(@"Localizable");
            /// <summary>
            /// Resource Type
            /// The binding's resource type
            /// </summary>
            public static RmAttributeName BoundObjectType = new RmAttributeName(@"BoundObjectType");
            /// <summary>
            /// String Regular Expression
            /// This is a .Net Regex pattern that defines what string values are allowed.
            /// </summary>
            public static RmAttributeName StringRegex = new RmAttributeName(@"StringRegex");
            /// <summary>
            /// Usage Keyword
            /// UsageKeyword
            /// </summary>
            public static RmAttributeName UsageKeyword = new RmAttributeName(@"UsageKeyword");
        }
        
        #endregion
        
    }
}
        
