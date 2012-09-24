using System.Collections.Generic;
using System.Linq;

namespace Predica.FimCommunication.Querying
{
    public class DataPage<T>
    {
        public IEnumerable<T> Items { get; private set; }

        public long TotalItemsCount { get; private set; }

        public DataPage(IEnumerable<T> items, long totalItemsCount)
        {
            Items = items;
            TotalItemsCount = totalItemsCount;
        }

        public static DataPage<T> Empty()
        {
            return new DataPage<T>(Enumerable.Empty<T>(), 0);
        }
    }
}
