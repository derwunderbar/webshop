namespace WebShop.Data.Entities
{
    public class BookDetailsEntity : BookEntity
    {
        public AuthorEntity Author { get; set; }

        public PublisherEntity Publisher { get; set; }

        public string Description { get; set; }
    }
}