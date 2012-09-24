using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {

    // PATCHED: added the EnumerationDetail element and the Count property.
    [XmlRoot(Namespace = Constants.WsEnumeration.Namespace)]
    public class EnumerateResponse : PullResponse {

        /// <summary>
        /// EnumerationDetail element.
        /// </summary>
        [XmlElement(Namespace = Constants.Rm.Namespace)]
        public EnumerationDetail EnumerationDetail;

        /// <summary>
        /// Total number of elements that matched the query. Returns null if the
        /// EnumerationDetail element is not present (IncludeCount header not
        /// specified in the request).
        /// </summary>
        [XmlIgnore()]
        public int? Count {
            get {
                if (null == EnumerationDetail) {
                    return null;
                } else {
                    return EnumerationDetail.Count;
                }
            }
        }

    }
}
