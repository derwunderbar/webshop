using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog
{
    public class BookAuthorEntity
    {
        [XmlElement("book-id")]
        public int BookId { get; set; }

        [XmlElement("author-id")]
        public int AuthorId { get; set; }
    }
}