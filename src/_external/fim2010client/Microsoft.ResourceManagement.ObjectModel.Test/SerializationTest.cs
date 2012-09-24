using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Microsoft.ResourceManagement.ObjectModel.Test {

    [TestClass]
    public class SerializationTest {

        public SerializationTest() {
        }

        public TestContext TestContext {
            get;
            set;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SerializeRmAttributeValueString01() {
            RmAttributeValue value = new RmAttributeValueSingle("test");
            string b64 = value.Base64StringSerialize();
            RmAttributeValue deserialized = b64.Base64StringDeserialize<RmAttributeValue>();
            Assert.IsNotNull(deserialized.Value);
            Assert.AreEqual(deserialized.Value, value.Value);
        }

        [TestMethod]
        public void SerializeRmAttributeValueNullableDateTime01() {
            DateTime? dt = null;
            RmAttributeValue value = new RmAttributeValueSingle(dt);
            string b64 = value.Base64StringSerialize();
            RmAttributeValue deserialized = b64.Base64StringDeserialize<RmAttributeValue>();
            Assert.IsNull(deserialized.Value);
        }

        [TestMethod]
        public void SerializeRmAttributeValueNullableDateTime02() {
            DateTime? dt = DateTime.Now;
            RmAttributeValue value = new RmAttributeValueSingle(dt);
            string b64 = value.Base64StringSerialize();
            RmAttributeValue deserialized = b64.Base64StringDeserialize<RmAttributeValue>();
            Assert.IsNotNull(deserialized.Value);
            Assert.IsFalse(value.IsMultiValue);
            Assert.AreEqual(deserialized.Value, value.Value);
        }

        [TestMethod]
        public void SerializeRmAttributeValueNullableDateTime03() {
            RmAttributeValue value = new RmAttributeValueMulti();
            value.Values.Add(DateTime.Now);
            value.Values.Add(null);
            value.Values.Add(DateTime.Now + TimeSpan.FromDays(1.0));
            string b64 = value.Base64StringSerialize();
            RmAttributeValue deserialized = b64.Base64StringDeserialize<RmAttributeValue>();
            Assert.IsNotNull(deserialized.Value);
            Assert.IsTrue(value.IsMultiValue);
            for (int i = 0; i < value.Values.Count; ++i) {
                Assert.AreEqual(deserialized.Values[i], value.Values[i]);
            }
        }

    }

    static class Helper {

        public static string Base64StringSerialize(this object value) {
            using (MemoryStream ms = new MemoryStream()) {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, value);
                return System.Convert.ToBase64String(ms.GetBuffer());
            }
        }

        public static T Base64StringDeserialize<T>(this string value) {
            using (MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(value), false)) {
                IFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }

    }

}
