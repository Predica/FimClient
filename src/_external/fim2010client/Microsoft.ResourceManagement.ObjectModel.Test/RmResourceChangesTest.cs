using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;

namespace Microsoft.ResourceManagement.ObjectModel.Test {
    [TestClass]
    public class RmResourceChangesTest {

        public RmResourceChangesTest() {
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
        public void ManagerChange01() {
            RmReference manager1 = new RmReference("{54C0FFDB-548A-45df-A7A4-7386EE8120A7}");
            RmReference manager2 = new RmReference("{C4360DE1-C589-4444-B960-92930878A7AC}");
            RmPerson person = new RmPerson() {
                Manager = manager1
            };
            RmResourceChanges changes = new RmResourceChanges(person);
            changes.BeginChanges();
            person.Manager = manager2;
            var changesList = changes.GetChanges();

            Assert.AreEqual(1, changesList.Count);
            Assert.AreEqual(RmAttributeChangeOperation.Replace, changesList[0].Operation);
            Assert.AreEqual(manager2, changesList[0].Value);
        }

        [TestMethod]
        public void FirstNameChange01() {
            string before = "Before";
            string after = "After";
            RmPerson person = new RmPerson() {
                FirstName = before
            };
            RmResourceChanges changes = new RmResourceChanges(person);
            changes.BeginChanges();
            person.FirstName = after;
            var changesList = changes.GetChanges();

            Assert.AreEqual(1, changesList.Count);
            Assert.AreEqual(RmAttributeChangeOperation.Replace, changesList[0].Operation);
            Assert.AreEqual(after, changesList[0].Value);
        }

        [TestMethod]
        public void AddAlias01() {
#if _
            RmPerson person = new RmPerson();
            person.MailAliases.Add("one");
            person.MailAliases.Add("two");
            RmResourceChanges changes = new RmResourceChanges(person);
            changes.BeginChanges();
            person.MailAliases.Add("three");
            var changesList = changes.GetChanges();
            Assert.AreEqual(1, changesList.Count);
            Assert.AreEqual(RmAttributeChangeOperation.Add, changesList[0].Operation);
            Assert.AreEqual("three", changesList[0].Value);
#endif
        }

        [TestMethod]
        public void RemoveAlias01() {
#if _
            RmPerson person = new RmPerson();
            person.MailAliases.Add("one");
            person.MailAliases.Add("two");
            RmResourceChanges changes = new RmResourceChanges(person);
            changes.BeginChanges();
            person.MailAliases.Remove("two");
            var changesList = changes.GetChanges();
            Assert.AreEqual(1, changesList.Count);
            Assert.AreEqual(RmAttributeChangeOperation.Delete, changesList[0].Operation);
            Assert.AreEqual("two", changesList[0].Value);
#endif
        }

        [TestMethod]
        public void AddRemoveAlias01() {
#if _
            RmPerson person = new RmPerson();
            person.MailAliases.Add("one");
            person.MailAliases.Add("two");
            RmResourceChanges changes = new RmResourceChanges(person);
            changes.BeginChanges();
            person.MailAliases.Remove("two");
            person.MailAliases.Add("three");
            var changesList = changes.GetChanges();
            Assert.AreEqual(2, changesList.Count);
            Assert.AreEqual(RmAttributeChangeOperation.Add, changesList[0].Operation);
            Assert.AreEqual("three", changesList[0].Value);
            Assert.AreEqual(RmAttributeChangeOperation.Delete, changesList[1].Operation);
            Assert.AreEqual("two", changesList[1].Value);
#endif
        }


    }
}
