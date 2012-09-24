using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// mv-data resource.
    /// Automatically generated on 06/30/2010 10:07:18
    /// </summary>
    [Serializable]
    public partial class Rmmv_data : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"mv-data`";

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
        public Rmmv_data()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected Rmmv_data(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// SyncConfig-extension
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_extension {
            get { return GetString(AttributeNames.SyncConfig_extension); }
            set { base[AttributeNames.SyncConfig_extension].Value = value; }
        }

        /// <summary>
        /// SyncConfig-format-version
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_format_version {
            get { return GetNullable<int>(AttributeNames.SyncConfig_format_version); }
            set { SetNullable (AttributeNames.SyncConfig_format_version, value); }
        }

        /// <summary>
        /// SyncConfig-import-attribute-flow
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_import_attribute_flow {
            get { return GetString(AttributeNames.SyncConfig_import_attribute_flow); }
            set { base[AttributeNames.SyncConfig_import_attribute_flow].Value = value; }
        }

        /// <summary>
        /// SyncConfig-mv-deletion
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_mv_deletion {
            get { return GetString(AttributeNames.SyncConfig_mv_deletion); }
            set { base[AttributeNames.SyncConfig_mv_deletion].Value = value; }
        }

        /// <summary>
        /// SyncConfig-password-change-history-size
        /// ObjectTypes that are synced
        /// </summary>
        public int? SyncConfig_password_change_history_size {
            get { return GetNullable<int>(AttributeNames.SyncConfig_password_change_history_size); }
            set { SetNullable (AttributeNames.SyncConfig_password_change_history_size, value); }
        }

        /// <summary>
        /// SyncConfig-password-sync
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_password_sync {
            get { return GetString(AttributeNames.SyncConfig_password_sync); }
            set { base[AttributeNames.SyncConfig_password_sync].Value = value; }
        }

        /// <summary>
        /// SyncConfig-provisioning
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning {
            get { return GetString(AttributeNames.SyncConfig_provisioning); }
            set { base[AttributeNames.SyncConfig_provisioning].Value = value; }
        }

        /// <summary>
        /// SyncConfig-provisioning-type
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_type {
            get { return GetString(AttributeNames.SyncConfig_provisioning_type); }
            set { base[AttributeNames.SyncConfig_provisioning_type].Value = value; }
        }

        /// <summary>
        /// SyncConfig-schema
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_schema {
            get { return GetString(AttributeNames.SyncConfig_schema); }
            set { base[AttributeNames.SyncConfig_schema].Value = value; }
        }

        /// <summary>
        /// SyncConfig-version
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_version {
            get { return GetNullable<int>(AttributeNames.SyncConfig_version); }
            set { SetNullable (AttributeNames.SyncConfig_version, value); }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.SyncConfig_extension, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_format_version, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_import_attribute_flow, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_mv_deletion, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_password_change_history_size, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_password_sync, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_provisioning, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_provisioning_type, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_schema, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_version, false);
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
        /// Names of mv-data specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// SyncConfig-extension
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_extension = new RmAttributeName(@"SyncConfig-extension");
            /// <summary>
            /// SyncConfig-format-version
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_format_version = new RmAttributeName(@"SyncConfig-format-version");
            /// <summary>
            /// SyncConfig-import-attribute-flow
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_import_attribute_flow = new RmAttributeName(@"SyncConfig-import-attribute-flow");
            /// <summary>
            /// SyncConfig-mv-deletion
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_mv_deletion = new RmAttributeName(@"SyncConfig-mv-deletion");
            /// <summary>
            /// SyncConfig-password-change-history-size
            /// ObjectTypes that are synced
            /// </summary>
            public static RmAttributeName SyncConfig_password_change_history_size = new RmAttributeName(@"SyncConfig-password-change-history-size");
            /// <summary>
            /// SyncConfig-password-sync
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_password_sync = new RmAttributeName(@"SyncConfig-password-sync");
            /// <summary>
            /// SyncConfig-provisioning
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_provisioning = new RmAttributeName(@"SyncConfig-provisioning");
            /// <summary>
            /// SyncConfig-provisioning-type
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_provisioning_type = new RmAttributeName(@"SyncConfig-provisioning-type");
            /// <summary>
            /// SyncConfig-schema
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_schema = new RmAttributeName(@"SyncConfig-schema");
            /// <summary>
            /// SyncConfig-version
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_version = new RmAttributeName(@"SyncConfig-version");
        }
        
        #endregion
        
    }
}
        
