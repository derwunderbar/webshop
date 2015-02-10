using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog.XmlContainers
{
    [XmlRoot("catalog")]
    public class BooksCatalog
    {
        [XmlArray("books")]
        [XmlArrayItem("item")]
        public BookEntity[] Books { get; set; }
    }
}