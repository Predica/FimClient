using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.ResourceManagement.Automation.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel;
using NLog;

namespace Predica.FimCommunication.Import
{
    public interface IXmlImporter
    {
        ImportResult Import(Stream inputStream);
    }

    public class XmlImporter : IXmlImporter
    {
        public ImportResult Import(Stream inputStream)
        {
            _log.Debug("Import started");

            var root = new XmlRootAttribute("Results");
            var serializer = new XmlSerializer(typeof(ExportObject[]), root);

            var deserialized = (ExportObject[])serializer.Deserialize(inputStream);

            _log.Debug("Imported {0} objects", deserialized.Length);

            if (deserialized.Length == 0)
            {
                return new ImportResult(Enumerable.Empty<RmResource>(), Enumerable.Empty<RmResource>());
            }

            string primaryObjectsType = deserialized[0].ResourceManagementObject.ObjectType;

            _log.Debug("Detected {0} as primary import type", primaryObjectsType);

            var allImportedObjects = deserialized.Select(x => ConvertToResource(x))
                .ToList();
            var primaryObjects = allImportedObjects.Where(x => x.ObjectType == primaryObjectsType)
                .ToList();

            _log.Debug("Imported {0} primary objects", primaryObjects.Count);

            return new ImportResult(primaryObjects, allImportedObjects);
        }

        private RmResource ConvertToResource(ExportObject exportObject)
        {
            var sourceObject = exportObject.ResourceManagementObject;

            var resource = new RmResource();
            resource.ObjectType = sourceObject.ObjectType;

            foreach (var attribute in sourceObject.ResourceManagementAttributes)
            {
                var rmAttributeName = new RmAttributeName(attribute.AttributeName);
                var rmAttributeValue = attribute.IsMultiValue
                    ? (RmAttributeValue)new RmAttributeValueMulti(attribute.Values)
                    : (RmAttributeValue)new RmAttributeValueSingle(attribute.Value)
                ;

                if (rmAttributeValue.Value is string)
                {
                    string s = (string)rmAttributeValue.Value;
                    if (s.StartsWith("urn:uuid:"))
                    {
                        rmAttributeValue.Value = new RmReference(s);
                    }
                }

                if (resource.ContainsKey(rmAttributeName))
                {
                    resource[rmAttributeName] = rmAttributeValue;
                }
                else
                {
                    resource.Add(rmAttributeName, rmAttributeValue);
                }
            }

            return resource;
        }

        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
    }
}