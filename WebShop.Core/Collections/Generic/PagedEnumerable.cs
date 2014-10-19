using System.Collections.Generic;

namespace WebShop.Core.Collections.Generic
{
    public interface IPagedEnumerable<out T>
    {
        IEnumerable<T> Items { get; }

        int TotalItemsCount { get; }
    }

    public class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        public PagedEnumerable( IEnumerable<T> items, int totalItemsCount )
        {
            Items = items;
            TotalItemsCount = totalItemsCount;
        }

        public IEnumerable<T> Items { get; private set; }

        public int TotalItemsCount { get; private set; }
    }
}