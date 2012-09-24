using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {
    // should be WsEnumeration namespace
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace)]
    public class PullAdjustment {
        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public long StartingIndex;
        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public EnumerationDirection EnumerationDirection;
    }
}
