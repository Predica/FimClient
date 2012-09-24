using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    [XmlRoot()]
    public class Challenge
    {
        [XmlElement (Namespace ="",ElementName="WorkflowAuthenticationChallenge")]
        public WorkflowAuthenticationChallenge workflowAuthChallenge;
    }
}
