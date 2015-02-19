using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebShop.ViewModels.Catalog
{
    public class PagedEnumerableViewModel<T>
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("items")]
        public IEnumerable<T> Items { get; set; }

        [JsonProperty("totalItemsCount")]
        public int TotalItemsCount { get; set; }
    }
}