namespace WebShop.Data.Entities.Catalog
{
    public class BookDetailsEntity : BookEntity
    {
        public AuthorEntity Author { get; set; }

        public PublisherEntity Publisher { get; set; }
    }
}