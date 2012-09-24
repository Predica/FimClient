using System;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTransfer {
    [XmlRoot(Namespace = Constants.Addressing.Namespace)]
    public class EndpointReference {
        [XmlElement(Namespace = Constants.Addressing.Namespace)]
        public String Address;

        //[XmlElement(Namespace = Constants.Addressing.Namespace)]
        [XmlIgnore()]
        public ReferenceProperties ReferenceProperties;

    }
}
