﻿using System.Xml.Serialization;

namespace WebShop.Data.Entities
{
    public class BookPublisherEntity
    {
        [XmlElement("book-id")]
        public int BookId { get; set; }

        [XmlElement("publisher-id")]
        public int PublisherId { get; set; }
    }
}