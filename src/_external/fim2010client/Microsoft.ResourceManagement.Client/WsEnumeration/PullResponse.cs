using System;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {

    /// <summary>
    /// PullResponse
    /// </summary>
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace)]
    public class PullResponse {
        [XmlElement()]
        public EnumerationContext EnumerationContext;

        [XmlElement()]
        public PullItem Items;

        [XmlElement()]
        public String EndOfSequence;

        [XmlIgnore()]
        public bool IsEndOfSequence {
            get {
                return EndOfSequence != null;
            }
        }

    }
}
