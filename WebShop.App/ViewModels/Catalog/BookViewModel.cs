using Newtonsoft.Json;

namespace WebShop.ViewModels.Catalog
{
    public class BookViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; } 
    }
}