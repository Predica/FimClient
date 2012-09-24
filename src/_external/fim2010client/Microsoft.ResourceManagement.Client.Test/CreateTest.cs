using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.Client.WsEnumeration;
using System.Xml.Schema;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Microsoft.ResourceManagement.ObjectModel;
using System.Net;
using System.Configuration;

namespace Microsoft.ResourceManagement.Client.Test {

    [TestClass]
    public class CreateTest {
        public CreateTest() {
        }

        public TestContext TestContext {
            get;
            set;
        }

        static WsTransferFactoryClient transferFactoryClient;
        static WsEnumerationClient enumerationClient;
        static WsTransferClient transferClient;
        static MexClient mexClient;
        static XmlSchemaSet schema;
        static RmResourceFactory resourceFactory;
        static RmRequestFactory requestFactory;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            NetworkCredential credential = GetCredential();
            transferFactoryClient = new WsTransferFactoryClient();
            transferFactoryClient.ClientCredentials.Windows.ClientCredential = credential;

            enumerationClient = new WsEnumerationClient();
            enumerationClient.ClientCredentials.Windows.ClientCredential = credential;

            transferClient = new WsTransferClient();
            transferClient.ClientCredentials.Windows.ClientCredential = credential;

            mexClient = new MexClient();
            schema = mexClient.Get();
            resourceFactory = new RmResourceFactory(schema);
            requestFactory = new RmRequestFactory(schema);
        }

        static NetworkCredential GetCredential() {
            string fimUser = ConfigurationManager.AppSettings["fimUser"];
            string fimDomain = ConfigurationManager.AppSettings["fimDomain"];
            string fimPwd = ConfigurationManager.AppSettings["fimPwd"];
            return new NetworkCredential(fimUser, fimPwd, fimDomain);
        }

        [ClassCleanup()]
        public static void MyClassCleanup() {
        }

        #region Utilities

        private static RmReference CreateResource(RmResource resource) {
            CreateRequest createRequest = requestFactory.CreateCreateRequest(resource);
            CreateResponse createResponse = transferFactoryClient.Create(createRequest);
            RmReference reference = new RmReference(createResponse.ResourceCreated.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value);
            return reference;
        }

        private static RmResource GetResource(RmReference reference) {
            GetRequest getRequest = requestFactory.CreateGetRequest(reference, null, null);
            GetResponse getResponse = transferClient.Get(getRequest);
            return resourceFactory.CreateResource(getResponse);
        }

        private static void DeleteResource(RmReference reference) {
            DeleteRequest deleteRequest = requestFactory.CreateDeleteRequest(reference);
            DeleteResponse deleteResponse = transferClient.Delete(deleteRequest);
        }

        private static void ModifyResource(RmResourceChanges changes) {
            PutRequest putRequest = requestFactory.CreatePutRequest(changes);
            PutResponse putResponse = transferClient.Put(putRequest);
        }

        #endregion

        [TestMethod]
        public void CreatePerson() {

            RmPerson person = new RmPerson() { 
                FirstName = "John",
                LastName = "Doe",
                DisplayName = "John Doe",
                Domain = "QF",
                AccountName = "jdoe",
                MailNickname = "john.doe",
            };

            RmReference reference = CreateResource(person);
            RmPerson queried = GetResource(reference) as RmPerson;
            DeleteResource(reference);

            Assert.IsNotNull(queried);
            Assert.AreEqual(person.FirstName, queried.FirstName);
            Assert.AreEqual(person.LastName, queried.LastName);
            Assert.AreEqual(person.DisplayName, queried.DisplayName);
            Assert.AreEqual(person.Domain, queried.Domain);
            Assert.AreEqual(person.AccountName, queried.AccountName);
            Assert.AreEqual(person.MailNickname, queried.MailNickname);

            Assert.IsFalse(person["Manager"].IsMultiValue);
            Assert.IsFalse(queried["Manager"].IsMultiValue);
        }

        [TestMethod]
        public void ModifyPerson() {

            RmPerson manager1 = new RmPerson() {
                FirstName = "John",
                LastName = "Doe",
                DisplayName = "John Doe",
                Domain = "QF",
                AccountName = "jdoe1",
                MailNickname = "john.doe"
            };
            RmPerson manager2 = new RmPerson() {
                FirstName = "Jack",
                LastName = "Doe",
                DisplayName = "Jack Doe",
                Domain = "QF",
                AccountName = "jdoe2",
                MailNickname = "jack.doe"
            };

            RmReference refMgr1 = CreateResource(manager1);
            RmReference refMgr2 = CreateResource(manager2);

            RmPerson employee = new RmPerson() {
                FirstName = "Jack",
                LastName = "Frost",
                DisplayName = "Jack Frost",
                Domain = "QF",
                AccountName = "jfrost",
                MailNickname = "jack.frost",
                Manager = refMgr1
            };

            RmReference refEmp = CreateResource(employee);
            employee.ObjectID = refEmp;
            RmPerson getEmp1 = GetResource(refEmp) as RmPerson;

            RmResourceChanges changes = new RmResourceChanges(employee);
            changes.BeginChanges();
            employee.Manager = refMgr2;
            ModifyResource(changes);
            changes.AcceptChanges();

            RmPerson getEmp2 = GetResource(refEmp) as RmPerson;

            DeleteResource(refMgr1);
            DeleteResource(refMgr2);
            DeleteResource(refEmp);

            Assert.IsNotNull(getEmp1);
            Assert.IsNotNull(getEmp2);
            Assert.AreEqual(refMgr1, getEmp1.Manager);
            Assert.AreEqual(refMgr2, getEmp2.Manager);
        }
    }
}