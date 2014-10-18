using WebShop.Services.Models;

namespace WebShop.ViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public string Cover { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }

        public string Description { get; set; }
    }
}