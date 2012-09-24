using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// ma-data resource.
    /// Automatically generated on 06/30/2010 10:07:04
    /// </summary>
    [Serializable]
    public partial class Rmma_data : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"ma-data`";

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
        public Rmma_data()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected Rmma_data(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// SyncConfig-attribute-inclusion
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_attribute_inclusion {
            get { return GetString(AttributeNames.SyncConfig_attribute_inclusion); }
            set { base[AttributeNames.SyncConfig_attribute_inclusion].Value = value; }
        }

        /// <summary>
        /// SyncConfig-capabilities-mask
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_capabilities_mask {
            get { return GetNullable<int>(AttributeNames.SyncConfig_capabilities_mask); }
            set { SetNullable (AttributeNames.SyncConfig_capabilities_mask, value); }
        }

        /// <summary>
        /// SyncConfig-category
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_category {
            get { return GetString(AttributeNames.SyncConfig_category); }
            set { base[AttributeNames.SyncConfig_category].Value = value; }
        }

        /// <summary>
        /// SyncConfig-component_mappings
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_component_mappings {
            get { return GetString(AttributeNames.SyncConfig_component_mappings); }
            set { base[AttributeNames.SyncConfig_component_mappings].Value = value; }
        }

        /// <summary>
        /// SyncConfig-controller-configuration
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_controller_configuration {
            get { return GetString(AttributeNames.SyncConfig_controller_configuration); }
            set { base[AttributeNames.SyncConfig_controller_configuration].Value = value; }
        }

        /// <summary>
        /// SyncConfig-creation-time
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_creation_time {
            get { return GetString(AttributeNames.SyncConfig_creation_time); }
            set { base[AttributeNames.SyncConfig_creation_time].Value = value; }
        }

        /// <summary>
        /// SyncConfig-dn-construction
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_dn_construction {
            get { return GetString(AttributeNames.SyncConfig_dn_construction); }
            set { base[AttributeNames.SyncConfig_dn_construction].Value = value; }
        }

        /// <summary>
        /// SyncConfig-encrypted-attributes
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_encrypted_attributes {
            get { return GetString(AttributeNames.SyncConfig_encrypted_attributes); }
            set { base[AttributeNames.SyncConfig_encrypted_attributes].Value = value; }
        }

        /// <summary>
        /// SyncConfig-export-attribute-flow
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_export_attribute_flow {
            get { return GetString(AttributeNames.SyncConfig_export_attribute_flow); }
            set { base[AttributeNames.SyncConfig_export_attribute_flow].Value = value; }
        }

        /// <summary>
        /// SyncConfig-export-type
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_export_type {
            get { return GetNullable<int>(AttributeNames.SyncConfig_export_type); }
            set { SetNullable (AttributeNames.SyncConfig_export_type, value); }
        }

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
        /// SyncConfig-id
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_id {
            get { return GetString(AttributeNames.SyncConfig_id); }
            set { base[AttributeNames.SyncConfig_id].Value = value; }
        }

        /// <summary>
        /// SyncConfig-internal-version
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_internal_version {
            get { return GetNullable<int>(AttributeNames.SyncConfig_internal_version); }
            set { SetNullable (AttributeNames.SyncConfig_internal_version, value); }
        }

        /// <summary>
        /// SyncConfig-join
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_join {
            get { return GetString(AttributeNames.SyncConfig_join); }
            set { base[AttributeNames.SyncConfig_join].Value = value; }
        }

        /// <summary>
        /// SyncConfig-last-modification-time
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_last_modification_time {
            get { return GetString(AttributeNames.SyncConfig_last_modification_time); }
            set { base[AttributeNames.SyncConfig_last_modification_time].Value = value; }
        }

        /// <summary>
        /// SyncConfig-ma-companyname
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_companyname {
            get { return GetString(AttributeNames.SyncConfig_ma_companyname); }
            set { base[AttributeNames.SyncConfig_ma_companyname].Value = value; }
        }

        /// <summary>
        /// SyncConfig-ma-listname
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_listname {
            get { return GetString(AttributeNames.SyncConfig_ma_listname); }
            set { base[AttributeNames.SyncConfig_ma_listname].Value = value; }
        }

        RmList<string> _syncConfig_ma_partition_data;
        
        /// <summary>
        /// SyncConfig-ma-partition-data
        /// Sync Configuration resource attribute
        /// </summary>
        public IList<string> SyncConfig_ma_partition_data {
            get {
                if (_syncConfig_ma_partition_data == null) {
                    lock (base.attributes) {
                        _syncConfig_ma_partition_data = GetMultiValuedString(AttributeNames.SyncConfig_ma_partition_data);
                    }
                }
                return _syncConfig_ma_partition_data;
            }
        }

        RmList<string> _syncConfig_ma_run_data;
        
        /// <summary>
        /// SyncConfig-ma-run-data
        /// Sync Configuration resource attribute
        /// </summary>
        public IList<string> SyncConfig_ma_run_data {
            get {
                if (_syncConfig_ma_run_data == null) {
                    lock (base.attributes) {
                        _syncConfig_ma_run_data = GetMultiValuedString(AttributeNames.SyncConfig_ma_run_data);
                    }
                }
                return _syncConfig_ma_run_data;
            }
        }

        /// <summary>
        /// SyncConfig-ma-ui-settings
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_ma_ui_settings {
            get { return GetString(AttributeNames.SyncConfig_ma_ui_settings); }
            set { base[AttributeNames.SyncConfig_ma_ui_settings].Value = value; }
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
        /// SyncConfig-password-sync-allowed
        /// Sync Configuration resource attribute
        /// </summary>
        public int? SyncConfig_password_sync_allowed {
            get { return GetNullable<int>(AttributeNames.SyncConfig_password_sync_allowed); }
            set { SetNullable (AttributeNames.SyncConfig_password_sync_allowed, value); }
        }

        /// <summary>
        /// SyncConfig-private-configuration
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_private_configuration {
            get { return GetString(AttributeNames.SyncConfig_private_configuration); }
            set { base[AttributeNames.SyncConfig_private_configuration].Value = value; }
        }

        /// <summary>
        /// SyncConfig-projection
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_projection {
            get { return GetString(AttributeNames.SyncConfig_projection); }
            set { base[AttributeNames.SyncConfig_projection].Value = value; }
        }

        /// <summary>
        /// SyncConfig-provisioning-cleanup
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_cleanup {
            get { return GetString(AttributeNames.SyncConfig_provisioning_cleanup); }
            set { base[AttributeNames.SyncConfig_provisioning_cleanup].Value = value; }
        }

        /// <summary>
        /// SyncConfig-provisioning-cleanup-type
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_provisioning_cleanup_type {
            get { return GetString(AttributeNames.SyncConfig_provisioning_cleanup_type); }
            set { base[AttributeNames.SyncConfig_provisioning_cleanup_type].Value = value; }
        }

        /// <summary>
        /// SyncConfig-refresh-schema
        /// Refresh Schema
        /// </summary>
        public int? SyncConfig_refresh_schema {
            get { return GetNullable<int>(AttributeNames.SyncConfig_refresh_schema); }
            set { SetNullable (AttributeNames.SyncConfig_refresh_schema, value); }
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
        /// SyncConfig-stay-disconnector
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_stay_disconnector {
            get { return GetString(AttributeNames.SyncConfig_stay_disconnector); }
            set { base[AttributeNames.SyncConfig_stay_disconnector].Value = value; }
        }

        /// <summary>
        /// SyncConfig-sub-type
        /// Sync Configuration resource attribute
        /// </summary>
        public string SyncConfig_sub_type {
            get { return GetString(AttributeNames.SyncConfig_sub_type); }
            set { base[AttributeNames.SyncConfig_sub_type].Value = value; }
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
            EnsureAttributeExists(AttributeNames.SyncConfig_attribute_inclusion, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_capabilities_mask, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_category, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_component_mappings, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_controller_configuration, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_creation_time, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_dn_construction, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_encrypted_attributes, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_export_attribute_flow, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_export_type, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_extension, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_format_version, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_id, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_internal_version, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_join, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_last_modification_time, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_ma_companyname, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_ma_listname, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_ma_partition_data, true);
            EnsureAttributeExists(AttributeNames.SyncConfig_ma_run_data, true);
            EnsureAttributeExists(AttributeNames.SyncConfig_ma_ui_settings, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_password_sync, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_password_sync_allowed, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_private_configuration, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_projection, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_provisioning_cleanup, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_provisioning_cleanup_type, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_refresh_schema, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_schema, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_stay_disconnector, false);
            EnsureAttributeExists(AttributeNames.SyncConfig_sub_type, false);
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
        /// Names of ma-data specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// SyncConfig-attribute-inclusion
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_attribute_inclusion = new RmAttributeName(@"SyncConfig-attribute-inclusion");
            /// <summary>
            /// SyncConfig-capabilities-mask
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_capabilities_mask = new RmAttributeName(@"SyncConfig-capabilities-mask");
            /// <summary>
            /// SyncConfig-category
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_category = new RmAttributeName(@"SyncConfig-category");
            /// <summary>
            /// SyncConfig-component_mappings
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_component_mappings = new RmAttributeName(@"SyncConfig-component_mappings");
            /// <summary>
            /// SyncConfig-controller-configuration
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_controller_configuration = new RmAttributeName(@"SyncConfig-controller-configuration");
            /// <summary>
            /// SyncConfig-creation-time
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_creation_time = new RmAttributeName(@"SyncConfig-creation-time");
            /// <summary>
            /// SyncConfig-dn-construction
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_dn_construction = new RmAttributeName(@"SyncConfig-dn-construction");
            /// <summary>
            /// SyncConfig-encrypted-attributes
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_encrypted_attributes = new RmAttributeName(@"SyncConfig-encrypted-attributes");
            /// <summary>
            /// SyncConfig-export-attribute-flow
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_export_attribute_flow = new RmAttributeName(@"SyncConfig-export-attribute-flow");
            /// <summary>
            /// SyncConfig-export-type
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_export_type = new RmAttributeName(@"SyncConfig-export-type");
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
            /// SyncConfig-id
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_id = new RmAttributeName(@"SyncConfig-id");
            /// <summary>
            /// SyncConfig-internal-version
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_internal_version = new RmAttributeName(@"SyncConfig-internal-version");
            /// <summary>
            /// SyncConfig-join
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_join = new RmAttributeName(@"SyncConfig-join");
            /// <summary>
            /// SyncConfig-last-modification-time
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_last_modification_time = new RmAttributeName(@"SyncConfig-last-modification-time");
            /// <summary>
            /// SyncConfig-ma-companyname
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_ma_companyname = new RmAttributeName(@"SyncConfig-ma-companyname");
            /// <summary>
            /// SyncConfig-ma-listname
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_ma_listname = new RmAttributeName(@"SyncConfig-ma-listname");
            /// <summary>
            /// SyncConfig-ma-partition-data
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_ma_partition_data = new RmAttributeName(@"SyncConfig-ma-partition-data");
            /// <summary>
            /// SyncConfig-ma-run-data
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_ma_run_data = new RmAttributeName(@"SyncConfig-ma-run-data");
            /// <summary>
            /// SyncConfig-ma-ui-settings
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_ma_ui_settings = new RmAttributeName(@"SyncConfig-ma-ui-settings");
            /// <summary>
            /// SyncConfig-password-sync
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_password_sync = new RmAttributeName(@"SyncConfig-password-sync");
            /// <summary>
            /// SyncConfig-password-sync-allowed
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_password_sync_allowed = new RmAttributeName(@"SyncConfig-password-sync-allowed");
            /// <summary>
            /// SyncConfig-private-configuration
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_private_configuration = new RmAttributeName(@"SyncConfig-private-configuration");
            /// <summary>
            /// SyncConfig-projection
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_projection = new RmAttributeName(@"SyncConfig-projection");
            /// <summary>
            /// SyncConfig-provisioning-cleanup
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_provisioning_cleanup = new RmAttributeName(@"SyncConfig-provisioning-cleanup");
            /// <summary>
            /// SyncConfig-provisioning-cleanup-type
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_provisioning_cleanup_type = new RmAttributeName(@"SyncConfig-provisioning-cleanup-type");
            /// <summary>
            /// SyncConfig-refresh-schema
            /// Refresh Schema
            /// </summary>
            public static RmAttributeName SyncConfig_refresh_schema = new RmAttributeName(@"SyncConfig-refresh-schema");
            /// <summary>
            /// SyncConfig-schema
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_schema = new RmAttributeName(@"SyncConfig-schema");
            /// <summary>
            /// SyncConfig-stay-disconnector
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_stay_disconnector = new RmAttributeName(@"SyncConfig-stay-disconnector");
            /// <summary>
            /// SyncConfig-sub-type
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_sub_type = new RmAttributeName(@"SyncConfig-sub-type");
            /// <summary>
            /// SyncConfig-version
            /// Sync Configuration resource attribute
            /// </summary>
            public static RmAttributeName SyncConfig_version = new RmAttributeName(@"SyncConfig-version");
        }
        
        #endregion
        
    }
}
        
