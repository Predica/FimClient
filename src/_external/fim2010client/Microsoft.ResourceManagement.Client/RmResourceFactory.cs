using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using Microsoft.ResourceManagement.Client.WsEnumeration;
using Microsoft.ResourceManagement.Client.WsTransfer;
using Microsoft.ResourceManagement.ObjectModel;

namespace Microsoft.ResourceManagement.Client {
    /// <summary>
    /// This class constructs RmResource objects from web service request and response messages.
    /// </summary>
    public class RmResourceFactory : RmFactory {
        IResourceTypeFactory resourceTypeFactory;

        const String ObjectType = @"ObjectType";
        const String ObjectID = @"ObjectID";

        public RmResourceFactory()
            : this(new XmlSchemaSet()) { }
        public RmResourceFactory(XmlSchemaSet rmSchema)
            : this(rmSchema, new DefaultResourceTypeFactory()) {

        }

        public RmResourceFactory(XmlSchemaSet rmSchema, IResourceTypeFactory resourceTypeFactory)
            : base(rmSchema) {
            if (resourceTypeFactory == null) {
                throw new ArgumentNullException("resourceTypeFactory");
            }
            this.resourceTypeFactory = resourceTypeFactory;
        }
        /// <summary>
        /// Returns a generic RmResource object from the getResponse object.
        /// </summary>
        /// <param name="getResponse">The get response from the server.</param>
        /// <returns>The RmResource object with the attributes returned in getResponse.</returns>
        public RmResource CreateResource(GetResponse getResponse) {
            if (getResponse == null) {
                throw new ArgumentNullException("getResponse");
            }
            if (getResponse.BaseObjectSearchResponse == null) {
                throw new ArgumentNullException("getResponse.BaseObjectSearchResponse");
            }
            lock (getResponse) {
                // look ahead for the type
                String objectType = null;
                foreach (PartialAttributeType partialAttribute in getResponse.BaseObjectSearchResponse.PartialAttributes) {
                    if (partialAttribute.Values.Count > 0) {
                        String localName = partialAttribute.Values[0].LocalName;
                        if (String.IsNullOrEmpty(localName)) {
                            continue;
                        }
                        if (localName.Equals(ObjectType)) {
                            objectType = partialAttribute.Values[0].InnerText;
                            break;
                        }

                    }
                }

                if (objectType == null) {
                    objectType = string.Empty;
                }

                RmResource rmResource = this.resourceTypeFactory.CreateResource(objectType);

                // fill in the attribute values
                foreach (PartialAttributeType partialAttribute in getResponse.BaseObjectSearchResponse.PartialAttributes) {
                    RmAttributeName attributeName = null;
                    RmAttributeValue newAttribute = null;
                    if (partialAttribute.Values.Count > 0) {
                        String localName = partialAttribute.Values[0].LocalName;
                        if (String.IsNullOrEmpty(localName)) {
                            continue;
                        } else {
                            attributeName = new RmAttributeName(localName);
                        }
                    } else {
                        continue;
                    }

                    if (rmResource.TryGetValue(attributeName, out newAttribute) == false) {
                        newAttribute = CreateRmAttributeValue(attributeName);
                        // PATCHED: the following line was missing
                        rmResource[attributeName] = newAttribute;
                    }

                    // add values to the typed list
                    foreach (XmlNode value in partialAttribute.Values) {
                        IComparable newValue = this.ConstructAttributeValue(attributeName, value.InnerText);
                        if (base.IsMultiValued(attributeName) == false)
                            newAttribute.Values.Clear();
                        if (attributeName.Name.Equals(ObjectType) || attributeName.Name.Equals(ObjectID))
                            newAttribute.Values.Clear();

                        newAttribute.Values.Add(newValue);
                    }
                }
                return rmResource;
            }
        }

        /// <summary>
        /// Creates a list of resources based on the pull or enumerate response.
        /// </summary>
        /// <param name="pullOrEnumerateResponse">The pull or enumerate response to use when creating resources.</param>
        /// <returns>The list of strongly-typed resources in the pull or enumerate response.</returns>
        public List<RmResource> CreateResource(PullResponse pullOrEnumerateResponse) {
            if (pullOrEnumerateResponse == null) {
                throw new ArgumentNullException("pullOrEnumerateResponse");
            }
            if (pullOrEnumerateResponse.Items == null || pullOrEnumerateResponse.Items.Values == null) {
                return new List<RmResource>();
            }
            lock (pullOrEnumerateResponse) {
                List<RmResource> retList = new List<RmResource>();

                foreach (XmlNode obj in pullOrEnumerateResponse.Items.Values) {
                    // look ahead for the type info;
                    String objectType = null;
                    foreach (XmlNode child in obj.ChildNodes) {
                        if (child.NodeType == XmlNodeType.Element) {
                            if (child.LocalName.Equals(@"ObjectType")) {
                                objectType = child.InnerText;
                                break;
                            }
                        }
                    }
                    if (objectType == null) {
                        objectType = String.Empty;
                    }

                    RmResource rmResource = this.resourceTypeFactory.CreateResource(objectType);

                    // now add the attributes to the resource object
                    foreach (XmlNode child in obj.ChildNodes) {
                        if (child.NodeType == XmlNodeType.Element) {
                            RmAttributeName attributeName = new RmAttributeName(child.LocalName);
                            IComparable attributeValue = this.ConstructAttributeValue(attributeName, child.InnerText);
                            if (attributeValue == null)
                                continue;

                            RmAttributeValue newAttribute = null;
                            if (rmResource.TryGetValue(attributeName, out newAttribute) == false) {
                                newAttribute = CreateRmAttributeValue(attributeName);
                                rmResource[attributeName] = newAttribute;
                            }
                            if (base.IsMultiValued(attributeName) == false)
                                newAttribute.Values.Clear();
                            if (attributeName.Name.Equals(ObjectType) || attributeName.Name.Equals(ObjectID))
                                newAttribute.Values.Clear();
                            newAttribute.Values.Add(attributeValue);
                        }
                    }
                    retList.Add(rmResource);
                }

                return retList;
            }
        }

        protected IComparable ConstructAttributeValue(RmAttributeName attributeName, String innerText) {
            if (innerText == null)
                return null;
            RmAttributeInfo info = null;
            if (base.RmAttributeCache.TryGetValue(attributeName, out info) == false) {
                // just in case they forget to load schema... we know that ObjectId must remove the uuid reference
                if (attributeName.Name.Equals(ObjectID)) {
                    return new RmReference(innerText);
                } else {
                    return innerText;
                }
            }

            try {
                switch (info.AttributeType) {
                case RmAttributeType.String:
                    return innerText;
                case RmAttributeType.DateTime:
                    return DateTime.Parse(innerText);
                case RmAttributeType.Integer:
                    return Int32.Parse(innerText);
                case RmAttributeType.Reference:
                    return new RmReference(innerText);
                case RmAttributeType.Binary:
                    return new RmBinary(innerText);
                case RmAttributeType.Boolean:
                    return Boolean.Parse(innerText);
                default:
                    return innerText;
                }
            } catch (FormatException ex) {
                throw new ArgumentException(
                    String.Format(
                        "Failed to parse attribute {0} with value {1} into type {2}.  Please ensure the resource management schema is up to date.",
                        attributeName,
                        innerText,
                        info.AttributeType.ToString()),
                    ex);
            } catch (System.Text.EncoderFallbackException ex) {
                throw new ArgumentException(
                    String.Format(
                        "Failed to convert the string on binary attribute {0} into byte array.",
                        attributeName),
                    ex);
            }
        }

        /// <summary>
        /// Gets or Sets the ResourceTypeFactory used to construct individual resource objects.
        /// </summary>
        public IResourceTypeFactory ResourceTypeFactory {
            get {
                return this.resourceTypeFactory;
            }
            set {
                if (value == null) {
                    throw new ArgumentNullException("ResourceTypeFactory");
                }
                this.resourceTypeFactory = value;
            }
        }
    }
}
