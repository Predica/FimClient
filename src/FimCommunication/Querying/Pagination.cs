namespace Predica.FimCommunication.Querying
{
    public class Pagination
    {
        public static readonly int FirstPageIndex = 0;

        /// <summary>
        /// Value used to get all pages in a query
        /// </summary>
        public static readonly int AllPagesSize = -1;


        // do NOT move this above previous field definitions, it needs to be initialized later
        // (needs to be lower in C# code)
        public static readonly Pagination All = new Pagination(FirstPageIndex, AllPagesSize);

        /// <summary>
        /// Zero-based index of the page
        /// </summary>
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public Pagination()
        {
        }

        /// <param name="pageIndex">Zero based index of the page.</param>
        public Pagination(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public static Pagination FirstPageOfSize(int size)
        {
            return new Pagination(FirstPageIndex, size);
        }

        /// <summary>
        /// Builds a request given zero-based starting row index and page size.
        /// </summary>
        public static Pagination FromRowIndex(int rowIndex, int pageSize)
        {
            return new Pagination(rowIndex / pageSize, pageSize);
        }

        public int GetFirstRowIndex()
        {
            return PageIndex*PageSize;
        }
    }
}