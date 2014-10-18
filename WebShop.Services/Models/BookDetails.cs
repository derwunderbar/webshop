namespace WebShop.Services.Models
{
    public class BookDetails : Book
    {
        public Author Author { get; set; }

        public Publisher Publisher { get; set; }
        
        public string Description { get;  set; }
    }
}