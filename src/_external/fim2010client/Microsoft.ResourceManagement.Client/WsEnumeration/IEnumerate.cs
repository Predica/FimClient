using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = Constants.WsEnumeration.Namespace, ConfigurationName = Constants.WsEnumeration.Enumerate)]
    public interface IEnumerate {
        [System.ServiceModel.OperationContractAttribute(Action = Constants.WsEnumeration.EnumerateAction, ReplyAction = Constants.WsEnumeration.EnumerateResponseAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthenticationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthenticationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthorizationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthorizationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.PermissionDeniedFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.PermissionDeniedFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.UnsupportedExpiration), Action = Constants.WsEnumeration.Fault, Name = "UnsupportedExpirationType")]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.CannotProcessFilter), Action = Constants.WsEnumeration.Fault, Name = "CannotProcessFilter")]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.EndpointUnavailable), Action = Constants.Addressing.Fault, Name = "EndpointUnavailable", Namespace = Constants.Addressing.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.FilterDialectRequestedUnavailable), Action = Constants.WsEnumeration.Fault, Name = "FilterDialectRequestedUnavailable")]
        // PATCHED: added this FaultContractAttribute
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.UnwillingToPerformFault), Action = Constants.Imda.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Imda.UnwillingToPerform, Namespace = Constants.Imda.Namespace)]
        Message Enumerate(Message request);

        [System.ServiceModel.OperationContractAttribute(Action = Constants.WsEnumeration.PullAction, ReplyAction = Constants.WsEnumeration.PullResponseAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthenticationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthenticationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthorizationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthorizationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.PermissionDeniedFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.PermissionDeniedFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.InvalidEnumerationContext), Action = Constants.WsEnumeration.Fault, Name = "InvalidEnumerationContext")]
        Message Pull(Message request);
    }
}
