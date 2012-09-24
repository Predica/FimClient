using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.Client.WsEnumeration;
using Microsoft.ResourceManagement.ObjectModel;
using System.Text;

namespace Microsoft.ResourceManagement.Client {

    /// <summary>
    /// This class constructs web service requests based on <see cref="RmResource"/> 
    /// and <see cref="RmResourceChanges"/> objects
    /// </summary>
    public class RmRequestFactory : RmFactory {

        // Attributes that cannot be set by the client.
        private Dictionary<string, bool> ProhibitedAttributes;

        /// <summary>
        /// Constructor.
        /// </summary>
        [Obsolete("The default constructor does not have schema information " +
            "and may incorrect deserialize objects. Use the constructor with " + 
            "the schema instead.")]
        public RmRequestFactory()
            : this(new XmlSchemaSet())
        {
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rmSchema">The FIM schema.</param>
        public RmRequestFactory(XmlSchemaSet rmSchema)
            : base(rmSchema)
        {
            this.ProhibitedAttributes = new Dictionary<string, bool>();

            // These are attributes which cannot be set by the client ever.
            this.ProhibitedAttributes.Add(@"ObjectID", true);
            // Need ObjectType for create and a client which changes it will get permission denied
            //this.ProhibitedAttributes.Add(@"ObjectType", true);
            this.ProhibitedAttributes.Add(@"Creator", true);
            this.ProhibitedAttributes.Add(@"CreatedTime", true);
            this.ProhibitedAttributes.Add(@"ExpectedRulesList", true);
            this.ProhibitedAttributes.Add(@"DetectedRulesList", true);
            this.ProhibitedAttributes.Add(@"DeletedTime", true);
            this.ProhibitedAttributes.Add(@"ResourceTime", true);
            this.ProhibitedAttributes.Add(@"ComputedMember", true);
            this.ProhibitedAttributes.Add(@"ComputedActor", true);
        }

        #region WS-Transfer

        /// <summary>
        /// Constructs a put request based on the changes tracked in the transaction.
        /// </summary>
        /// <param name="transaction">The transaction object which tracked the changes made to an object.</param>
        /// <returns></returns>
        public virtual PutRequest CreatePutRequest(RmResourceChanges transaction)
        {

            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }

            RmResource rmObject = transaction.RmObject;
            if (rmObject == null)
            {
                throw new InvalidOperationException("transaction does not have rmObject");
            }
            if (rmObject.ObjectID == null) {
                throw new InvalidOperationException("The rmObject does not have an ObjectID.");
            }
            lock (rmObject)
            {

                PutRequest putRequest = new PutRequest();

                putRequest.ResourceReferenceProperty = new ResourceReferenceProperty(rmObject.ObjectID.ToString());
                if (string.IsNullOrEmpty(rmObject.Locale) == false) 
                {
                    putRequest.ResourceLocaleProperty = new ResourceLocaleProperty(new System.Globalization.CultureInfo(rmObject.Locale));
                }

                putRequest.ModifyRequest = new ModifyRequest();

                IList<RmAttributeChange> changes = transaction.GetChanges();

                foreach (RmAttributeChange attributeChange in changes)
                {
                    if (this.ProhibitedAttributes.ContainsKey(attributeChange.Name.Name))
                        continue;

                    DirectoryAccessChange putReqChange = BuildDirectoryAccessChange(attributeChange);

                    if (base.IsMultiValued(attributeChange.Name))
                    {
                        putReqChange.Operation = attributeChange.Operation.ToString();
                    }
                    else
                    {
                        if (attributeChange.Operation == RmAttributeChangeOperation.Add)
                        {
                            putReqChange.Operation = RmAttributeChangeOperation.Replace.ToString();
                        }
                        else if (attributeChange.Operation == RmAttributeChangeOperation.Delete)
                        {
                            putReqChange.Operation = RmAttributeChangeOperation.Replace.ToString();
                            putReqChange.AttributeValue = null;
                        } else {
                            putReqChange.Operation = attributeChange.Operation.ToString();                            
                        }
                    }
                    putRequest.ModifyRequest.Changes.Add(putReqChange);
                }
                return putRequest;
            }
        }

        /// <summary>
        /// Constructs a create request based on the provided object.
        /// </summary>
        /// <param name="newResource">The RmResource object for which to construct a create request.</param>
        /// <returns></returns>
        public virtual CreateRequest CreateCreateRequest(RmResource newResource)
        {
            if (newResource == null)
            {
                throw new ArgumentNullException("newResource");
            }
            lock (newResource)
            {
                CreateRequest createRequest = new CreateRequest();

                createRequest.AddRequest = new AddRequest();
                createRequest.AddRequest.AttributeTypeAndValues = new List<DirectoryAccessChange>();
                foreach (KeyValuePair<RmAttributeName, RmAttributeValue> attribute in newResource.Attributes)
                {
                    if (this.ProhibitedAttributes.ContainsKey(attribute.Key.Name))
                        continue;

                    foreach (IComparable value in attribute.Value.Values)
                    {
                        DirectoryAccessChange createReqChange = BuildDirectoryAccessChange(attribute.Key, value);
                        // cannot specify the operation on create
                        createReqChange.Operation = null;
                        createRequest.AddRequest.AttributeTypeAndValues.Add(createReqChange);
                    }
                }
                return createRequest;
            }
        }

        public virtual DeleteRequest CreateDeleteRequest(RmReference objectId)
        {
            if (objectId == null)
            {
                throw new ArgumentNullException("objectId");
            }
            DeleteRequest deleteRequest = new DeleteRequest();
            deleteRequest.ResourceReferenceProperty = new ResourceReferenceProperty(objectId.Value);
            return deleteRequest;
        }

        public virtual GetRequest CreateGetRequest(RmReference objectId, CultureInfo culture, String[] attributes)
        {
            GetRequest request = new GetRequest();
            request.ResourceReferenceProperty = new ResourceReferenceProperty(objectId.Value);
            if (culture != null)
            {
                request.ResourceLocaleProperty = new ResourceLocaleProperty(culture);
            }
            if (attributes != null)
            {
                request.BaseObjectSearchRequest = new BaseObjectSearchRequest(attributes);
            }
            return request;
        }

        #endregion

        #region WS-Enumeration

        public virtual IEnumerable<RmResource> CreateEnumeration(WsEnumerationClient client, RmResourceFactory factory, String filter, String[] attributes)
        {
            return new EnumerationResultEnumerator(client, factory, filter, attributes);
        }

        #endregion

        DirectoryAccessChange BuildDirectoryAccessChange(RmAttributeChange attribute)
        {
            DirectoryAccessChange retReqChange = new DirectoryAccessChange();
            retReqChange.AttributeType = attribute.Name.Name;
            XmlElement attributeValueElem = base.RmDoc.CreateElement(retReqChange.AttributeType, RmNamespace);
            if (attribute.Value != null)
            {
                attributeValueElem.InnerText = attribute.Value.ToString();
            }
            retReqChange.AttributeValue.Values.Add(attributeValueElem);
            return retReqChange;
        }

        DirectoryAccessChange BuildDirectoryAccessChange(RmAttributeName name, IComparable value) {
            if (value == null) {
                throw new ArgumentNullException("name", string.Format("Attribute '{0}' is null.", name));
            }
            DirectoryAccessChange retReqChange = new DirectoryAccessChange();
            retReqChange.AttributeType = name.Name;
            XmlElement attributeValueElem = base.RmDoc.CreateElement(retReqChange.AttributeType, RmNamespace);
            attributeValueElem.InnerText = value.ToString();
            retReqChange.AttributeValue.Values.Add(attributeValueElem);
            return retReqChange;
        }
    }
}
