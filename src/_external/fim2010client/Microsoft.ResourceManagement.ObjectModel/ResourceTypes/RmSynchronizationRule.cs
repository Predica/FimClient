using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// SynchronizationRule resource.
    /// Automatically generated on 06/30/2010 10:08:11
    /// </summary>
    [Serializable]
    public partial class RmSynchronizationRule : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @`"SynchronizationRule`";

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
        public RmSynchronizationRule()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmSynchronizationRule(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Create External System Resource
        /// Indicates if an external system resource is created if the relationship criteria is not met.
        /// </summary>
        public bool? CreateConnectedSystemObject {
            get { return GetNullable<bool>(AttributeNames.CreateConnectedSystemObject); }
            set { SetNullable (AttributeNames.CreateConnectedSystemObject, value); }
        }

        /// <summary>
        /// Create FIM Resource
        /// Indicates if a resource should be created in FIM if the relationship criteria is not met.
        /// </summary>
        public bool? CreateILMObject {
            get { return GetNullable<bool>(AttributeNames.CreateILMObject); }
            set { SetNullable (AttributeNames.CreateILMObject, value); }
        }

        /// <summary>
        /// Data Flow Direction
        /// A Synchronization Rule can be defined as inbound (0), outbound (1) or bi-directional (2).
        /// </summary>
        public int? FlowType {
            get { return GetNullable<int>(AttributeNames.FlowType); }
            set { SetNullable (AttributeNames.FlowType, value); }
        }

        /// <summary>
        /// Dependency
        /// A Synchronization Rule that must be applied to a resource before this Synchronization Rule can be applied.
        /// </summary>
        public RmReference Dependency {
            get { return GetReference(AttributeNames.Dependency); }
            set { base[AttributeNames.Dependency].Value = value; }
        }

        /// <summary>
        /// Disconnect External System Resource
        /// This option applies when this Synchronization Rule is removed from a resource in FIM.
        /// </summary>
        public bool? DisconnectConnectedSystemObject {
            get { return GetNullable<bool>(AttributeNames.DisconnectConnectedSystemObject); }
            set { SetNullable (AttributeNames.DisconnectConnectedSystemObject, value); }
        }

        RmList<string> _existenceTest;
        
        /// <summary>
        /// Existence Test
        /// Outbound attribute flows within a transformation marked as an existence tests for the Synchronization Rule.
        /// </summary>
        public IList<string> ExistenceTest {
            get {
                if (_existenceTest == null) {
                    lock (base.attributes) {
                        _existenceTest = GetMultiValuedString(AttributeNames.ExistenceTest);
                    }
                }
                return _existenceTest;
            }
        }

        /// <summary>
        /// External System
        /// The Management Agent identifying the external system this Synchronization Rule will operate on.
        /// </summary>
        public string ConnectedSystem {
            get { return GetString(AttributeNames.ConnectedSystem); }
            set { base[AttributeNames.ConnectedSystem].Value = value; }
        }

        /// <summary>
        /// External System Resource Type
        /// The resource type in the external system that this Synchronization Rule applies to.
        /// </summary>
        public string ConnectedObjectType {
            get { return GetString(AttributeNames.ConnectedObjectType); }
            set { base[AttributeNames.ConnectedObjectType].Value = value; }
        }

        /// <summary>
        /// External System Scoping Filter
        /// A filter representing the resources on the external system that the rule applies to.
        /// </summary>
        public string ConnectedSystemScope {
            get { return GetString(AttributeNames.ConnectedSystemScope); }
            set { base[AttributeNames.ConnectedSystemScope].Value = value; }
        }

        /// <summary>
        /// FIM Resource Type
        /// The resource type in the FIM Metaverse that this Synchronization Rule applies to.
        /// </summary>
        public string ILMObjectType {
            get { return GetString(AttributeNames.ILMObjectType); }
            set { base[AttributeNames.ILMObjectType].Value = value; }
        }

        RmList<string> _initialFlow;
        
        /// <summary>
        /// Initial Flow
        /// A series of outbound flows between FIM and external systems.  These flows are only executed upon creation of a new resource.
        /// </summary>
        public IList<string> InitialFlow {
            get {
                if (_initialFlow == null) {
                    lock (base.attributes) {
                        _initialFlow = GetMultiValuedString(AttributeNames.InitialFlow);
                    }
                }
                return _initialFlow;
            }
        }

        RmList<string> _persistentFlow;
        
        /// <summary>
        /// Persistent Flow
        /// A series of attribute flow definitions.
        /// </summary>
        public IList<string> PersistentFlow {
            get {
                if (_persistentFlow == null) {
                    lock (base.attributes) {
                        _persistentFlow = GetMultiValuedString(AttributeNames.PersistentFlow);
                    }
                }
                return _persistentFlow;
            }
        }

        /// <summary>
        /// Precedence
        /// A number indicating the Synchronization Rule's precedence relative to all other Synchronization Rules that apply to the same external system.  A smaller number represents a higher precedence.
        /// </summary>
        public int? Precedence {
            get { return GetNullable<int>(AttributeNames.Precedence); }
            set { SetNullable (AttributeNames.Precedence, value); }
        }

        /// <summary>
        /// Relationship Criteria
        /// Defines how a relationship between a resource in FIM and a resource in an external system is detected.
        /// </summary>
        public string RelationshipCriteria {
            get { return GetString(AttributeNames.RelationshipCriteria); }
            set { base[AttributeNames.RelationshipCriteria].Value = value; }
        }

        RmList<string> _synchronizationRuleParameters;
        
        /// <summary>
        /// Synchronization Rule Parameters
        /// These are parameters which require values to be provided from the workflow that adds the Synchronization Rule to a resource.
        /// </summary>
        public IList<string> SynchronizationRuleParameters {
            get {
                if (_synchronizationRuleParameters == null) {
                    lock (base.attributes) {
                        _synchronizationRuleParameters = GetMultiValuedString(AttributeNames.SynchronizationRuleParameters);
                    }
                }
                return _synchronizationRuleParameters;
            }
        }
        
        #endregion

        #region Protected methods
        
        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.CreateConnectedSystemObject, false);
            EnsureAttributeExists(AttributeNames.CreateILMObject, false);
            EnsureAttributeExists(AttributeNames.FlowType, false);
            EnsureAttributeExists(AttributeNames.Dependency, false);
            EnsureAttributeExists(AttributeNames.DisconnectConnectedSystemObject, false);
            EnsureAttributeExists(AttributeNames.ExistenceTest, true);
            EnsureAttributeExists(AttributeNames.ConnectedSystem, false);
            EnsureAttributeExists(AttributeNames.ConnectedObjectType, false);
            EnsureAttributeExists(AttributeNames.ConnectedSystemScope, false);
            EnsureAttributeExists(AttributeNames.ILMObjectType, false);
            EnsureAttributeExists(AttributeNames.InitialFlow, true);
            EnsureAttributeExists(AttributeNames.PersistentFlow, true);
            EnsureAttributeExists(AttributeNames.Precedence, false);
            EnsureAttributeExists(AttributeNames.RelationshipCriteria, false);
            EnsureAttributeExists(AttributeNames.SynchronizationRuleParameters, true);
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
        /// Names of SynchronizationRule specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Create External System Resource
            /// Indicates if an external system resource is created if the relationship criteria is not met.
            /// </summary>
            public static RmAttributeName CreateConnectedSystemObject = new RmAttributeName(@"CreateConnectedSystemObject");
            /// <summary>
            /// Create FIM Resource
            /// Indicates if a resource should be created in FIM if the relationship criteria is not met.
            /// </summary>
            public static RmAttributeName CreateILMObject = new RmAttributeName(@"CreateILMObject");
            /// <summary>
            /// Data Flow Direction
            /// A Synchronization Rule can be defined as inbound (0), outbound (1) or bi-directional (2).
            /// </summary>
            public static RmAttributeName FlowType = new RmAttributeName(@"FlowType");
            /// <summary>
            /// Dependency
            /// A Synchronization Rule that must be applied to a resource before this Synchronization Rule can be applied.
            /// </summary>
            public static RmAttributeName Dependency = new RmAttributeName(@"Dependency");
            /// <summary>
            /// Disconnect External System Resource
            /// This option applies when this Synchronization Rule is removed from a resource in FIM.
            /// </summary>
            public static RmAttributeName DisconnectConnectedSystemObject = new RmAttributeName(@"DisconnectConnectedSystemObject");
            /// <summary>
            /// Existence Test
            /// Outbound attribute flows within a transformation marked as an existence tests for the Synchronization Rule.
            /// </summary>
            public static RmAttributeName ExistenceTest = new RmAttributeName(@"ExistenceTest");
            /// <summary>
            /// External System
            /// The Management Agent identifying the external system this Synchronization Rule will operate on.
            /// </summary>
            public static RmAttributeName ConnectedSystem = new RmAttributeName(@"ConnectedSystem");
            /// <summary>
            /// External System Resource Type
            /// The resource type in the external system that this Synchronization Rule applies to.
            /// </summary>
            public static RmAttributeName ConnectedObjectType = new RmAttributeName(@"ConnectedObjectType");
            /// <summary>
            /// External System Scoping Filter
            /// A filter representing the resources on the external system that the rule applies to.
            /// </summary>
            public static RmAttributeName ConnectedSystemScope = new RmAttributeName(@"ConnectedSystemScope");
            /// <summary>
            /// FIM Resource Type
            /// The resource type in the FIM Metaverse that this Synchronization Rule applies to.
            /// </summary>
            public static RmAttributeName ILMObjectType = new RmAttributeName(@"ILMObjectType");
            /// <summary>
            /// Initial Flow
            /// A series of outbound flows between FIM and external systems.  These flows are only executed upon creation of a new resource.
            /// </summary>
            public static RmAttributeName InitialFlow = new RmAttributeName(@"InitialFlow");
            /// <summary>
            /// Persistent Flow
            /// A series of attribute flow definitions.
            /// </summary>
            public static RmAttributeName PersistentFlow = new RmAttributeName(@"PersistentFlow");
            /// <summary>
            /// Precedence
            /// A number indicating the Synchronization Rule's precedence relative to all other Synchronization Rules that apply to the same external system.  A smaller number represents a higher precedence.
            /// </summary>
            public static RmAttributeName Precedence = new RmAttributeName(@"Precedence");
            /// <summary>
            /// Relationship Criteria
            /// Defines how a relationship between a resource in FIM and a resource in an external system is detected.
            /// </summary>
            public static RmAttributeName RelationshipCriteria = new RmAttributeName(@"RelationshipCriteria");
            /// <summary>
            /// Synchronization Rule Parameters
            /// These are parameters which require values to be provided from the workflow that adds the Synchronization Rule to a resource.
            /// </summary>
            public static RmAttributeName SynchronizationRuleParameters = new RmAttributeName(@"SynchronizationRuleParameters");
        }
        
        #endregion
        
    }
}
        
