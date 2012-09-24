using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    [XmlRoot()]
    public class Response
    {
        [XmlElement (Namespace ="",ElementName="WorkflowAuthenticationResponse")]
        public WorkflowAuthenticationResponse workflowAuthenticationResponse;

        public Response()
        {
            this.workflowAuthenticationResponse = new WorkflowAuthenticationResponse();
        }

        public Response(Dictionary<int, String> answers)
        {
            this.workflowAuthenticationResponse = new WorkflowAuthenticationResponse(answers);
        }
    }

}
