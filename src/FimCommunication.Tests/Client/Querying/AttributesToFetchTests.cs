using System;
using Predica.FimCommunication.Querying;
using Xunit;

namespace Predica.FimCommunication.Tests.Client.Querying
{
    public class AttributesToFetchTests
    {
        [Fact]
        public void returns_given_strings_as_array()
        {
            var attributes = new AttributesToFetch("attr1", "attr2", "attr3");

            var names = attributes.GetNames();

            Assert.Equal(new[] { "attr1", "attr2", "attr3" }, names);
        }

        [Fact]
        public void returns_null_if_no_names_passed___required_for_underlying_fim2010client_mechanisms__must_be_null_not_empty_collection()
        {
            var attributes = new AttributesToFetch();

            var names = attributes.GetNames();

            Assert.Null(names);
        }

        [Fact]
        public void All_returns_null_names()
        {
            var allNames = AttributesToFetch.All.GetNames();

            Assert.Null(allNames);
        }

        [Fact]
        public void does_not_modify_original_instance()
        {
            var attributes = new AttributesToFetch("attr1");

            attributes.AppendAttribute("attr2");

            var names = attributes.GetNames();

            Assert.Equal(new[] { "attr1" }, names);
        }

        [Fact]
        public void appends_new_name_to_the_list_and_creates_new_instance()
        {
            var attributes = new AttributesToFetch("attr1");

            var newAttributes = attributes.AppendAttribute("attr2");

            var names = newAttributes.GetNames();

            Assert.Equal(new[] { "attr1", "attr2" }, names);
        }

        [Fact]
        public void does_not_append_duplicate_names()
        {
            var attributes = new AttributesToFetch("attr1", "attr2");

            var newAttributes = attributes.AppendAttribute("attr2");

            var names = newAttributes.GetNames();

            Assert.Equal(new[] { "attr1", "attr2" }, names);
        }

        [Fact]
        public void can_append_names_to_empty_names_list()
        {
            var attributes = new AttributesToFetch();

            var newAttributes = attributes.AppendAttribute("attr1");

            var names = newAttributes.GetNames();

            Assert.Equal(new[] { "attr1" }, names);
        }

        [Fact]
        public void throws_when_trying_to_modify_All_instance()
        {
            var allNames = AttributesToFetch.All;

            Assert.Throws<InvalidOperationException>(
                () => allNames.AppendAttribute("attr")
            );

            Assert.Null(allNames.GetNames());
        }
    }
}