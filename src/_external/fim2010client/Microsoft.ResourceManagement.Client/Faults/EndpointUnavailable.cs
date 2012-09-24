using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.Client.Faults {
    [DataContract(Namespace = Constants.Rm.Namespace)]
    public class EndpointUnavailable// : System.ServiceModel.FaultException<EndpointUnavailable>
    {
        public EndpointUnavailable() {

        }
    }
}
