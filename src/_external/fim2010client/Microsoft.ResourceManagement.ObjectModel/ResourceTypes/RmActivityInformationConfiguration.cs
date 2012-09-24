using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {

    /// <summary>
    /// ActivityInformationConfiguration resource.
    /// Automatically generated on 06/30/2010 10:05:33
    /// </summary>
    [Serializable]
    public partial class RmActivityInformationConfiguration : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"ActivityInformationConfiguration";

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
        public RmActivityInformationConfiguration()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmActivityInformationConfiguration(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Activity Name
        /// The class name of the correspondent activity
        /// </summary>
        public string ActivityName {
            get { return GetString(AttributeNames.ActivityName); }
            set { base[AttributeNames.ActivityName].Value = value; }
        }

        /// <summary>
        /// Assembly Name
        /// The assembly where the activity settings part is defined
        /// </summary>
        public string AssemblyName {
            get { return GetString(AttributeNames.AssemblyName); }
            set { base[AttributeNames.AssemblyName].Value = value; }
        }

        /// <summary>
        /// Is Action Activity
        /// This is an indication that this activity could be put into an action process
        /// </summary>
        public bool? IsActionActivity {
            get { return GetNullable<bool>(AttributeNames.IsActionActivity); }
            set { SetNullable(AttributeNames.IsActionActivity, value); }
        }

        /// <summary>
        /// Is Authentication Activity
        /// This is an indication that this activity could be put into an authentication process
        /// </summary>
        public bool? IsAuthenticationActivity {
            get { return GetNullable<bool>(AttributeNames.IsAuthenticationActivity); }
            set { SetNullable(AttributeNames.IsAuthenticationActivity, value); }
        }

        /// <summary>
        /// Is Authorization Activity
        /// This is an indication that this activity could be put into an authorization process
        /// </summary>
        public bool? IsAuthorizationActivity {
            get { return GetNullable<bool>(AttributeNames.IsAuthorizationActivity); }
            set { SetNullable(AttributeNames.IsAuthorizationActivity, value); }
        }

        /// <summary>
        /// Is Configuration Type
        /// This is an indication that this resource is a configuration resource.
        /// </summary>
        public bool? IsConfigurationType {
            get { return GetNullable<bool>(AttributeNames.IsConfigurationType); }
            set { SetNullable(AttributeNames.IsConfigurationType, value); }
        }

        /// <summary>
        /// Type Name
        /// The class name of the activity settings part.
        /// </summary>
        public string TypeName {
            get { return GetString(AttributeNames.TypeName); }
            set { base[AttributeNames.TypeName].Value = value; }
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.ActivityName, false);
            EnsureAttributeExists(AttributeNames.AssemblyName, false);
            EnsureAttributeExists(AttributeNames.IsActionActivity, false);
            EnsureAttributeExists(AttributeNames.IsAuthenticationActivity, false);
            EnsureAttributeExists(AttributeNames.IsAuthorizationActivity, false);
            EnsureAttributeExists(AttributeNames.IsConfigurationType, false);
            EnsureAttributeExists(AttributeNames.TypeName, false);
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
        /// Names of ActivityInformationConfiguration specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Activity Name
            /// The class name of the correspondent activity
            /// </summary>
            public static RmAttributeName ActivityName = new RmAttributeName(@"ActivityName");
            /// <summary>
            /// Assembly Name
            /// The assembly where the activity settings part is defined
            /// </summary>
            public static RmAttributeName AssemblyName = new RmAttributeName(@"AssemblyName");
            /// <summary>
            /// Is Action Activity
            /// This is an indication that this activity could be put into an action process
            /// </summary>
            public static RmAttributeName IsActionActivity = new RmAttributeName(@"IsActionActivity");
            /// <summary>
            /// Is Authentication Activity
            /// This is an indication that this activity could be put into an authentication process
            /// </summary>
            public static RmAttributeName IsAuthenticationActivity = new RmAttributeName(@"IsAuthenticationActivity");
            /// <summary>
            /// Is Authorization Activity
            /// This is an indication that this activity could be put into an authorization process
            /// </summary>
            public static RmAttributeName IsAuthorizationActivity = new RmAttributeName(@"IsAuthorizationActivity");
            /// <summary>
            /// Is Configuration Type
            /// This is an indication that this resource is a configuration resource.
            /// </summary>
            public static RmAttributeName IsConfigurationType = new RmAttributeName(@"IsConfigurationType");
            /// <summary>
            /// Type Name
            /// The class name of the activity settings part.
            /// </summary>
            public static RmAttributeName TypeName = new RmAttributeName(@"TypeName");
        }

        #endregion

    }
}

