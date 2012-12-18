using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.ResourceManagement.ObjectModel;
using Predica.FimCommunication.Export;
using Xunit;

namespace Predica.FimCommunication.Tests.Export
{
    public class XmlExporterTests
        : FimIntegrationTestBase
    {
        private XmlExporter _exporter;

        public XmlExporterTests()
        {
            _exporter = new XmlExporter();
        }

        [Fact]
        public void can_contact_fim_during_export___should_detect_problems_with_incorrect_versions_of_referenced_dlls()
        {
            var person = _client.EnumerateAll<RmResource>("/Person").First();

            using (var stream = new MemoryStream())
            {
                _exporter.WriteXml(stream, "/*[ObjectID='{0}']".FormatWith(person.ObjectID.Value));
                stream.Seek(0, SeekOrigin.Begin);

                var doc = XDocument.Load(stream);

                Assert.Equal("Results", doc.Root.Name);

                Assert.True(doc.Root.Elements().Count() > 0);
            }
        }

        [Fact(Skip = "specific dev-enviroment test only; requires local FIM to contain user with given ID and 2 references set")]
        public void can_write_exported_object_to_xml()
        {
            using (var stream = new MemoryStream())
            {
                _exporter.WriteXml(stream, "/*[ObjectID='5a668487-35dd-41ca-9610-bd1c11da4a00']");
                stream.Seek(0, SeekOrigin.Begin);

                var doc = XDocument.Load(stream);

                Assert.Equal("Results", doc.Root.Name);
                // 3 = 1 user + 2 references
                Assert.Equal(3, doc.Root.Elements().Count());
            }
        }
    }
}