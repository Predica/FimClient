using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.ResourceManagement.WebServices.WSResourceManagement;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {
    
    /// <summary>
    /// Manual addition to the Request class.
    /// </summary>
    partial class RmRequest {

        /// <summary>
        /// Gets the request parameters as a list of <see cref="RequestParameter"/>
        /// objects.
        /// </summary>
        /// <returns></returns>
        public IList<RequestParameter> GetRequestParameters() {
            XmlSerializer serializer = new XmlSerializer(typeof(RequestParameter));
            List<RequestParameter> ret = new List<RequestParameter>();
            foreach (string value in this.RequestParameter) { 
                StringReader reader = new StringReader(value);
                RequestParameter parameter = serializer.Deserialize(reader) as RequestParameter;
                if (null != parameter) {
                    ret.Add(parameter);
                }
            }
            return ret;
        }

    }
}
