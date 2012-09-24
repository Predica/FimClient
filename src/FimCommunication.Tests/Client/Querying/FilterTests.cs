using System;
using Predica.FimCommunication.Querying;
using Xunit;
using Xunit.Extensions;

namespace Predica.FimCommunication.Tests.Client.Querying
{
    public class FilterTests
    {
        [Fact]
        public void composes_xpath_filter_from_current_state___using_startswith_with_wildcard_instead_of_contains_to_cheat_FIM()
        {
            var filter = new Filter("some-attribute", "some-value", FilterOperation.Contains);

            string xpath = filter.ComposeXPath();

            Assert.Equal("starts-with(some-attribute, '%some-value')", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state___using_startsWith()
        {
            var filter = new Filter("some-attribute", "some-value", FilterOperation.StartsWith);

            string xpath = filter.ComposeXPath();

            Assert.Equal("starts-with(some-attribute, 'some-value')", xpath);
        }

        [Fact]
        public void refSyntax_composes_query_using_dereferencing__using_startswith_with_wildcard_instead_of_contains_to_cheat_FIM()
        {
            var filter = new Filter("[ref]attr,type,attr2", "some-value", FilterOperation.Contains);

            string xpath = filter.ComposeXPath();

            Assert.Equal("attr=/type[starts-with(attr2, '%some-value')]", xpath);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void refSyntax_throws_if_not_3_elements_present(int paramsCount)
        {
            string[] parameters = Randomizer.Array(() => Randomizer.String(), paramsCount);
            var filter = new Filter("[ref]" + string.Join(",", parameters), "value", FilterOperation.Contains);

            Assert.Throws<ArgumentException>(
                () => filter.ComposeXPath()
            );
        }

        [Fact]
        public void throws_if_requested_to_compose_xpath_for_unsupported_operation()
        {
            var filter = new Filter("some-attribute", "some-value", (FilterOperation)int.MaxValue);

            Assert.Throws<NotSupportedException>(
                () => filter.ComposeXPath()
            );
        }

        [Fact]
        public void composes_xpath_filter_from_current_state___using_greater()
        {
            var filter = new Filter("some-attribute", "some-value", FilterOperation.Greater);

            string xpath = filter.ComposeXPath();

            Assert.Equal("some-attribute > some-value", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state___using_equals_for_bool()
        {
            var filter = new Filter("some-attribute", "true", FilterOperation.Equals);
            var xpath = filter.ComposeXPath();

            Assert.Equal("some-attribute = true", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state_uing_IsIntSet()
        {
            var filter = new Filter("some-attribute", "Resource", FilterOperation.IsInSet);
            var xpath = filter.ComposeXPath();

            Assert.Equal("some-attribute = /Resource", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state___using_equals_for_int()
        {
            var filter = new Filter("some-attribute", "3", FilterOperation.Equals);
            var xpath = filter.ComposeXPath();

            Assert.Equal("some-attribute = 3", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state___using_equals_for_other_types()
        {
            var filter = new Filter("some-attribute", "some-value", FilterOperation.Equals);
            var xpath = filter.ComposeXPath();

            Assert.Equal("some-attribute = 'some-value'", xpath);
        }

        [Fact]
        public void composes_xpath_filter_from_current_state__using_equals_and_DateTime_attribute_type_when_date_is_correct()
        {
            var filter = new Filter("attr-name", "2011-11-30", FilterOperation.Equals, AttributeTypes.DateTime);

            string xpath = filter.ComposeXPath();

            Assert.Equal("attr-name >= '2011-11-30T00:00:00' and attr-name <= '2011-11-30T23:59:59'", xpath);
        }

        [Fact]
        public void composes_xpath_filter_that_will_return_no_results_using_equals_operation_and_DateTime_attribute_type_when_date_is_incorrect()
        {
            var filter = new Filter("attr-name", "incorrect-date", FilterOperation.Equals, AttributeTypes.DateTime);

            string xpath = filter.ComposeXPath();

            Assert.Equal(string.Format("attr-name > '{0}T00:00:00'", DateTime.MaxValue.ToShortDateString()), xpath);
        }

        [Fact]
        public void composes_xpath_filter_checking_if_value_is_not_null__using_equals_and_Integer_attribute_type()
        {
            var filter = new Filter("attr-name", Filter.NotNull, FilterOperation.Equals, AttributeTypes.Integer);

            string xpath = filter.ComposeXPath();

            Assert.Equal(string.Format("attr-name <= {0}", int.MaxValue), xpath);
        }

        [Fact]
        public void composes_xpath_filter_checking_if_value_is_null__using_equals_and_Integer_attribute_type()
        {
            var filter = new Filter("attr-name", Filter.Null, FilterOperation.Equals, AttributeTypes.Integer);

            string xpath = filter.ComposeXPath();

            Assert.Equal(string.Format("not(attr-name <= {0})", int.MaxValue), xpath);
        }

        [Fact]
        public void throws_if_requested_to_compose_xpath_from_refSyntax_for_greater()
        {
            string[] parameters = Randomizer.Array(() => Randomizer.String(), 3);
            var filter = new Filter("[ref]" + string.Join(",", parameters), "some-value", FilterOperation.Greater);

            Assert.Throws<NotSupportedException>(
                () => filter.ComposeXPath()
            );
        }

        [Fact]
        public void composes_attribute_name_for_refSyntax()
        {
            var attributeName = Filter.GetAttributeNameForReferenceFilter("parent-attribute", "type", "child-attribute");

            Assert.Equal("[ref]parent-attribute,type,child-attribute", attributeName);
        }

        [Fact]
        public void negates_xpath_filter_if_configured_to_do_so()
        {
            var filter = new Filter("some-attribute", "some-value", FilterOperation.Contains);

            filter.Negate = true;

            string xpath = filter.ComposeXPath();

            Assert.Equal("not(starts-with(some-attribute, '%some-value'))", xpath);
        }
    }
}