using System.Collections.Generic;

namespace WebShop.Data.Entities
{
    public class AuthorDetailsEntity : AuthorEntity
    {
        public string Avatar { get; set; }

        public IEnumerable<BookEntity> Books { get; set; }
    }
}