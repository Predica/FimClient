using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsEnumeration {

    // PATCHED: added the class for XML message serialization
    /// <summary>
    /// EnumerationDetail
    /// </summary>
    [XmlRoot]
    public class EnumerationDetail {
        /// <summary>
        /// Total number of elements that matched the query in a PullResponse or 
        /// EnumerationResponse.
        /// </summary>
        [XmlElement()]
        public int Count;
    }

}
