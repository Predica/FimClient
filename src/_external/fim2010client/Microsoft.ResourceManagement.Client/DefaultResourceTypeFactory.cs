using System;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;

namespace Microsoft.ResourceManagement.Client {
    public class DefaultResourceTypeFactory : IResourceTypeFactory {

        public virtual RmResource CreateResource(string resourceType) {
            if (String.IsNullOrEmpty(resourceType)) {
                return new RmResource();
            }
            String upperCaseResourceType = resourceType.ToUpperInvariant();
            switch (upperCaseResourceType) {
            case @"ACTIVITYINFORMATIONCONFIGURATION":
                return new RmActivityInformationConfiguration();
            case @"APPROVAL":
                return new RmApproval();
            case @"APPROVALRESPONSE":
                return new RmApprovalResponse();
            case @"ATTRIBUTETYPEDESCRIPTION":
                return new RmAttributeTypeDescription();
            case @"BINDINGDESCRIPTION":
                return new RmBindingDescription();
            case @"DETECTEDRULEENTRY":
                return new RmDetectedRuleEntry();
            case @"DOMAINCONFIGURATION":
                return new RmDomainConfiguration();
            case @"EXPECTEDRULEENTRY":
                return new RmExpectedRuleEntry();
            case @"GROUP":
                return new RmGroup();
            case @"OBJECTTYPEDESCRIPTION":
                return new RmObjectTypeDescription();
            case @"PERSON":
                return new RmPerson();
            case @"REQUEST":
                return new RmRequest();
            case @"SET":
                return new RmSet();
            default:
                return new RmResource();
            }
        }

    }
}
