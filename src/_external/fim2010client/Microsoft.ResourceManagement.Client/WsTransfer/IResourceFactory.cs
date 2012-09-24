using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = Constants.WsTransfer.Namespace, ConfigurationName = Constants.WsTransfer.ResourceFactory)]
    public interface IResourceFactory {
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Action = Constants.WsTransfer.CreateAction, ReplyAction = Constants.WsTransfer.CreateResponseAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.InvalidRepresentationFault), Action = Constants.WsTransfer.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.InvalidRepresentation, Namespace = Constants.WsTransfer.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthenticationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthenticationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.AuthorizationRequiredFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.AuthorizationRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.CannotProcessFilter), Action = Constants.Wsman.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Wsman.CannotProcessFilter, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.CannotProcessFilter), Action = Constants.Wsman.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Wsman.DataRequiredFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.PermissionDeniedFault), Action = Constants.Rm.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Rm.PermissionDeniedFault, Namespace = Constants.Rm.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.EndpointUnavailable), Action = Constants.Addressing.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Addressing.EndpointUnavailable, Namespace = Constants.Addressing.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.UnwillingToPerformFault), Action = Constants.Imda.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Imda.UnwillingToPerform, Namespace = Constants.Imda.Namespace)]
        [System.ServiceModel.FaultContractAttribute(typeof(Faults.FragmentDialectNotSupported), Action = Constants.Wsman.Fault, ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Name = Constants.Wsman.FragmentDialectNotSupported, Namespace = Constants.Wsman.Namespace)]
        Message Create(Message request);
    }
}
