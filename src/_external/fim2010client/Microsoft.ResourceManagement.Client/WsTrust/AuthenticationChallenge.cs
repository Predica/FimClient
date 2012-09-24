using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.ResourceManagement.Client.WsTrust
{
    public class AuthenticationChallenge
    {
        [XmlElement (ElementName="Challenge")]
        public Challenge challenge;
    }
}
