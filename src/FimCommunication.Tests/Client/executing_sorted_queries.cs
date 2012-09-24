using Microsoft.ResourceManagement.ObjectModel;
using Microsoft.ResourceManagement.ObjectModel.ResourceTypes;
using Predica.FimCommunication.Querying;
using Xunit;
using System.Linq;

namespace Predica.FimCommunication.Tests.Client
{
    public class executing_sorted_queries
        : FimIntegrationTestBase
    {
        [Fact]
        public void can_fetch_items_sorted_ascending_by_given_attribute()
        {
            var sorting = new SortingInstructions(
                RmPerson.AttributeNames.LastName.Name
                , SortOrder.Ascending
            );
            var page = _client.EnumeratePage<RmPerson>("/Person", Pagination.FirstPageOfSize(3), sorting);

            var sorteredLocally = page.Items.OrderBy(x => x.LastName).ToList();
            var fromFIM = page.Items.ToList();

            Assert.Equal(sorteredLocally, fromFIM);
        }

        [Fact]
        public void can_fetch_items_sorted_descending_by_given_attribute()
        {
            var sorting = new SortingInstructions(
                RmResource.AttributeNames.DisplayName.Name
                , SortOrder.Descending
            );
            var page = _client.EnumeratePage<RmPerson>("/Person", Pagination.FirstPageOfSize(3), sorting);

            var sorteredLocally = page.Items.OrderByDescending(x => x.DisplayName).ToList();
            var fromFIM = page.Items.ToList();

            Assert.Equal(sorteredLocally, fromFIM);
        }

        [Fact]
        public void the_same_page_with_different_sorting_should_return_different_results()
        {
            var sorting1 = new SortingInstructions(
                RmResource.AttributeNames.DisplayName.Name
                , SortOrder.Descending
            );
            var page1 = _client.EnumeratePage<RmPerson>("/Person", Pagination.FirstPageOfSize(3), sorting1);

            var sorting2 = new SortingInstructions(
                RmResource.AttributeNames.DisplayName.Name
                , SortOrder.Ascending
            );
            var page2 = _client.EnumeratePage<RmPerson>("/Person", Pagination.FirstPageOfSize(3), sorting2);

            Assert.NotEqual(page1.Items, page2.Items);
        }
    }
}