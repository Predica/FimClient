using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.ResourceManagement.ObjectModel;
using Predica.FimCommunication.Import;
using Xunit;

namespace Predica.FimCommunication.Tests.Import
{
    public class XmlImporterTests
    {
        private XmlImporter _importer;

        public XmlImporterTests()
        {
            _importer = new XmlImporter();
        }

        private Stream OpenStream()
        {
            string resourceName = "Predica.FimCommunication.Tests.Import.exported-users.xml";

            return Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resourceName);
        }

        private ImportResult PerformImport()
        {
            using (var stream = OpenStream())
            {
                return _importer.Import(stream);
            }
        }

        [Fact]
        public void imports_exported_users()
        {
            var result = PerformImport();

            Assert.Equal(5, result.PrimaryImportObjects.Count());

            Assert.Equal("[x [x [x", result.PrimaryImportObjects.First()
                .Attributes.Single(x => x.Key.Name == "City")
                .Value.Value);
            Assert.Equal("Administrator", result.PrimaryImportObjects
                .Last().Attributes.Single(x => x.Key.Name == "AccountName")
                .Value.Value);
        }

        [Fact]
        public void detects_references()
        {
            var user = PerformImport().PrimaryImportObjects.First();

            Assert.IsType<RmReference>(user["Creator"].Value);
        }

        [Fact]
        public void imports_all_exported_objects_including_references()
        {
            var result = PerformImport();

            Assert.Equal(8, result.AllImportedObjects.Count());

            Assert.Equal("Person", result.AllImportedObjects.Skip(0).First().ObjectType);
            Assert.Equal("DomainConfiguration", result.AllImportedObjects.Skip(1).First().ObjectType);
            Assert.Equal("qfOuAssignement", result.AllImportedObjects.Skip(2).First().ObjectType);
            Assert.Equal("Person", result.AllImportedObjects.Skip(3).First().ObjectType);
            Assert.Equal("Person", result.AllImportedObjects.Skip(4).First().ObjectType);
            Assert.Equal("qfOuAssignement", result.AllImportedObjects.Skip(5).First().ObjectType);
            Assert.Equal("Person", result.AllImportedObjects.Skip(6).First().ObjectType);
            Assert.Equal("Person", result.AllImportedObjects.Skip(7).First().ObjectType);
        }
    }
}