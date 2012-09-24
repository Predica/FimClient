using System.ServiceModel;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [MessageContract(IsWrapped = false)]
    public class ImdaRequest : TransferRequest {
    }
}
