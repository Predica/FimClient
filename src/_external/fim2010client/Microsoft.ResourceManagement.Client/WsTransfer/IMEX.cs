using System.ServiceModel.Channels;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = Constants.WsTransfer.Namespace, ConfigurationName = Constants.WsTransfer.IMEX)]
    public interface IMEX {
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel = System.Net.Security.ProtectionLevel.None, Action = Constants.WsTransfer.GetAction, ReplyAction = Constants.WsTransfer.GetResponseAction)]
        Message Get(Message request);
    }
}
