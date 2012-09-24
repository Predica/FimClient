using System;
using Microsoft.ResourceManagement.ObjectModel;
using Predica.FimCommunication.Querying;
using Xunit;
using System.Linq;

namespace Predica.FimCommunication.Tests.Client
{
    public class executing_paged_queries
        : FimIntegrationTestBase
    {
        [Fact]
        public void requires_paging_information___use_All_instead_of_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => _client.EnumeratePage<RmResource>("/query", null, SortingInstructions.None)
            );
        }

        [Fact]
        public void requires_sorting_information___use_None_instead_of_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => _client.EnumeratePage<RmResource>("/query", Pagination.All, null)
            );
        }

        [Fact]
        public void can_get_all_elements_when_no_paging_defined()
        {
            var items = _client.EnumeratePage<RmResource>("/Person", Pagination.All, SortingInstructions.None)
                .Items.ToList();

            Assert.True(items.Count > 3);
        }

        [Fact]
        public void can_fetch_only_desired_number_of_elements()
        {
            var pagination = Pagination.FirstPageOfSize(2);
            var items = _client.EnumeratePage<RmResource>("/Person", pagination, SortingInstructions.None)
                .Items.ToList();

            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void fetches_total_count_of_items()
        {
            var pagination = Pagination.FirstPageOfSize(2);
            var result = _client.EnumeratePage<RmResource>("/Person", pagination, SortingInstructions.None);

            Assert.True(result.TotalItemsCount > 2);
        }

        [Fact]
        public void fetches_different_items_for_different_pages()
        {
            var result1 = _client.EnumeratePage<RmResource>("/Person", Pagination.FirstPageOfSize(2), SortingInstructions.None);
            var result2 = _client.EnumeratePage<RmResource>("/Person", new Pagination(Pagination.FirstPageIndex + 1, 2), SortingInstructions.None);

            var items1 = result1.Items.ToArray();
            var items2 = result2.Items.ToArray();

            Assert.NotEqual(items1[0].ObjectID.Value, items2[0].ObjectID.Value);
            Assert.NotEqual(items1[1].ObjectID.Value, items2[1].ObjectID.Value);
        }

        [Fact]
        public void fetches_attributes_values_for_objects___prevents_loading_empty_objects_with_ID_value_only_caused_by_incorrectly_setting_selection_range()
        {
            var page = _client.EnumeratePage<RmResource>("/Person", Pagination.FirstPageOfSize(2), SortingInstructions.None);

            var firstItem = page.Items.First();
            Assert.NotEmpty((string)firstItem[new RmAttributeName("DisplayName")].Value);
        }

        [Fact]
        public void fetches_all_items_when_pagination_configured_for_all_pages()
        {
            var page = _client.EnumeratePage<RmResource>("/Person", Pagination.All, SortingInstructions.None);

            Assert.Equal(page.TotalItemsCount, page.Items.Count());
        }

        [Fact]
        public void fetches_only_selected_attributes()
        {
            var result1 = _client.EnumeratePage<RmResource>(
                "/Person"
                , Pagination.FirstPageOfSize(2)
                , SortingInstructions.None
            );
            var result2 = _client.EnumeratePage<RmResource>(
                "/Person"
                , Pagination.FirstPageOfSize(2)
                , SortingInstructions.None
                , new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name, RmResource.AttributeNames.CreatedTime.Name)
            );

            var items1 = result1.Items.ToArray();
            var items2 = result2.Items.ToArray();

            Assert.Equal(items1.Length, items2.Length);

            for (int i = 0; i < items1.Length; i++)
            {
                Assert.NotEmpty(items1[i].DisplayName);
                Assert.NotNull(items1[i].CreatedTime);

                Assert.Empty(items2[i].DisplayName);
                Assert.NotNull(items2[i].CreatedTime);
            }
        }

        [Fact]
        public void always_fetches_objecttype_with_selected_attributes___required_to_create_instances_of_correct_resource_types()
        {
            var result = _client.EnumeratePage<RmResource>(
                "/Person"
                , Pagination.FirstPageOfSize(3)
                , SortingInstructions.None
                , new AttributesToFetch(RmResource.AttributeNames.ObjectID.Name, RmResource.AttributeNames.DisplayName.Name)
            );

            var persons = result.Items.ToArray();

            foreach (var person in persons)
            {
                Assert.NotEqual(person.GetType(), typeof(RmResource));
            }
        }

        [Fact]
        public void fetches_selected_attributes_even_if_some_incorrect_attributes_are_also_present()
        {
            var results = _client.EnumeratePage<RmResource>(
                "/Person"
                , Pagination.FirstPageOfSize(3)
                , SortingInstructions.None
                , new AttributesToFetch(
                    RmResource.AttributeNames.ObjectID.Name
                    , "DisplayName"
                    // attribute from other resource type
                    , "ActivityName"
                )
            );

            foreach (var item in results.Items)
            {
                Assert.NotEmpty(item.DisplayName);
            }
        }
    }
}