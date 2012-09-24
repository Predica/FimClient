using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;
using System.IO;
using System.ServiceModel.Description;
using System.Xml;
using System.Reflection;

namespace Microsoft.ResourceManagement.Client.Test {

    /// <summary>
    /// Test that the FIM schema is read correctly.
    /// 
    /// Uses a schema read from file with a special test class:
    /// 
    /// SchemaTestResource
    ///   SchemaTestIntRange              : Integer, single, range = [-42,42]
    ///   SchemaTestIntMultiRange         : Integer, multi, range = [-42,42]
    ///   SchemaTestStringMultiValidation : String, multi, validation = [a-zA-Z][a-zA-Z0-9]{2,}
    ///   
    /// </summary>
    /// <remarks>
    /// Restrictions on integers are serialized in the schema, while string 
    /// validation regular expressions are not.
    /// </remarks>

    [TestClass]
    public class SchemaTest {

        public SchemaTest() {
        }

        public TestContext TestContext {
            get;
            set;
        }

        #region Get Schema from embedded resource

        private const string SchemaDialect = "http://www.w3.org/2001/XMLSchema";
        private const string SchemaResourceName = "Microsoft.ResourceManagement.Client.Test.fim-schema-test.xml";

        /// <summary>
        /// Gets the schema from an embedded resource.
        /// </summary>
        /// <returns></returns>
        private static XmlSchemaSet GetSchema() {
            Stream schemaStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SchemaResourceName);
            XmlTextReader xmlTextReader = new XmlTextReader(schemaStream);
            // create the XmlSchemaSet
            MetadataSet set = MetadataSet.ReadFrom(xmlTextReader);
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            foreach (MetadataSection section in set.MetadataSections) {
                if (section.Dialect.Equals(SchemaDialect) &&
                    section.Identifier.Equals(":")) {
                    XmlSchema schema = section.Metadata as System.Xml.Schema.XmlSchema;
                    if (schema != null) {
                        schemaSet.Add(schema);
                    }
                }
            }
            schemaSet.Compile();
            return schemaSet;
        }

        #endregion

        static RmFactory factory;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) {
            factory = new RmFactory(GetSchema());
        }

        #region MultiValue test

        [TestMethod]
        public void SchemaIsMultiValue01() {
            Assert.IsFalse(factory.IsMultiValued("Manager"));
        }

        [TestMethod]
        public void SchemaIsMultiValue02() {
            Assert.IsTrue(factory.IsMultiValued("ExpectedRulesList"));
        }

        [TestMethod]
        public void SchemaIsMultiValue03() {
            Assert.IsTrue(factory.IsMultiValued("SchemaTestIntMultiRange"));
        }

        public void SchemaIsMultiValue04() {
            Assert.IsTrue(factory.IsMultiValued("SchemaTestIntRange"));
        }

        #endregion

        [TestMethod]
        public void SchemaTypeString01() {
            Assert.AreEqual(RmFactory.RmAttributeType.String, factory.GetAttributeType("FirstName"));
        }

        [TestMethod]
        public void SchemaTypeString02() {
            Assert.AreEqual(RmFactory.RmAttributeType.String, factory.GetAttributeType("SchemaTestStringMultiValidation"));
        }

        [TestMethod]
        public void SchemaTypeInteger() {
            Assert.AreEqual(RmFactory.RmAttributeType.Integer, factory.GetAttributeType("IntegerMaximum"));
        }

        [TestMethod]
        public void SchemaTypeIntegerWithRestrictions() {
            Assert.AreEqual(RmFactory.RmAttributeType.Integer, factory.GetAttributeType("SchemaTestIntRange"));
        }

        [TestMethod]
        public void SchemaTypeBoolean() {
            Assert.AreEqual(RmFactory.RmAttributeType.Boolean, factory.GetAttributeType("Localizable"));
        }

        [TestMethod]
        public void SchemaTypeBinaryMulti() {
            Assert.AreEqual(RmFactory.RmAttributeType.Binary, factory.GetAttributeType("SIDHistory"));
            Assert.IsTrue(factory.IsMultiValued("SIDHistory"));
        }


    }
}
