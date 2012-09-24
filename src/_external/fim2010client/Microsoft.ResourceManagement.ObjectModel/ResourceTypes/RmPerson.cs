using System;
using System.Collections.Generic;
using Microsoft.ResourceManagement.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes
{

    /// <summary>
    /// Person resource.
    /// Automatically generated on 06/30/2010 10:08:20
    /// </summary>
    [Serializable]
    public partial class RmPerson : RmResource
    {

        /// <summary>
        /// The type of the wrapped resource.
        /// </summary>
        protected const String ResourceType = @"Person";

        /// <summary>
        /// Gets the FIM name of the wrapped resource type.
        /// </summary>
        /// <returns>The FIM name of the wrapped resource type.</returns>
        public override string GetResourceType()
        {
            return ResourceType;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RmPerson()
            : base()
        {
        }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        protected RmPerson(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        #region promoted properties


        /// <summary>
        /// Account Name
        /// User's log on name
        /// </summary>
        public string AccountName
        {
            get { return GetString(AttributeNames.AccountName); }
            set { base[AttributeNames.AccountName].Value = value; }
        }

        /// <summary>
        /// AD User Cannot Change Password
        /// Will sync from AD to track whether the user is locked out from changing their AD password
        /// </summary>
        public bool? AD_UserCannotChangePassword
        {
            get { return GetNullable<bool>(AttributeNames.AD_UserCannotChangePassword); }
            set { SetNullable(AttributeNames.AD_UserCannotChangePassword, value); }
        }

        /// <summary>
        /// Address
        /// Address
        /// </summary>
        public string Address
        {
            get { return GetString(AttributeNames.Address); }
            set { base[AttributeNames.Address].Value = value; }
        }

        /// <summary>
        /// Assistant
        /// Assistant
        /// </summary>
        public RmReference Assistant
        {
            get { return GetReference(AttributeNames.Assistant); }
            set { base[AttributeNames.Assistant].Value = value; }
        }

        RmList<RmReference> _authNWFLockedOut;

        /// <summary>
        /// AuthN Workflow Locked Out
        /// This is the list of AuthN Processes a user is locked out of
        /// </summary>
        public IList<RmReference> AuthNWFLockedOut
        {
            get
            {
                if (_authNWFLockedOut == null)
                {
                    lock (base.attributes)
                    {
                        _authNWFLockedOut = GetMultiValuedReference(AttributeNames.AuthNWFLockedOut);
                    }
                }
                return _authNWFLockedOut;
            }
        }

        RmList<RmReference> _authNWFRegistered;

        /// <summary>
        /// AuthN Workflow Registered
        /// This is the list of AuthN Processes a user is registered for
        /// </summary>
        public IList<RmReference> AuthNWFRegistered
        {
            get
            {
                if (_authNWFRegistered == null)
                {
                    lock (base.attributes)
                    {
                        _authNWFRegistered = GetMultiValuedReference(AttributeNames.AuthNWFRegistered);
                    }
                }
                return _authNWFRegistered;
            }
        }

        /// <summary>
        /// City
        /// City
        /// </summary>
        public string City
        {
            get { return GetString(AttributeNames.City); }
            set { base[AttributeNames.City].Value = value; }
        }

        /// <summary>
        /// Company
        /// Company
        /// </summary>
        public string Company
        {
            get { return GetString(AttributeNames.Company); }
            set { base[AttributeNames.Company].Value = value; }
        }

        /// <summary>
        /// Cost Center
        /// CostCenter
        /// </summary>
        public string CostCenter
        {
            get { return GetString(AttributeNames.CostCenter); }
            set { base[AttributeNames.CostCenter].Value = value; }
        }

        /// <summary>
        /// Cost Center Name
        /// CostCenterName
        /// </summary>
        public string CostCenterName
        {
            get { return GetString(AttributeNames.CostCenterName); }
            set { base[AttributeNames.CostCenterName].Value = value; }
        }

        /// <summary>
        /// Country/Region
        /// Country
        /// </summary>
        public string Country
        {
            get { return GetString(AttributeNames.Country); }
            set { base[AttributeNames.Country].Value = value; }
        }

        /// <summary>
        /// Department
        /// Department
        /// </summary>
        public string Department
        {
            get { return GetString(AttributeNames.Department); }
            set { base[AttributeNames.Department].Value = value; }
        }

        /// <summary>
        /// Domain
        /// Choose the domain where you want to create the user account for this user
        /// </summary>
        public string Domain
        {
            get { return GetString(AttributeNames.Domain); }
            set { base[AttributeNames.Domain].Value = value; }
        }

        /// <summary>
        /// Domain Configuration
        /// A reference to a the parent Domain resource for this resource.
        /// </summary>
        public RmReference DomainConfiguration
        {
            get { return GetReference(AttributeNames.DomainConfiguration); }
            set { base[AttributeNames.DomainConfiguration].Value = value; }
        }

        /// <summary>
        /// E-mail
        /// Primary e-mail address for the user
        /// </summary>
        public string Email
        {
            get { return GetString(AttributeNames.Email); }
            set { base[AttributeNames.Email].Value = value; }
        }

        /// <summary>
        /// E-mail Alias
        /// E-mail alias. It is used to create the e-mail address
        /// </summary>
        public string MailNickname
        {
            get { return GetString(AttributeNames.MailNickname); }
            set { base[AttributeNames.MailNickname].Value = value; }
        }

        /// <summary>
        /// Employee End Date
        /// EmployeeEndDate
        /// </summary>
        public DateTime? EmployeeEndDate
        {
            get { return GetNullable<DateTime>(AttributeNames.EmployeeEndDate); }
            set { SetNullable(AttributeNames.EmployeeEndDate, value); }
        }

        /// <summary>
        /// Employee ID
        /// EmployeeID
        /// </summary>
        public string EmployeeID
        {
            get { return GetString(AttributeNames.EmployeeID); }
            set { base[AttributeNames.EmployeeID].Value = value; }
        }

        /// <summary>
        /// Employee Start Date
        /// EmployeeStartDate
        /// </summary>
        public DateTime? EmployeeStartDate
        {
            get { return GetNullable<DateTime>(AttributeNames.EmployeeStartDate); }
            set { SetNullable(AttributeNames.EmployeeStartDate, value); }
        }

        /// <summary>
        /// Employee Type
        /// EmployeeType
        /// </summary>
        public string EmployeeType
        {
            get { return GetString(AttributeNames.EmployeeType); }
            set { base[AttributeNames.EmployeeType].Value = value; }
        }

        /// <summary>
        /// Fax
        /// OfficeFax
        /// </summary>
        public string OfficeFax
        {
            get { return GetString(AttributeNames.OfficeFax); }
            set { base[AttributeNames.OfficeFax].Value = value; }
        }

        /// <summary>
        /// First Name
        /// FirstName
        /// </summary>
        public string FirstName
        {
            get { return GetString(AttributeNames.FirstName); }
            set { base[AttributeNames.FirstName].Value = value; }
        }

        /// <summary>
        /// Freeze Count
        /// FreezeCount
        /// </summary>
        public int? FreezeCount
        {
            get { return GetNullable<int>(AttributeNames.FreezeCount); }
            set { SetNullable(AttributeNames.FreezeCount, value); }
        }

        /// <summary>
        /// Freeze Level
        /// Tracks the number of times the user has unsuccessfully attempted to run an AuthN WF
        /// </summary>
        public string FreezeLevel
        {
            get { return GetString(AttributeNames.FreezeLevel); }
            set { base[AttributeNames.FreezeLevel].Value = value; }
        }

        /// <summary>
        /// Job Title
        /// JobTitle
        /// </summary>
        public string JobTitle
        {
            get { return GetString(AttributeNames.JobTitle); }
            set { base[AttributeNames.JobTitle].Value = value; }
        }

        /// <summary>
        /// Last Name
        /// LastName
        /// </summary>
        public string LastName
        {
            get { return GetString(AttributeNames.LastName); }
            set { base[AttributeNames.LastName].Value = value; }
        }

        /// <summary>
        /// Last Reset Attempt Time
        /// LastResetAttemptTime
        /// </summary>
        public DateTime? LastResetAttemptTime
        {
            get { return GetNullable<DateTime>(AttributeNames.LastResetAttemptTime); }
            set { SetNullable(AttributeNames.LastResetAttemptTime, value); }
        }

        RmList<RmReference> _authNLockoutRegistrationID;

        /// <summary>
        /// Lockout Gate Registration Data Ids
        /// This is the list of gate registration ids used by the lockout gate
        /// </summary>
        public IList<RmReference> AuthNLockoutRegistrationID
        {
            get
            {
                if (_authNLockoutRegistrationID == null)
                {
                    lock (base.attributes)
                    {
                        _authNLockoutRegistrationID = GetMultiValuedReference(AttributeNames.AuthNLockoutRegistrationID);
                    }
                }
                return _authNLockoutRegistrationID;
            }
        }

        /// <summary>
        /// Login Name
        /// This is a combination for domain/Alias
        /// </summary>
        public string LoginName
        {
            get { return GetString(AttributeNames.LoginName); }
            set { base[AttributeNames.LoginName].Value = value; }
        }

        /// <summary>
        /// Manager
        /// Manager
        /// </summary>
        public RmReference Manager
        {
            get { return GetReference(AttributeNames.Manager); }
            set { base[AttributeNames.Manager].Value = value; }
        }

        /// <summary>
        /// Middle Name
        /// MiddleName
        /// </summary>
        public string MiddleName
        {
            get { return GetString(AttributeNames.MiddleName); }
            set { base[AttributeNames.MiddleName].Value = value; }
        }

        /// <summary>
        /// Mobile Phone
        /// MobilePhone
        /// </summary>
        public string MobilePhone
        {
            get { return GetString(AttributeNames.MobilePhone); }
            set { base[AttributeNames.MobilePhone].Value = value; }
        }

        /// <summary>
        /// Office Location
        /// OfficeLocation
        /// </summary>
        public string OfficeLocation
        {
            get { return GetString(AttributeNames.OfficeLocation); }
            set { base[AttributeNames.OfficeLocation].Value = value; }
        }

        /// <summary>
        /// Office Phone
        /// OfficePhone
        /// </summary>
        public string OfficePhone
        {
            get { return GetString(AttributeNames.OfficePhone); }
            set { base[AttributeNames.OfficePhone].Value = value; }
        }

        /// <summary>
        /// Photo
        /// Photo
        /// </summary>
        public int? Photo
        {
            get { return GetNullable<int>(AttributeNames.Photo); }
            set { SetNullable(AttributeNames.Photo, value); }
        }

        /// <summary>
        /// Postal Code
        /// PostalCode
        /// </summary>
        public string PostalCode
        {
            get { return GetString(AttributeNames.PostalCode); }
            set { base[AttributeNames.PostalCode].Value = value; }
        }

        RmList<string> _proxyAddressCollection;

        /// <summary>
        /// Proxy Address Collection
        /// ProxyAddressCollection
        /// </summary>
        public IList<string> ProxyAddressCollection
        {
            get
            {
                if (_proxyAddressCollection == null)
                {
                    lock (base.attributes)
                    {
                        _proxyAddressCollection = GetMultiValuedString(AttributeNames.ProxyAddressCollection);
                    }
                }
                return _proxyAddressCollection;
            }
        }

        /// <summary>
        /// RAS Access Permission
        /// IsRASEnabled
        /// </summary>
        public bool? IsRASEnabled
        {
            get { return GetNullable<bool>(AttributeNames.IsRASEnabled); }
            set { SetNullable(AttributeNames.IsRASEnabled, value); }
        }

        /// <summary>
        /// Register
        /// Register
        /// </summary>
        public bool? Register
        {
            get { return GetNullable<bool>(AttributeNames.Register); }
            set { SetNullable(AttributeNames.Register, value); }
        }

        /// <summary>
        /// Registration Required
        /// Tracks if the user must register for SSPR
        /// </summary>
        public bool? RegistrationRequired
        {
            get { return GetNullable<bool>(AttributeNames.RegistrationRequired); }
            set { SetNullable(AttributeNames.RegistrationRequired, value); }
        }

        /// <summary>
        /// Reset Password
        /// This attribute is used to trigger a password reset process.
        /// </summary>
        public string ResetPassword
        {
            get { return GetString(AttributeNames.ResetPassword); }
            set { base[AttributeNames.ResetPassword].Value = value; }
        }

        /// <summary>
        /// Resource SID
        /// A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
        /// </summary>
        public int? ObjectSID
        {
            get { return GetNullable<int>(AttributeNames.ObjectSID); }
            set { SetNullable(AttributeNames.ObjectSID, value); }
        }

        /// <summary>
        /// Time Zone
        /// Reference to timezone configuration
        /// </summary>
        public RmReference TimeZone
        {
            get { return GetReference(AttributeNames.TimeZone); }
            set { base[AttributeNames.TimeZone].Value = value; }
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Ensures all attributes exist.
        /// </summary>
        protected override void EnsureSpecificAttributesExist()
        {
            EnsureAttributeExists(AttributeNames.AccountName, false);
            EnsureAttributeExists(AttributeNames.AD_UserCannotChangePassword, false);
            EnsureAttributeExists(AttributeNames.Address, false);
            EnsureAttributeExists(AttributeNames.Assistant, false);
            EnsureAttributeExists(AttributeNames.AuthNWFLockedOut, true);
            EnsureAttributeExists(AttributeNames.AuthNWFRegistered, true);
            EnsureAttributeExists(AttributeNames.City, false);
            EnsureAttributeExists(AttributeNames.Company, false);
            EnsureAttributeExists(AttributeNames.CostCenter, false);
            EnsureAttributeExists(AttributeNames.CostCenterName, false);
            EnsureAttributeExists(AttributeNames.Country, false);
            EnsureAttributeExists(AttributeNames.Department, false);
            EnsureAttributeExists(AttributeNames.Domain, false);
            EnsureAttributeExists(AttributeNames.DomainConfiguration, false);
            EnsureAttributeExists(AttributeNames.Email, false);
            EnsureAttributeExists(AttributeNames.MailNickname, false);
            EnsureAttributeExists(AttributeNames.EmployeeEndDate, false);
            EnsureAttributeExists(AttributeNames.EmployeeID, false);
            EnsureAttributeExists(AttributeNames.EmployeeStartDate, false);
            EnsureAttributeExists(AttributeNames.EmployeeType, false);
            EnsureAttributeExists(AttributeNames.OfficeFax, false);
            EnsureAttributeExists(AttributeNames.FirstName, false);
            EnsureAttributeExists(AttributeNames.FreezeCount, false);
            EnsureAttributeExists(AttributeNames.FreezeLevel, false);
            EnsureAttributeExists(AttributeNames.JobTitle, false);
            EnsureAttributeExists(AttributeNames.LastName, false);
            EnsureAttributeExists(AttributeNames.LastResetAttemptTime, false);
            EnsureAttributeExists(AttributeNames.AuthNLockoutRegistrationID, true);
            EnsureAttributeExists(AttributeNames.LoginName, false);
            EnsureAttributeExists(AttributeNames.Manager, false);
            EnsureAttributeExists(AttributeNames.MiddleName, false);
            EnsureAttributeExists(AttributeNames.MobilePhone, false);
            EnsureAttributeExists(AttributeNames.OfficeLocation, false);
            EnsureAttributeExists(AttributeNames.OfficePhone, false);
            EnsureAttributeExists(AttributeNames.Photo, false);
            EnsureAttributeExists(AttributeNames.PostalCode, false);
            EnsureAttributeExists(AttributeNames.ProxyAddressCollection, true);
            EnsureAttributeExists(AttributeNames.IsRASEnabled, false);
            EnsureAttributeExists(AttributeNames.Register, false);
            EnsureAttributeExists(AttributeNames.RegistrationRequired, false);
            EnsureAttributeExists(AttributeNames.ResetPassword, false);
            EnsureAttributeExists(AttributeNames.ObjectSID, false);
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
        /// Names of Person specific attributes
        /// </summary>
        public sealed new partial class AttributeNames
        {
            /// <summary>
            /// Account Name
            /// User's log on name
            /// </summary>
            public static RmAttributeName AccountName = new RmAttributeName(@"AccountName");
            /// <summary>
            /// AD User Cannot Change Password
            /// Will sync from AD to track whether the user is locked out from changing their AD password
            /// </summary>
            public static RmAttributeName AD_UserCannotChangePassword = new RmAttributeName(@"AD_UserCannotChangePassword");
            /// <summary>
            /// Address
            /// Address
            /// </summary>
            public static RmAttributeName Address = new RmAttributeName(@"Address");
            /// <summary>
            /// Assistant
            /// Assistant
            /// </summary>
            public static RmAttributeName Assistant = new RmAttributeName(@"Assistant");
            /// <summary>
            /// AuthN Workflow Locked Out
            /// This is the list of AuthN Processes a user is locked out of
            /// </summary>
            public static RmAttributeName AuthNWFLockedOut = new RmAttributeName(@"AuthNWFLockedOut");
            /// <summary>
            /// AuthN Workflow Registered
            /// This is the list of AuthN Processes a user is registered for
            /// </summary>
            public static RmAttributeName AuthNWFRegistered = new RmAttributeName(@"AuthNWFRegistered");
            /// <summary>
            /// City
            /// City
            /// </summary>
            public static RmAttributeName City = new RmAttributeName(@"City");
            /// <summary>
            /// Company
            /// Company
            /// </summary>
            public static RmAttributeName Company = new RmAttributeName(@"Company");
            /// <summary>
            /// Cost Center
            /// CostCenter
            /// </summary>
            public static RmAttributeName CostCenter = new RmAttributeName(@"CostCenter");
            /// <summary>
            /// Cost Center Name
            /// CostCenterName
            /// </summary>
            public static RmAttributeName CostCenterName = new RmAttributeName(@"CostCenterName");
            /// <summary>
            /// Country/Region
            /// Country
            /// </summary>
            public static RmAttributeName Country = new RmAttributeName(@"Country");
            /// <summary>
            /// Department
            /// Department
            /// </summary>
            public static RmAttributeName Department = new RmAttributeName(@"Department");
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
            /// Employee End Date
            /// EmployeeEndDate
            /// </summary>
            public static RmAttributeName EmployeeEndDate = new RmAttributeName(@"EmployeeEndDate");
            /// <summary>
            /// Employee ID
            /// EmployeeID
            /// </summary>
            public static RmAttributeName EmployeeID = new RmAttributeName(@"EmployeeID");
            /// <summary>
            /// Employee Start Date
            /// EmployeeStartDate
            /// </summary>
            public static RmAttributeName EmployeeStartDate = new RmAttributeName(@"EmployeeStartDate");
            /// <summary>
            /// Employee Type
            /// EmployeeType
            /// </summary>
            public static RmAttributeName EmployeeType = new RmAttributeName(@"EmployeeType");
            /// <summary>
            /// Fax
            /// OfficeFax
            /// </summary>
            public static RmAttributeName OfficeFax = new RmAttributeName(@"OfficeFax");
            /// <summary>
            /// First Name
            /// FirstName
            /// </summary>
            public static RmAttributeName FirstName = new RmAttributeName(@"FirstName");
            /// <summary>
            /// Freeze Count
            /// FreezeCount
            /// </summary>
            public static RmAttributeName FreezeCount = new RmAttributeName(@"FreezeCount");
            /// <summary>
            /// Freeze Level
            /// Tracks the number of times the user has unsuccessfully attempted to run an AuthN WF
            /// </summary>
            public static RmAttributeName FreezeLevel = new RmAttributeName(@"FreezeLevel");
            /// <summary>
            /// Job Title
            /// JobTitle
            /// </summary>
            public static RmAttributeName JobTitle = new RmAttributeName(@"JobTitle");
            /// <summary>
            /// Last Name
            /// LastName
            /// </summary>
            public static RmAttributeName LastName = new RmAttributeName(@"LastName");
            /// <summary>
            /// Last Reset Attempt Time
            /// LastResetAttemptTime
            /// </summary>
            public static RmAttributeName LastResetAttemptTime = new RmAttributeName(@"LastResetAttemptTime");
            /// <summary>
            /// Lockout Gate Registration Data Ids
            /// This is the list of gate registration ids used by the lockout gate
            /// </summary>
            public static RmAttributeName AuthNLockoutRegistrationID = new RmAttributeName(@"AuthNLockoutRegistrationID");
            /// <summary>
            /// Login Name
            /// This is a combination for domain/Alias
            /// </summary>
            public static RmAttributeName LoginName = new RmAttributeName(@"LoginName");
            /// <summary>
            /// Manager
            /// Manager
            /// </summary>
            public static RmAttributeName Manager = new RmAttributeName(@"Manager");
            /// <summary>
            /// Middle Name
            /// MiddleName
            /// </summary>
            public static RmAttributeName MiddleName = new RmAttributeName(@"MiddleName");
            /// <summary>
            /// Mobile Phone
            /// MobilePhone
            /// </summary>
            public static RmAttributeName MobilePhone = new RmAttributeName(@"MobilePhone");
            /// <summary>
            /// Office Location
            /// OfficeLocation
            /// </summary>
            public static RmAttributeName OfficeLocation = new RmAttributeName(@"OfficeLocation");
            /// <summary>
            /// Office Phone
            /// OfficePhone
            /// </summary>
            public static RmAttributeName OfficePhone = new RmAttributeName(@"OfficePhone");
            /// <summary>
            /// Photo
            /// Photo
            /// </summary>
            public static RmAttributeName Photo = new RmAttributeName(@"Photo");
            /// <summary>
            /// Postal Code
            /// PostalCode
            /// </summary>
            public static RmAttributeName PostalCode = new RmAttributeName(@"PostalCode");
            /// <summary>
            /// Proxy Address Collection
            /// ProxyAddressCollection
            /// </summary>
            public static RmAttributeName ProxyAddressCollection = new RmAttributeName(@"ProxyAddressCollection");
            /// <summary>
            /// RAS Access Permission
            /// IsRASEnabled
            /// </summary>
            public static RmAttributeName IsRASEnabled = new RmAttributeName(@"IsRASEnabled");
            /// <summary>
            /// Register
            /// Register
            /// </summary>
            public static RmAttributeName Register = new RmAttributeName(@"Register");
            /// <summary>
            /// Registration Required
            /// Tracks if the user must register for SSPR
            /// </summary>
            public static RmAttributeName RegistrationRequired = new RmAttributeName(@"RegistrationRequired");
            /// <summary>
            /// Reset Password
            /// This attribute is used to trigger a password reset process.
            /// </summary>
            public static RmAttributeName ResetPassword = new RmAttributeName(@"ResetPassword");
            /// <summary>
            /// Resource SID
            /// A binary value that specifies the security identifier (SID) of the user. The SID is a unique value used to identify the user as a security principal.
            /// </summary>
            public static RmAttributeName ObjectSID = new RmAttributeName(@"ObjectSID");
            /// <summary>
            /// Time Zone
            /// Reference to timezone configuration
            /// </summary>
            public static RmAttributeName TimeZone = new RmAttributeName(@"TimeZone");
        }

        #endregion

    }
}

