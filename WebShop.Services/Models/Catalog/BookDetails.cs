namespace WebShop.Services.Models.Catalog
{
    public class BookDetails : Book
    {
        public Author Author { get; set; }

        public Publisher Publisher { get; set; }
        
        public string Description { get;  set; }
    }
}