using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog
{
    public class PublisherEntity
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}