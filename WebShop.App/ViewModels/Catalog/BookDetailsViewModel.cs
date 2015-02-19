using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using WebShop.Services.Models.Catalog;

namespace WebShop.ViewModels.Catalog
{
    public class BookDetailsViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public float Price { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("author")]
        public AuthorViewModel Author { get; set; }

        [JsonProperty("publisher")]
        public PublisherViewModel Publisher { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}