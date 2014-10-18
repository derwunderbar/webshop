using System.Collections.Generic;

namespace WebShop.Data.Entities
{
    public class PublisherDetailsEntity : PublisherEntity
    {
        public IEnumerable<BookEntity> Books { get; set; }
    }
}