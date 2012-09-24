using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ResourceManagement.Client.WsTrust;

namespace Microsoft.ResourceManagement.Client
{
    public delegate Dictionary<int,String> QAGateQuestionsHandler(WorkflowAuthenticationChallenge authenticationChallenge);
}
