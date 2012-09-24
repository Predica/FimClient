using System;

namespace Microsoft.ResourceManagement.Client {
    /// <summary>
    /// This class stores all of the strings needed in the client.
    /// </summary>
    internal class Constants {
        private Constants() { }

        internal class Endpoint {
            private Endpoint() { }
            public const String Resource = "ResourceManagementService/Resource";
            public const String ResourceFactory = "ResourceManagementService/ResourceFactory";
            public const String Enumeration = "ResourceManagementService/Enumeration";
            public const String Alternate = "ResourceManagementService/Alternate";
        }

        public enum Endpoints {
            Resource,
            ResourceFactory,
            Enumeration,
            Alternate,
        }

        internal class Addressing {
            private Addressing() { }
            public const String Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing";
            public const String Prefix = "wsa";
            public const String Fault = "http://www.w3.org/2005/08/addressing/fault";

            public const String EndpointUnavailable = "EndpointUnavailable";
            public const String ReferenceProperties = "ReferenceProperties";
            public const String EndpointAddress = "EndpointAddress";
            public const String Address = "Address";
        }

        internal class Soap {
            private Soap() { }
            public const String Namespace = "http://www.w3.org/2003/05/soap-envelope";
            public const String Prefix = "s";

        }

        internal class Xsi {
            private Xsi() { }
            public const String Nil = "nil";
            public const String Namespace = "http://www.w3.org/2001/XMLSchema-instance";
            public const String Prefix = "xsi";
        }

        internal class Xsd {
            private Xsd() { }

            public const String Namespace = "http://www.w3.org/2001/XMLSchema";
            public const String Prefix = "xsd";
        }

        internal class Dialect {
            private Dialect() { }

            public const String IdmXpathFilter = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";
            public const String IdmAttributeType = "http://schemas.microsoft.com/2006/11/ResourceManagement/Dialect/IdentityAttributeType-20080602";
        }

        internal class WsTransfer {
            private WsTransfer() { }

            public const String Namespace = "http://http://scheams.xmlsoap.org/ws/2004/09/transfer";
            public const String Prefix = "wxf";
            public const String Fault = "http://schemas.xmlsoap.org/ws/2004/09/transfer/fault";

            public const String CreateAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Create";
            public const String CreateResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/CreateResponse";
            public const String DeleteAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Delete";
            public const String DeleteResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/DeleteResponse";
            public const String GetAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get";
            public const String GetResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/GetResponse";
            public const String PutAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Put";
            public const String PutResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/transfer/PutResponse";


            public const String Alternate = "Alternate";
            public const String Resource = "Resource";
            public const String ResourceFactory = "ResourceFactory";
            public const String IMEX = "IMEX";
            public const String ResourceCreated = "ResourceCreated";

        }

        internal class WsEnumeration {
            private WsEnumeration() { }

            public const String Namespace = "http://schemas.xmlsoap.org/ws/2004/09/enumeration";
            public const String Prefix = "wsen";
            public const String Fault = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/fault";

            public const String EnumerateAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Enumerate";
            public const String EnumerateResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/EnumerateResponse";
            public const String GetStatusAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/GetStatus";
            public const String GetStatusResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/GetStatusResponse";
            public const String PullAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Pull";
            public const String PullResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/PullResponse";
            public const String ReleaseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Release";
            public const String ReleaseResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/ReleaseResponse";
            public const String RenewAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Renew";
            public const String RenewResponseAction = "http://schemas.xmlsoap.org/ws/2004/09/enumeration/RenewResponse";

            public const String Enumerate = "Enumerate";
            public const String Pull = "Pull";
            public const String Filter = "Filter";

            public const Int32 DefaultMaxCharacters = 3668672;
            public const Int32 DefaultMaxElements = 20;
        }

        internal class Imda {
            private Imda() { }

            public const String Namespace = "http://schemas.microsoft.com/2006/11/IdentityManagement/DirectoryAccess";
            public const String Prefix = "ida";
            public const String Fault = "http://schemas.microsoft.com/2006/11/IdentityManagement/DirectoryAccess/fault";

            public const String ExtensionHeaderName = "IdentityManagementOperation";

            public const String BaseObjectSearchRequest = "BaseObjectSearchRequest";
            public const String BaseObjectSearchResponse = "BaseObjectSearchResponse";
            public const String Dialect = "Dialect";
            public const String Operation = "Operation";
            public const String Change = "Change";
            public const String AttributeTypeAndValue = "AttributeTypeAndValue";
            public const String AttributeTypes = "AttributeTypes";
            public const String ModifyRequest = "ModifyRequest";
            public const String AddRequest = "AddRequest";
            public const String PartialAttribute = "PartialAttribute";

            public const String UnwillingToPerform = "UnwillingToPerform";
        }
        internal class Rm {
            private Rm() { }

            public const String Namespace = "http://schemas.microsoft.com/2006/11/ResourceManagement";
            public const String Prefix = "rm";
            public const String Fault = "http://schemas.microsoft.com/2006/11/ResourceManagement/fault";

            public const String PermissionHints = "permissions";
            public const String ResourceReferenceProperty = "ResourceReferenceProperty";
            public const String ResourceTimeProperty = "Time";
            public const String ResourceLocaleProperty = "Locale";
            public const String InvalidRepresentation = "InvalidRepresentation";

            public const String AuthorizationRequiredFault = "AuthorizationRequiredFault";
            public const String PermissionDeniedFault = "PermissionDeniedFault";
            public const String AuthenticationRequiredFault = "AuthenticationRequiredFault";
            public const String AnonymousInteractionRequiredFault = "AnonymousInteractionRequiredFault";

        }

        internal class Wsman {
            private Wsman() { }

            public const String Namespace = "http://schemas.dmtf.org/wbem/wsman/1/wsman.xsd";
            public const String Prefix = "wsman";
            public const String Fault = "http://schemas.dmtf.org/wbem/wsman/1/wsman/fault";

            public const String DataRequiredFault = "DataRequiredFault";
            public const String CannotProcessFilter = "CannotProcessFilter";
            public const String FragmentDialectNotSupported = "FragmentDialectNotSupported";
        }

        internal class WsTrust {
            private WsTrust() { }

            public const String Namespace = "http://schemas.xmlsoap.org/ws/2005/02/trust";
            public const String Prefix = "wst";
            public const String Fault = "http://schemas.xmlsoap.org/ws/2005/02/trust";

            public const String SecurityTokenService = "SecurityTokenService";
            public const String RequestSecurityToken = "RequestSecurityToken";
            public const String RequestSecurityTokenResponse = "RequestSecurityTokenResponse";
            public const String RequestFailed = "RequestFailed";

            public const String RequestSecurityTokenIssueAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";
            public const String RequestSecurityTokenResponseIssueAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue";
        }

        internal class WsPolicy {
            private WsPolicy() { }

            public const String Namespace = "http://schemas.xmlsoap.org/ws/2004/09/policy";
            public const String Prefix = "wsp";
            public const String Fault = "http://schemas.xmlsoap.org/ws/2004/09/policy/fault";
        }
    }
}
