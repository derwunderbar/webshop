using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog.XmlContainers
{
    [XmlRoot("catalog")]
    public class PublisherBooksCatalog
    {
        [XmlArray("publishers")]
        [XmlArrayItem("item")]
        public PublisherEntity[] Publishers { get; set; }

        [XmlArray("book-publishers")]
        [XmlArrayItem("item")]
        public BookPublisherEntity[] BookPublishers { get; set; }
    }
}