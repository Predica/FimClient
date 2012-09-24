using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class AuthenticationChallengeResponse
    {
        [XmlElement (ElementName="Response")]
        public Response response;

        public AuthenticationChallengeResponse()
        {
            this.response = new Response();
        }

        public AuthenticationChallengeResponse(Dictionary<int,String> answers)
        {
            this.response = new Response(answers);
        }
    }


}
