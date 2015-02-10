using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog.XmlContainers
{
    [XmlRoot("catalog")]
    public class AuthorBooksCatalog
    {
        [XmlArray("authors")]
        [XmlArrayItem("item")]
        public AuthorEntity[] Authors { get; set; }

        [XmlArray("book-authors")]
        [XmlArrayItem("item")]
        public BookAuthorEntity[] BookAuthors { get; set; }
    }
}