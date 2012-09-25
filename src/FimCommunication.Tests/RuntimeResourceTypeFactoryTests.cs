using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Predica.FimCommunication.Errors;
using Xunit;

namespace Predica.FimCommunication.Tests
{
    public class RuntimeResourceTypeFactoryTests
    {
        private RuntimeResourceTypeFactory _factory;

        public RuntimeResourceTypeFactoryTests()
        {
            _factory = new RuntimeResourceTypeFactory();
        }

        [Fact]
        public void creates_generic_resource_for_empty_type()
        {
            RmResource resource = _factory.CreateResource(string.Empty);

            Assert.Equal(typeof(RmResource), resource.GetType());
        }

        [Fact]
        public void creates_generic_resource_for_null_type()
        {
            RmResource resource = _factory.CreateResource(null);

            Assert.Equal(typeof(RmResource), resource.GetType());
        }

        [Fact]
        public void creates_generic_resource_for_unknown_resource_type()
        {
            RmResource resource = _factory.CreateResource("unknown-resource-type");

            Assert.Equal(typeof(RmResource), resource.GetType());
        }

        [Fact]
        public void creates_resources_for_types_defined_in_standard_fim2010client_library()
        {
            RmResource resource = _factory.CreateResource("Person");

            Assert.Equal(typeof(RmPerson), resource.GetType());
        }

        [Fact]
        public void creates_resources_ignoring_case()
        {
            RmResource resource = _factory.CreateResource("pERsoN");

            Assert.Equal(typeof(RmPerson), resource.GetType());
        }

        [Fact]
        public void creates_resources_for_types_defined_in_custom_referenced_libraries()
        {
            RmResource resource = _factory.CreateResource("CustomResource");

            Assert.Equal(typeof(RmCustomResource), resource.GetType());
        }

        [Fact]
        public void creates_resources_for_types_ignoring_Rm_prefix()
        {
            RmResource resource = _factory.CreateResource("OtherCustomResource");

            Assert.Equal(typeof(OtherCustomResource), resource.GetType());
        }

        [Fact]
        public void throws_if_multiple_types_conform_to_the_given_type_name()
        {
            Assert.Throws<MultipleResourceTypesException>(() => _factory.CreateResource("MultipleResource"));
        }

        [Fact]
        public void handles_resource_types_with_dashes___treats_dashes_as_underscores()
        {
            RmResource resource = _factory.CreateResource("ma-data");

            Assert.Equal(typeof(Rmma_data), resource.GetType());
        }

        #region types for tests

        public class RmCustomResource : RmResource
        {

        }

        public class OtherCustomResource : RmResource
        {

        }

        public class MultipleResource : RmResource
        {

        }

        public class RmMultipleResource : RmResource
        {

        }

        #endregion
    }
}