using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.Client.Faults {
    [DataContract(Namespace = Constants.Rm.Namespace)]
    public class FragmentDialectNotSupported// : System.ServiceModel.FaultException<FragmentDialectNotSupported>
    {
        public FragmentDialectNotSupported() {

        }
    }
}
