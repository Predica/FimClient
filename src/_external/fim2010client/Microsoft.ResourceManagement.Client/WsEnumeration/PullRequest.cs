using System;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace, ElementName = Constants.WsEnumeration.Pull)]
    public class PullRequest {
        public PullRequest() {
            this.MaxCharacters = Constants.WsEnumeration.DefaultMaxCharacters;
            this.MaxElements = Constants.WsEnumeration.DefaultMaxElements;
        }

        [XmlElement()]
        public EnumerationContext EnumerationContext;

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public Int32 MaxElements;

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public Int32 MaxCharacters;

        [XmlElement(Namespace = Constants.WsEnumeration.Namespace)]
        public PullAdjustment PullAdjustment;

    }
}
