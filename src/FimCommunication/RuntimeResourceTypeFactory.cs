using System;
using Microsoft.ResourceManagement.Client;
using Microsoft.ResourceManagement.ObjectModel;
using System.Linq;
using Predica.FimCommunication.Errors;

namespace Predica.FimCommunication
{
    /// <summary>
    /// Scans loaded assemblies and finds matching resource types
    /// that inherit from <see cref="RmResource"/>
    /// ignoring 'Rm' prefix.
    /// </summary>
    public class RuntimeResourceTypeFactory : IResourceTypeFactory
    {
        private static volatile Type[] _resourceTypes;
        private static object _typesSyncRoot = new object();

        public RmResource CreateResource(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                return new RmResource();
            }

            if (_resourceTypes == null)
            {
                lock (_typesSyncRoot)
                {
                    if (_resourceTypes == null)
                    {
                        _resourceTypes = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => typeof(RmResource).IsAssignableFrom(x))
                            .ToArray();
                    }
                }
            }

            string comparableResourceType = resourceType.Replace('-', '_');

            var exactMatchingTypes = _resourceTypes
                .Where(x => x.Name.Equals(comparableResourceType, StringComparison.OrdinalIgnoreCase));

            var rmMatchingTypes = _resourceTypes
                .Where(x =>
                    x.Name.StartsWith("rm", StringComparison.OrdinalIgnoreCase)
                    && x.Name.Substring(2).Equals(comparableResourceType, StringComparison.OrdinalIgnoreCase)
                );

            var allMatchingTypes = exactMatchingTypes.Union(rmMatchingTypes)
                .ToList();

            if (allMatchingTypes.Count == 0)
            {
                return new RmResource();
            }
            if (allMatchingTypes.Count > 1)
            {
                throw new MultipleResourceTypesException(resourceType, allMatchingTypes.ToArray());
            }

            return (RmResource)Activator.CreateInstance(allMatchingTypes[0]);
        }
    }
}