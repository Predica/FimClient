using System;
using System.Linq;
using Microsoft.ResourceManagement.ObjectModel;

namespace Predica.FimCommunication.Querying
{
    public class AttributesToFetch
    {
        private string[] _attributeNames;

        public static readonly AttributesToFetch All = new AttributesToFetch();
        public static readonly AttributesToFetch DisplayNameAndObjectID = new AttributesToFetch(
            RmResource.AttributeNames.ObjectID.Name,
            RmResource.AttributeNames.DisplayName.Name);

        public AttributesToFetch(params string[] attributeNames)
        {
            _attributeNames = attributeNames;
        }

        public AttributesToFetch AppendAttribute(string newName)
        {
            if (this == All)
            {
                throw new InvalidOperationException("Cannot modify readonly AttributesToFetch.All instance (trying to add name {0})".FormatWith(newName));
            }

            var newAttributes = _attributeNames.Union(new[] { newName }).ToArray();

            return new AttributesToFetch(newAttributes);
        }

        public string[] GetNames()
        {
            return _attributeNames.Length > 0
                       ? _attributeNames
                       : null;
        }
    }
}