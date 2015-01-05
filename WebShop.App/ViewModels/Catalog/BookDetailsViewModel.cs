using System.ComponentModel.DataAnnotations;
using WebShop.Services.Models.Catalog;

namespace WebShop.ViewModels.Catalog
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public float Price { get; set; }

        public string Cover { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

        public string Description { get; set; }
    }
}