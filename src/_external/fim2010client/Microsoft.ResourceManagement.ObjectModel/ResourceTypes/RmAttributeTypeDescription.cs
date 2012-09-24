using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// AttributeTypeDescription resource.
    /// Automatically generated on 06/30/2010 10:05:50
    /// </summary>
    [Serializable]
    public partial class RmAttributeTypeDescription : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"AttributeTypeDescription";

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
        public RmAttributeTypeDescription()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmAttributeTypeDescription(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Data Type
        /// DataType
        /// </summary>
        public string DataType {
            get { return GetString(AttributeNames.DataType); }
            set { base[AttributeNames.DataType].Value = value; }
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
        /// Multivalued
        /// Multivalued
        /// </summary>
        public bool? Multivalued {
            get { return GetNullable<bool>(AttributeNames.Multivalued); }
            set { SetNullable (AttributeNames.Multivalued, value); }
        }

        /// <summary>
        /// Name
        /// Name
        /// </summary>
        public string Name {
            get { return GetString(AttributeNames.Name); }
            set { base[AttributeNames.Name].Value = value; }
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
            EnsureAttributeExists(AttributeNames.DataType, false);
            EnsureAttributeExists(AttributeNames.IntegerMaximum, false);
            EnsureAttributeExists(AttributeNames.IntegerMinimum, false);
            EnsureAttributeExists(AttributeNames.Localizable, false);
            EnsureAttributeExists(AttributeNames.Multivalued, false);
            EnsureAttributeExists(AttributeNames.Name, false);
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
        /// Names of AttributeTypeDescription specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Data Type
            /// DataType
            /// </summary>
            public static RmAttributeName DataType = new RmAttributeName(@"DataType");
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
            /// Multivalued
            /// Multivalued
            /// </summary>
            public static RmAttributeName Multivalued = new RmAttributeName(@"Multivalued");
            /// <summary>
            /// Name
            /// Name
            /// </summary>
            public static RmAttributeName Name = new RmAttributeName(@"Name");
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
        
