using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using Microsoft.ResourceManagement.ObjectModel;
using System.Diagnostics;

namespace Microsoft.ResourceManagement.Client
{
    /// <summary>
    /// Base class for request and resource factories.
    /// </summary>
    public class RmFactory
    {
        public XmlSchemaSet RmSchema;
        protected const string RmNamespace = "http://schemas.microsoft.com/2006/11/ResourceManagement";
        protected Dictionary<RmAttributeName, RmAttributeInfo> RmAttributeCache;
        protected Dictionary<string, Dictionary<RmAttributeName, RmAttributeInfo>> RmObjectCache;
        protected XmlDocument RmDoc;
        protected XmlNamespaceManager RmNsManager;

        /// <summary>
        /// Creates an indexable cache of Resource Management attributes and objects based on the given schema set.
        /// </summary>
        /// <param name="rmSchema"></param>
        public RmFactory(XmlSchemaSet rmSchema)
        {
            if (rmSchema == null)
            {
                throw new ArgumentNullException("rmSchema");
            }
            lock (rmSchema)
            {
                this.RmSchema = rmSchema;
                if (this.RmSchema.IsCompiled == false)
                {
                    this.RmSchema.Compile();
                }
                this.RmAttributeCache = new Dictionary<RmAttributeName, RmAttributeInfo>();
                this.RmObjectCache = new Dictionary<string, Dictionary<RmAttributeName, RmAttributeInfo>>();

                this.RmDoc = new XmlDocument();
                this.RmNsManager = new XmlNamespaceManager(this.RmDoc.NameTable);
                this.RmNsManager.AddNamespace("rm", RmNamespace);

                foreach (XmlSchemaObject schemaObj in this.RmSchema.GlobalTypes.Values)
                {
                    XmlSchemaComplexType schemaObjComplexType = schemaObj as XmlSchemaComplexType;
                    if (schemaObjComplexType != null)
                    {
                        if (schemaObjComplexType.Name == null || schemaObjComplexType.Particle == null)
                        {
                            continue;
                        }
                        RmObjectCache[schemaObjComplexType.Name] = new Dictionary<RmAttributeName, RmAttributeInfo>();
                        XmlSchemaSequence schemaObjSequence = schemaObjComplexType.Particle as XmlSchemaSequence;
                        if (schemaObjSequence != null)
                        {
                            foreach (XmlSchemaObject sequenceObj in schemaObjSequence.Items)
                            {
                                XmlSchemaElement sequenceElement = sequenceObj as XmlSchemaElement;
                                if (sequenceElement != null)
                                {
                                    RmAttributeInfo info = new RmAttributeInfo();

                                    if (sequenceElement.MaxOccurs > Decimal.One)
                                    {
                                        info.IsMultiValue = true;
                                    }

                                    if (sequenceElement.MinOccurs > Decimal.Zero)
                                    {
                                        info.IsRequired = true;
                                    }

                                    string attributeTypeName = sequenceElement.ElementSchemaType.QualifiedName.Name.ToUpperInvariant();

                                    if (string.IsNullOrEmpty(attributeTypeName)) {
                                        attributeTypeName = sequenceElement.SchemaType.TypeCode.ToString().ToUpperInvariant();
                                        //Trace.TraceWarning("No type information for attribute '{0}' [{1}]", 
                                        //    sequenceElement.Name,
                                        //    sequenceElement.ElementSchemaType.TypeCode);
                                    }
                                    if (string.IsNullOrEmpty(attributeTypeName)) {
                                        throw new ArgumentException(string.Format(
                                            "Could not get type for attribute {0}",
                                            sequenceElement.Name));
                                    }

                                    if (attributeTypeName.Contains("COLLECTION")) {
                                        info.IsMultiValue = true;
                                    }

                                    if (attributeTypeName.Contains("REFERENCE"))
                                    {
                                        info.AttributeType = RmAttributeType.Reference;
                                    }
                                    else if (attributeTypeName.Contains("BOOLEAN"))
                                    {
                                        info.AttributeType = RmAttributeType.Boolean;
                                    }
                                    else if (attributeTypeName.Contains("INTEGER"))
                                    {
                                        info.AttributeType = RmAttributeType.Integer;
                                    }
                                    else if (attributeTypeName.Contains("DATETIME"))
                                    {
                                        info.AttributeType = RmAttributeType.DateTime;
                                    }
                                    else if (attributeTypeName.Contains("BINARY"))
                                    {
                                        info.AttributeType = RmAttributeType.Binary;
                                    } else if (attributeTypeName.Contains("STRING")) {
                                        info.AttributeType = RmAttributeType.String;
                                    } else if (attributeTypeName.Contains("TEXT")) {
                                        info.AttributeType = RmAttributeType.String;
                                    } else {
                                        throw new ArgumentException(string.Format(
                                            "Uknown type '{0}' for attribute {1}",
                                            attributeTypeName,
                                            sequenceElement.Name));
                                    }
                                    RmAttributeName attributeName = new RmAttributeName(sequenceElement.Name);
                                    RmObjectCache[schemaObjComplexType.Name][attributeName] = info;
                                    RmAttributeCache[attributeName] = info;
                                }
                            }
                        }
                    }
                }
            }
        }

        #warning "TBM?"
        public RmAttributeValue CreateRmAttributeValue(RmAttributeName attributeName) {
            if (IsMultiValued(attributeName)) {
                return new RmAttributeValueMulti();
            } else {
                return new RmAttributeValueSingle();
            }
        }

        #region Internal test methods

        /// <summary>
        /// IsMultiValued
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is multivalued, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsMultiValued(string attributeName) {
            return IsMultiValued(new RmAttributeName(attributeName));
        }

        /// <summary>
        /// IsMultiValued
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is multivalued, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsMultiValued(RmAttributeName attributeName) {
            RmAttributeInfo retValue = null;
            RmAttributeCache.TryGetValue(attributeName, out retValue);
            if (retValue == null)
            {
                return false;
            } 
            else 
            {
                return retValue.IsMultiValue;
            }

        }

        /// <summary>
        /// IsReference
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is a reference, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsReference(string attributeName) {
            return IsReference(new RmAttributeName(attributeName));
        }

        /// <summary>
        /// IsReference
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is a reference, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsReference(RmAttributeName attributeName) {
            RmAttributeInfo retValue = null;
            RmAttributeCache.TryGetValue(attributeName, out retValue);
            if (retValue == null)
            {
                return false;
            } else {
                return retValue.AttributeType == RmAttributeType.Reference;
            }

        }
        /// <summary>
        /// IsRequired
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is required, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsRequired(string objectType, string attributeName) {
            return IsRequired(objectType, new RmAttributeName(attributeName));
        }

        /// <summary>
        /// IsRequired
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>True if the attribute is required, false otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal bool IsRequired(string objectType, RmAttributeName attributeName) {
            Dictionary<RmAttributeName, RmAttributeInfo> attributeValue = null;
            RmObjectCache.TryGetValue(objectType, out attributeValue);
            if (attributeValue == null)
            {
                return false;
            }
            else
            {
                RmAttributeInfo attributeInfo = null;
                attributeValue.TryGetValue(attributeName, out attributeInfo);
                if (attributeInfo == null)
                {
                    return false;
                } else {
                    return attributeInfo.IsRequired;
                }
            }

        }

        /// <summary>
        /// GetAttributeType
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>The FIM type of the attribute if found, null otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal RmAttributeType? GetAttributeType(string attributeName) {
            return GetAttributeType(new RmAttributeName(attributeName));
        }

        /// <summary>
        /// GetAttributeType
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>The FIM type of the attribute if found, null otherwise.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal RmAttributeType? GetAttributeType(RmAttributeName attributeName) {
            RmAttributeInfo retValue = null;
            RmAttributeCache.TryGetValue(attributeName, out retValue);
            if (retValue == null) {
                return null;
            } else {
                return retValue.AttributeType;
            }
        }

        /// <summary>
        /// Gets the list of required attributes for the given object type.
        /// </summary>
        /// <param name="objectType">The type of the object</param>
        /// <returns>List of required attributes.</returns>
        /// <remarks>This method is only for testing, and should not be used
        /// directly by clients.</remarks>
        internal List<RmAttributeName> RequiredAttributes(string objectType) {
            List<RmAttributeName> retList = new List<RmAttributeName>();
            Dictionary<RmAttributeName, RmAttributeInfo> attributeValue = null;
            RmObjectCache.TryGetValue(objectType, out attributeValue);
            if (attributeValue == null)
            {
                return retList;
            }
            else
            {
                foreach(KeyValuePair<RmAttributeName, RmAttributeInfo> pair in attributeValue)
                {
                    if (pair.Value.IsRequired)
                    {
                        retList.Add(pair.Key);
                    }
                }
                return retList;
            }
        }

        #endregion

        /// <summary>
        /// Information about an attribute.
        /// </summary>
        public class RmAttributeInfo {
            /// <summary>
            /// Attribute is multi valued.
            /// </summary>
            public bool IsMultiValue;
            /// <summary>
            /// Attribute is required.
            /// </summary>
            public bool IsRequired;
            /// <summary>
            /// Attribute type.
            /// </summary>
            public RmAttributeType AttributeType;
        }

        /// <summary>
        /// The FIM type of the attribute.
        /// </summary>
        public enum RmAttributeType {
            String,
            Reference,
            DateTime,
            Integer,
            Binary,
            Boolean
        }

    }
}
