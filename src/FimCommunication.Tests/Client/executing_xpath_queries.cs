using System.Linq;
using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Predica.FimCommunication.Querying;
using Xunit;

namespace Predica.FimCommunication.Tests.Client
{
    public class executing_xpath_queries
        : FimIntegrationTestBase
    {
        [Fact]
        public void finds_multiple_objects()
        {
            var resources = _client.EnumerateAll<RmResource>("/WorkflowDefinition[RequestPhase='Authorization']")
                .ToList();

            Assert.NotEmpty(resources);
        }

        [Fact]
        public void finds_single_object()
        {
            var resources = _client.EnumerateAll<RmResource>("/WorkflowDefinition[DisplayName='Expiration Workflow']")
                .ToList();

            Assert.Equal(1, resources.Count);
        }

        [Fact]
        public void finds_object_by_id_as_collection()
        {
            var allResources = _client.EnumerateAll<RmResource>("/WorkflowDefinition");
            var firstResource = allResources.First();

            var resources = _client.EnumerateAll<RmResource>("/WorkflowDefinition[ObjectID='" + firstResource.ObjectID.Value + "']")
                .ToList();

            Assert.Equal(1, resources.Count);
        }

        [Fact]
        public void casts_found_objects_to_known_types()
        {
            var resources = _client.EnumerateAll<RmResource>("/ActivityInformationConfiguration")
                .ToList();

            // test makes no sense if no resources fetched
            Assert.NotEmpty(resources);

            foreach (var resource in resources)
            {
                Assert.IsType<RmActivityInformationConfiguration>(resource);
            }
        }

        [Fact]
        public void can_fetch_objects_with_only_selected_attribute_values()
        {
            var personWithAllAttributes = _client.EnumerateAll<RmResource>("/Person").First(x => x.DisplayName.Length > 0);
            Assert.NotEmpty(personWithAllAttributes.DisplayName);

            var personWithSomeAttributes = _client.EnumerateAll<RmResource>("/Person",
                new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name)
            ).First(x => x.ObjectID == personWithAllAttributes.ObjectID);

            Assert.Empty(personWithSomeAttributes.DisplayName);
        }

        [Fact]
        public void always_fetches_objecttype_with_selected_attributes___required_to_create_instances_of_correct_resource_types()
        {
            var personWithAllAttributes = _client.EnumerateAll<RmResource>("/Person").First(x => x.DisplayName.Length > 0);
            Assert.NotEmpty(personWithAllAttributes.DisplayName);

            var personWithSomeAttributes = _client.EnumerateAll<RmResource>("/Person",
                new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name)
            ).First(x => x.ObjectID == personWithAllAttributes.ObjectID);

            Assert.NotEqual(personWithSomeAttributes.GetType(), typeof(RmResource));
        }
    }
}