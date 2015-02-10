using System.Xml.Serialization;

namespace WebShop.Data.Entities
{
    public class AuthorEntity
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("first-name")]
        public string FirstName { get; set; }

        [XmlElement("last-name")]
        public string LastName { get; set; }
    }
}