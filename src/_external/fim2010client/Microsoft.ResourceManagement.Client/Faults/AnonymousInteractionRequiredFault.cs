using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.ResourceManagement.Client.Faults {

    [DataContract(Namespace = Constants.Rm.Namespace)]
    public class AnonymousInteractionRequiredFault {

        public AnonymousInteractionRequiredFault() {
        }

        [DataMember()]
        InteractiveWorkflowAddress EndpointAddresses;

        [DataContract(Namespace = Constants.Rm.Namespace)]
        class InteractiveWorkflowAddress {

            [DataMember(Order = 1)]
            public string InstanceId;

            [DataMember(Order = 2)]
            public EndpointAddressesCollection EndpointAddresses;

        }

        [CollectionDataContract(Namespace = Constants.Rm.Namespace)]
        class EndpointAddressesCollection : List<string> {
        }

        /// <summary>
        /// Gets the address of the endpoint to be used for further 
        /// communication with the server.
        /// </summary>
        public string AnonymousInteractionEndpointAddress {
            get {
                if (EndpointAddresses == null) {
                    // this should never happen.
                    throw new Exception("Could not deserialize InteractiveWorkflowAddress in AnonymousInteractionRequiredFault.");
                }
                if (EndpointAddresses.EndpointAddresses == null || EndpointAddresses.EndpointAddresses.Count == 0) {
                    // this should never happen.
                    throw new Exception("Could not deserialize EndpointAddresses in AnonymousInteractionRequiredFault.");
                }
                return EndpointAddresses.EndpointAddresses[0];
            }
        }

    }

}
