using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.Client.WsTrust
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = Constants.WsTrust.Namespace, ConfigurationName = Constants.WsTrust.SecurityTokenService)]
        public interface ISecurityTokenService
    {

        [System.ServiceModel.OperationContractAttribute(Action = Constants.WsTrust.RequestSecurityTokenIssueAction, ReplyAction = Constants.WsTrust.RequestSecurityTokenResponseIssueAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Microsoft.ResourceManagement.Client.Faults.RequestFailedFault), Action = Constants.WsTrust.RequestSecurityTokenResponseIssueAction, Name = "RequestFailed")]
        System.ServiceModel.Channels.Message RequestSecurityToken(System.ServiceModel.Channels.Message request);

        /*[System.ServiceModel.OperationContractAttribute(Action = Constants.WsTrust.RequestSecurityTokenIssueAction, ReplyAction = Constants.WsTrust.RequestSecurityTokenResponseIssueAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Microsoft.ResourceManagement.Client.Faults.RequestFailedFault), Action = Constants.WsTrust.RequestSecurityTokenResponseIssueAction, Name = "RequestFailed")]
        Microsoft.IdentityModel.Protocols.WSTrust.WSTrustMessage RequestSecurityTokenAsWSTrustMessage(Microsoft.IdentityModel.Protocols.WSTrust.WSTrustMessage request);
 */
        [System.ServiceModel.OperationContractAttribute(Action = Constants.WsTrust.RequestSecurityTokenResponseIssueAction, ReplyAction = Constants.WsTrust.RequestSecurityTokenResponseIssueAction)]
        [System.ServiceModel.FaultContractAttribute(typeof(Microsoft.ResourceManagement.Client.Faults.RequestFailedFault), Action = Constants.WsTrust.RequestSecurityTokenResponseIssueAction, Name = "RequestFailed")]
        System.ServiceModel.Channels.Message RequestSecurityTokenResponse(System.ServiceModel.Channels.Message request);
    }
}