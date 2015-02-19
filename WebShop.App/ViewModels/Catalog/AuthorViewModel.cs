using Newtonsoft.Json;

namespace WebShop.ViewModels.Catalog
{
    public class AuthorViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}