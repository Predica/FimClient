using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.ResourceManagement.Automation;
using Microsoft.ResourceManagement.Automation.ObjectModel;
using NLog;

namespace Predica.FimCommunication.Export
{
    public interface IXmlExporter
    {
        void WriteXml(Stream stream, string xpath);
    }

    public class XmlExporter : IXmlExporter
    {
        /// <summary>
        /// Uses logic from ConvertFrom-FIMResource cmdlet to fetch export objects
        /// and xml-serializes them to a given stream
        /// </summary>
        public void WriteXml(Stream stream, string xpath)
        {
            _log.Debug("Fetching export objects for query {0}", xpath);

            string url = ConfigurationManager.AppSettings["fimServiceBaseUrl"];

            var exportConfig = new ExportConfig
            {
                CustomConfig = new[] { xpath },
                Uri = url,
            };

            var results = exportConfig.Invoke<ExportObject>()
                .ToList();

            _log.Debug("Fetched {0} export objects for query {1}", results.Count, xpath);

            // code copied from ConvertFrom-FIMResource cmdlet
            var root = new XmlRootAttribute("Results");
            var serializer = new XmlSerializer(typeof(ExportObject[]), root);
            serializer.Serialize(stream, results.ToArray());
        }

        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
    }
}