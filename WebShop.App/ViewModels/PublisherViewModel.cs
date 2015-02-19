using Newtonsoft.Json;

namespace WebShop.ViewModels
{
    public class PublisherViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } 
    }
}