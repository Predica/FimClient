using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.ResourceManagement.Client.Faults
{
    [XmlRoot(Namespace = Constants.Rm.Namespace)]
    [DataContract(Namespace=Constants.Rm.Namespace)]
    public class AuthenticationRequiredFault
    {
        [XmlElement()]
        [DataMember()]
        public string SecurityTokenServiceAddress;

        [XmlElement()]
        [DataMember()]
        public bool? UserRegistered;

        [XmlElement()]
        [DataMember()]
        public bool? UserLockedOut;

        [XmlElement()]
        [DataMember()]
        public String ContextIdentifier;

    }
}
