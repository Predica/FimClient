using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.ResourceManagement.Client.WsTransfer;

namespace Microsoft.ResourceManagement.Client.Faults {
    [DataContract(Namespace = Constants.Rm.Namespace)]
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    public class AuthorizationRequiredFault {
        public AuthorizationRequiredFault() {

        }
        [XmlElement()]
        [DataMember()]
        public EndpointReference EndpointReference;
    }
}
