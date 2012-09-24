using System;
using System.Text;

namespace Predica.FimCommunication.Querying
{
    public enum FilterOperation
    {
        Contains,
        Equals,
        Greater,
        StartsWith,
        IsInSet
    }

    public enum AttributeTypes
    {
        Undefined,
        String,
        Integer,
        DateTime,
        Boolean
    }

    public class Filter
    {
        public const string DateAttribute = "[Date]";
        public const string Null = "___$$$null$$$___";
        public const string NotNull = "___$$$not-null$$$___";

        public string AttributeName { get; set; }
        public string Value { get; set; }
        public FilterOperation Operation { get; set; }
        public AttributeTypes AttributeType { get; set; }

        public bool Negate { get; set; }

        public Filter(string attributeName, string value, FilterOperation operation)
        {
            AttributeName = attributeName;
            Value = value;
            Operation = operation;
            AttributeType = AttributeTypes.Undefined;
        }

        public Filter(string attributeName, string value, FilterOperation operation, AttributeTypes attributeType)
            : this(attributeName, value, operation)
        {
            AttributeType = attributeType;
        }

        public string ComposeXPath()
        {
            string xpath;
            if (this.AttributeName.StartsWith("[ref]"))
            {
                xpath = ReferenceSyntax();
            }
            else
            {
                xpath = NormalSyntax(this.AttributeName, this.Value);
            }

            return Negate
                       ? "not(" + xpath + ")"
                       : xpath;
        }

        private string ReferenceSyntax()
        {
            switch (this.Operation)
            {
                case FilterOperation.Contains:
                case FilterOperation.Equals:
                    var attr = this.AttributeName.Substring(5);
                    var parts = attr.Split(',');
                    if (parts.Length != 3)
                    {
                        throw new ArgumentException(
                            "3 parts are required for [ref] syntax in 'contains' filter, current definition is incorrect: " +
                            this.AttributeName);
                    }
                    return "{0}=/{1}[{2}]".FormatWith(parts[0], parts[1], NormalSyntax(parts[2], this.Value));

                default:
                    throw new NotSupportedException(
                        "Requested operation {0} is not supported for references.".FormatWith(this.Operation));
            }
        }

        private string NormalSyntax(string attributeName, string filterValue)
        {
            switch (this.Operation)
            {
                // [MA]
                // <FIM cheating mode on>
                // contains() does not work as expected
                // (filters only attributes that start with given value, not contain it, and no wildcards help)
                // but starts-with with '%' wildcard does the trick
                // requires FIM update: http://support.microsoft.com/kb/2635086 , does not work with previous versions
                // because FIM team changes wildcard interpretation logic in xpath queries every now and then
                // </FIM cheating mode off>
                case FilterOperation.Contains:
                    {
                        return "starts-with({0}, '%{1}')".FormatWith(attributeName, filterValue);
                    }
                case FilterOperation.StartsWith:
                    {
                        return "starts-with({0}, '{1}')".FormatWith(attributeName, filterValue);
                    }
                case FilterOperation.IsInSet:
                    {
                        return "{0} = /{1}".FormatWith(attributeName, filterValue);
                    }
                case FilterOperation.Equals:
                    {
                        string filter;

                        if (AttributeType == AttributeTypes.Integer && (filterValue == NotNull || filterValue == Null))
                        {
                            filter = "{0} <= {1}".FormatWith(attributeName, int.MaxValue);

                            if (filterValue == Null)
                            {
                                filter = "not({0})".FormatWith(filter);
                            }
                        }
                        else if (AttributeType == AttributeTypes.DateTime)
                        {
                            DateTime filterDate;

                            if (DateTime.TryParse(filterValue, out filterDate))
                            {
                                filter =
                                    "{0} >= '{1}T00:00:00' and {0} <= '{1}T23:59:59'".FormatWith(
                                        attributeName,
                                        filterDate.ToShortDateString());
                            }
                            else
                            {
                                // incorrect filter so create filter that will show no results
                                filter =
                                    "{0} > '{1}T00:00:00'".FormatWith(
                                        attributeName,
                                        DateTime.MaxValue.ToShortDateString());
                            }

                        }
                        else
                        {
                            bool test;
                            int test2;
                            if (Boolean.TryParse(filterValue, out test) || Int32.TryParse(filterValue, out test2))
                            {
                                filter = "{0} = {1}".FormatWith(attributeName, filterValue);
                            }
                            else
                            {
                                filter = "{0} = '{1}'".FormatWith(attributeName, filterValue);
                            }
                        }

                        return filter;
                    }
                case FilterOperation.Greater:
                    {
                        return "{0} > {1}".FormatWith(attributeName, filterValue);
                    }
                default:
                    throw new NotSupportedException(
                        "Requested operation {0} is not supported.".FormatWith(this.Operation));
            }
        }

        public static string GetAttributeNameForReferenceFilter(string objectAttribute, string resourceType, string resourceAttribute)
        {
            var sb = new StringBuilder("[ref]");
            sb.Append(objectAttribute);
            sb.Append(',');
            sb.Append(resourceType);
            sb.Append(',');
            sb.Append(resourceAttribute);

            return sb.ToString();
        }
    }
}
