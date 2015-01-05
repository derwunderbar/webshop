using System.Collections.Generic;

namespace WebShop.Services.Models.Catalog
{
    public class AuthorDetails : Author
    {
        public IEnumerable<Book> Books { get; set; }
    }
}