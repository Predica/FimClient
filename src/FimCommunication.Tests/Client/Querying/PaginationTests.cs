using Predica.FimCommunication.Querying;
using Xunit;

namespace Predica.FimCommunication.Tests.Client.Querying
{
    public class PaginationTests
    {
        [Fact]
        public void page_indexes_are_zero_based()
        {
            Assert.Equal(0, Pagination.FirstPageIndex);
        }

        [Fact]
        public void All_instance_is_configured_for_fetching_all_items()
        {
            var p = Pagination.All;
            
            Assert.Equal(Pagination.FirstPageIndex, p.PageIndex);
            Assert.Equal(Pagination.AllPagesSize, p.PageSize);
        }

        [Fact]
        public void FirstPageOfSize_factory_creates_instance_configured_for_fetching_first_page_of_given_size()
        {
            var p = Pagination.FirstPageOfSize(19);

            Assert.Equal(Pagination.FirstPageIndex, p.PageIndex);
            Assert.Equal(19, p.PageSize);
        }

        [Fact]
        public void FromRowIndex_factory_creates_instance_configured_for_page_containing_given_row()
        {
            var p1 = Pagination.FromRowIndex(0, 19);
            Assert.Equal(0, p1.PageIndex);
            Assert.Equal(19, p1.PageSize);

            var p2 = Pagination.FromRowIndex(7, 4);
            Assert.Equal(1, p2.PageIndex);
            Assert.Equal(4, p2.PageSize);
        }

        [Fact]
        public void calculates_first_row_index_for_no_paging()
        {
            var p = Pagination.All;
            int rowIndex = p.GetFirstRowIndex();

            Assert.Equal(0, rowIndex);
        }

        [Fact]
        public void calculates_first_row_index_on_given_page()
        {
            var p = new Pagination(2, 3);
            int rowIndex = p.GetFirstRowIndex();

            Assert.Equal(6, rowIndex);
        }
    }
}