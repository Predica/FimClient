using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.Client.Faults {
    [DataContract(Namespace = Constants.Rm.Namespace)]
    public class InvalidRepresentationFault// : System.ServiceModel.FaultException<InvalidRepresentationFault>
    {
        public InvalidRepresentationFault() {

        }
    }
}
