using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class WorkflowAuthenticationResponse
    {

        private String responseDataEncoded;

        [XmlElement()]
        public String data
        {
            get
            {
                return responseDataEncoded;
            }
            set
            {
                responseDataEncoded = value;
            }
        }
        public WorkflowAuthenticationResponse(Dictionary<int, String> answers)
        {

            responseDataEncoded = ChallengeResponseHelper.BuildResponseData(answers);
        }
        public WorkflowAuthenticationResponse()
        {
        }
    }
    

}
