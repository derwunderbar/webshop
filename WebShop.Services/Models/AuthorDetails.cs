using System.Collections.Generic;

namespace WebShop.Services.Models
{
    public class AuthorDetails : Author
    {
        public string Avatar { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}