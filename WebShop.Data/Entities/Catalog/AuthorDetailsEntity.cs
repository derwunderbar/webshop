using System.Collections.Generic;

namespace WebShop.Data.Entities.Catalog
{
    public class AuthorDetailsEntity : AuthorEntity
    {
        public IEnumerable<BookEntity> Books { get; set; }
    }
}