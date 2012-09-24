using System;

using Microsoft.ResourceManagement.ObjectModel;

namespace Microsoft.ResourceManagement.Client
{
    public interface IResourceTypeFactory
    {
        /// <summary>
        /// Returns a new strongly-typed resource based on the resource type name.
        /// 
        /// If a strongly-typed RmResource is not available, a generic RmResource is returned instead.
        /// </summary>
        /// <param name="resourceType">The resource type name.  "Group" or "Person" for example.</param>
        /// <returns>A new resource that is strongly typed.</returns>
        RmResource CreateResource(String resourceType);
    }
}
