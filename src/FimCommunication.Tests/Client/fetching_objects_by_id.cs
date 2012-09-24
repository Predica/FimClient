using System.Linq;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Predica.FimCommunication.Querying;
using Xunit;

namespace Predica.FimCommunication.Tests.Client
{
    public class fetching_objects_by_id
        : FimIntegrationTestBase
    {
        [Fact]
        public void finds_object_by_id()
        {
            var allPeople = _client.EnumerateAll<RmPerson>("/Person");
            var firstPerson = allPeople.First();

            RmResource resource = _client.FindById(firstPerson.ObjectID.Value);

            Assert.NotNull(resource);

            Assert.IsType<RmPerson>(resource);
        }

        [Fact]
        public void returns_null_if_object_not_found()
        {
            // assumption: such guid will never be created by FIM
            RmResource result = _client.FindById("11111111-1111-1111-1111-111111111111");

            Assert.Null(result);
        }

        [Fact]
        public void can_fetch_object_with_only_selected_attribute_values()
        {
            var personWithAllAttributes = _client.EnumerateAll<RmResource>("/Person")
                .First(x => x.DisplayName.Length > 0);
            Assert.NotEmpty(personWithAllAttributes.DisplayName);

            var personWithSomeAttributes = _client.FindById(
                personWithAllAttributes.ObjectID.Value,
                new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name)
            );
            Assert.Empty(personWithSomeAttributes.DisplayName);
        }

        [Fact]
        public void always_fetches_objecttype_with_selected_attributes___required_to_create_instances_of_correct_resource_types()
        {
            var personWithAllAttributes = _client.EnumerateAll<RmResource>("/Person")
                .First(x => x.DisplayName.Length > 0);
            Assert.NotEmpty(personWithAllAttributes.DisplayName);

            var personWithSomeAttributes = _client.FindById(
                personWithAllAttributes.ObjectID.Value,
                new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name)
            );

            Assert.NotEqual(personWithSomeAttributes.GetType(), typeof(RmResource));
        }
    }
}