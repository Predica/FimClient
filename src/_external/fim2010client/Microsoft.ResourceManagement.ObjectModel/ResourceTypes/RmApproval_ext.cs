using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.ObjectModel.ResourceTypes {

    /// <summary>
    /// Manual addition to the Approval class.
    /// </summary>
    public partial class RmApproval {

        /// <summary>
        /// Gets the approval endpoint address.
        /// </summary>
        /// <returns></returns>
        public string ApprovalEndpointAddress {
            get {
                // note that the http protocol is second in the list behind the mail 
                // listener's endpoint
                if (null == EndpointAddress) {
                    // this can happen if the object was retrieved with a query that
                    // was specifying the parameters list excluding the EndpointAddress
                    // attribute.
                    throw new InvalidOperationException("The Approval object contains no endpoint information.");
                }
                if (2 != EndpointAddress.Count) {
                    // this should never happen
                    throw new InvalidOperationException(string.Format(
                        "The Approval object contains {0} endpoints instead of 2.",
                        EndpointAddress.Count));
                }
                string endpointAddress = EndpointAddress[1];
                if (!endpointAddress.StartsWith("http://")) {
                    // this should never happen
                    throw new InvalidOperationException(string.Format(
                        "The endpoint address '{0}' does not specify the http protocol.",
                        EndpointAddress.Count));
                }
                return endpointAddress;
            }
        }

    }
}
