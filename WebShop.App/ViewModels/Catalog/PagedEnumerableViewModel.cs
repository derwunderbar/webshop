using System.Collections.Generic;

namespace WebShop.ViewModels.Catalog
{
    public class PagedEnumerableViewModel<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> Items { get; set; }

        public int TotalItemsCount { get; set; }
    }
}