using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {

    /// <summary>
    /// Group resource.
    /// Automatically generated on 06/30/2010 10:06:40
    /// </summary>
    [Serializable]
    public partial class RmGroup : RmResource {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"Group";

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
        public RmGroup()
            : base() {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmGroup(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) {
        }

        #region promoted properties


        /// <summary>
        /// Account Name
        /// User's log on name
        /// </summary>
        public string AccountName {
            get { return GetString(AttributeNames.AccountName); }
            set { base[AttributeNames.AccountName].Value = value; }
        }

        RmList<RmReference> _computedMember;

        /// <summary>
        /// Computed Member
        /// Resources in the set that are computed from the membership filter
        /// </summary>
        public IList<RmReference> ComputedMember {
            get {
                if (_computedMember == null) {
                    lock (base.attributes) {
                        _computedMember = GetMultiValuedReference(AttributeNames.ComputedMember);
                    }
                }
                return _computedMember;
            }
        }

        /// <summary>
        /// Displayed Owner
        /// DisplayedOwner
        /// </summary>
        public RmReference DisplayedOwner {
            get { return GetReference(AttributeNames.DisplayedOwner); }
            set { base[AttributeNames.DisplayedOwner].Value = value; }
        }

        /// <summary>
        /// Domain
        /// Choose the domain where you want to create the user account for this user
        /// </summary>
        public string Domain {
            get { return GetString(AttributeNames.Domain); }
            set { base[AttributeNames.Domain].Value = value; }
        }

        /// <summary>
        /// Domain Configuration
        /// A reference to a the parent Domain resource for this resource.
        /// </summary>
        public RmReference DomainConfiguration {
            get { return GetReference(AttributeNames.DomainConfiguration); }
            set { base[AttributeNames.DomainConfiguration].Value = value; }
        }

        /// <summary>
        /// E-mail
        /// Primary e-mail address for the user
        /// </summary>
        public string Email {
            get { return GetString(AttributeNames.Email); }
            set { base[AttributeNames.Email].Value = value; }
        }

        /// <summary>
        /// E-mail Alias
        /// E-mail alias. It is used to create the e-mail address
        /// </summary>
        public string MailNickname {
            get { return GetString(AttributeNames.MailNickname); }
            set { base[AttributeNames.MailNickname].Value = value; }
        }

        /// <summary>
        /// Filter
        /// A predicate defining a subset of the resources.
        /// </summary>
        public string Filter {
            get { return GetString(AttributeNames.Filter); }
            set { base[AttributeNames.Filter].Value = value; }
        }

        RmList<RmReference> _explicitMember;

        /// <summary>
        /// Manually-managed Membership
        /// ExplicitMember
        /// </summary>
        public IList<RmReference> ExplicitMember {
            get {
                if (_explicitMember == null) {
                    lock (base.attributes) {
                        _explicitMember = GetMultiValuedReference(AttributeNames.ExplicitMember);
                    }
                }
                return _explicitMember;
            }
        }

        /// <summary>
        /// Membership Add Workflow
        /// MembershipAddWorkflow
        /// </summary>
        public string MembershipAddWorkflow {
            get { return GetString(AttributeNames.MembershipAddWorkflow); }
            set { base[AttributeNames.MembershipAddWorkflow].Value = value; }
        }

        /// <summary>
        /// Membership Locked
        /// MembershipLocked
        /// </summary>
        public bool? MembershipLocked {
            get { return GetNullable<bool>(AttributeNames.MembershipLocked); }
            set { SetNullable(AttributeNames.MembershipLocked, value); }
        }

        RmList<RmReference> _owner;

        /// <summary>
        /// Owner
        /// Owner
        /// </summary>
        public IList<RmReference> Owner {
            get {
                if (_owner == null) {
                    lock (base.attributes) {
                        _owner = GetMultiValuedReference(AttributeNames.Owner);
                    }
                }
                return _owner;
            }
        }

        /// <summary>
        /// Resource SID
        /// A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
        /// </summary>
        public int? ObjectSID {
            get { return GetNullable<int>(AttributeNames.ObjectSID); }
            set { SetNullable(AttributeNames.ObjectSID, value); }
        }

        /// <summary>
        /// Scope
        /// Scope
        /// </summary>
        public string Scope {
            get { return GetString(AttributeNames.Scope); }
            set { base[AttributeNames.Scope].Value = value; }
        }

        /// <summary>
        /// Temporal
        /// Defined by a filter that matches resources based on date and time attributes
        /// </summary>
        public bool? Temporal {
            get { return GetNullable<bool>(AttributeNames.Temporal); }
            set { SetNullable(AttributeNames.Temporal, value); }
        }

        /// <summary>
        /// Type
        /// Type
        /// </summary>
        public string Type {
            get { return GetString(AttributeNames.Type); }
            set { base[AttributeNames.Type].Value = value; }
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist() {
            EnsureAttributeExists(AttributeNames.AccountName, false);
            EnsureAttributeExists(AttributeNames.ComputedMember, true);
            EnsureAttributeExists(AttributeNames.DisplayedOwner, false);
            EnsureAttributeExists(AttributeNames.Domain, false);
            EnsureAttributeExists(AttributeNames.DomainConfiguration, false);
            EnsureAttributeExists(AttributeNames.Email, false);
            EnsureAttributeExists(AttributeNames.MailNickname, false);
            EnsureAttributeExists(AttributeNames.Filter, false);
            EnsureAttributeExists(AttributeNames.ExplicitMember, true);
            EnsureAttributeExists(AttributeNames.MembershipAddWorkflow, false);
            EnsureAttributeExists(AttributeNames.MembershipLocked, false);
            EnsureAttributeExists(AttributeNames.Owner, true);
            EnsureAttributeExists(AttributeNames.ObjectSID, false);
            EnsureAttributeExists(AttributeNames.Scope, false);
            EnsureAttributeExists(AttributeNames.Temporal, false);
            EnsureAttributeExists(AttributeNames.Type, false);
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
        /// Names of Group specific attributes
        /// </summary>
        public sealed new partial class AttributeNames {
            /// <summary>
            /// Account Name
            /// User's log on name
            /// </summary>
            public static RmAttributeName AccountName = new RmAttributeName(@"AccountName");
            /// <summary>
            /// Computed Member
            /// Resources in the set that are computed from the membership filter
            /// </summary>
            public static RmAttributeName ComputedMember = new RmAttributeName(@"ComputedMember");
            /// <summary>
            /// Displayed Owner
            /// DisplayedOwner
            /// </summary>
            public static RmAttributeName DisplayedOwner = new RmAttributeName(@"DisplayedOwner");
            /// <summary>
            /// Domain
            /// Choose the domain where you want to create the user account for this user
            /// </summary>
            public static RmAttributeName Domain = new RmAttributeName(@"Domain");
            /// <summary>
            /// Domain Configuration
            /// A reference to a the parent Domain resource for this resource.
            /// </summary>
            public static RmAttributeName DomainConfiguration = new RmAttributeName(@"DomainConfiguration");
            /// <summary>
            /// E-mail
            /// Primary e-mail address for the user
            /// </summary>
            public static RmAttributeName Email = new RmAttributeName(@"Email");
            /// <summary>
            /// E-mail Alias
            /// E-mail alias. It is used to create the e-mail address
            /// </summary>
            public static RmAttributeName MailNickname = new RmAttributeName(@"MailNickname");
            /// <summary>
            /// Filter
            /// A predicate defining a subset of the resources.
            /// </summary>
            public static RmAttributeName Filter = new RmAttributeName(@"Filter");
            /// <summary>
            /// Manually-managed Membership
            /// ExplicitMember
            /// </summary>
            public static RmAttributeName ExplicitMember = new RmAttributeName(@"ExplicitMember");
            /// <summary>
            /// Membership Add Workflow
            /// MembershipAddWorkflow
            /// </summary>
            public static RmAttributeName MembershipAddWorkflow = new RmAttributeName(@"MembershipAddWorkflow");
            /// <summary>
            /// Membership Locked
            /// MembershipLocked
            /// </summary>
            public static RmAttributeName MembershipLocked = new RmAttributeName(@"MembershipLocked");
            /// <summary>
            /// Owner
            /// Owner
            /// </summary>
            public static RmAttributeName Owner = new RmAttributeName(@"Owner");
            /// <summary>
            /// Resource SID
            /// A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
            /// </summary>
            public static RmAttributeName ObjectSID = new RmAttributeName(@"ObjectSID");
            /// <summary>
            /// Scope
            /// Scope
            /// </summary>
            public static RmAttributeName Scope = new RmAttributeName(@"Scope");
            /// <summary>
            /// Temporal
            /// Defined by a filter that matches resources based on date and time attributes
            /// </summary>
            public static RmAttributeName Temporal = new RmAttributeName(@"Temporal");
            /// <summary>
            /// Type
            /// Type
            /// </summary>
            public static RmAttributeName Type = new RmAttributeName(@"Type");
        }

        #endregion

    }
}

