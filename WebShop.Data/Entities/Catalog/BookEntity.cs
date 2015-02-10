using System.Xml.Serialization;

namespace WebShop.Data.Entities.Catalog
{
    public class BookEntity
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("price")]
        public float Price { get; set; }

        [XmlElement("thumb-image")]
        public string ThumbImage { get; set; }

        [XmlElement("title-image")]
        public string TitleImage { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
    }
}