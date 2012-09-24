using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.ResourceManagement.ObjectModel.Test {

    [TestClass]
    public class RmAttributeValueTest {

        public RmAttributeValueTest() {
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
        public void IsMultiValue01() {
            RmAttributeValue value = new RmAttributeValueSingle();
            Assert.IsFalse(value.IsMultiValue);
        }

        [TestMethod]
        public void IsMultiValue02() {
            RmAttributeValue value = new RmAttributeValueSingle();
            value.Value = "one";
            Assert.IsFalse(value.IsMultiValue);
        }

        [TestMethod]
        public void IsMultiValue03() {
            RmAttributeValue value = new RmAttributeValueMulti();
            value.Values.AddRange(new string[] { "one", "two" });
            Assert.IsTrue(value.IsMultiValue);
        }

        [TestMethod]
        public void IsMultiValue04() {
            RmAttributeValue value = new RmAttributeValueMulti(new string[] { "one" });
            Assert.IsTrue(value.IsMultiValue);
        }

        [TestMethod]
        public void IsMultiValue05() {
            RmAttributeValue value = new RmAttributeValueSingle();
            value.Value = "one";
            value.Value = "two";
            Assert.IsFalse(value.IsMultiValue);
        }

        [TestMethod]
        public void Value01() {
            RmAttributeValue value = new RmAttributeValueSingle();
            Assert.IsNull(value.Value);
        }

        [TestMethod]
        public void Value02() {
            RmAttributeValue value = new RmAttributeValueSingle();
            value.Value = null;
            Assert.IsNull(value.Value);
        }

        [TestMethod]
        public void Value03() {
            RmAttributeValue value = new RmAttributeValueSingle();
            value.Value = 1;
            Assert.IsNotNull(value.Value);
            Assert.AreEqual(value.Value, 1);
        }

        [TestMethod]
        public void Value04() {
            RmAttributeValue value = new RmAttributeValueSingle();
            value.Value = 1;
            value.Value = 2;
            Assert.IsNotNull(value.Value);
            Assert.AreEqual(value.Value, 2);
        }

        [TestMethod]
        public void MultiValue01() {
            RmAttributeValue value = new RmAttributeValueMulti( new string[] {"one"} );
            value.Values.Add("two");
            Assert.AreEqual(value.Values.Count, 2);
        }

    }
}
