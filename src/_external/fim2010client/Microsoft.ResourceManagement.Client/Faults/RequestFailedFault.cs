using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.ResourceManagement.Client.Faults
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestFailedFault",Namespace="http://schemas.datacontract.org/2004/07/Microsoft.ResourceManagement.WebServices." +
        "WSTrust")]
    public partial class RequestFailedFault : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
    }
}
