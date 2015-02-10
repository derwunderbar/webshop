using System.Linq;
using WebShop.Data.Contexts;
using WebShop.Data.Entities.Catalog;

namespace WebShop.Data.Repositories.Catalog
{
    public interface IAuthorRepository
    {
        AuthorDetailsEntity Get(int id);
    }

    public class AuthorRepository : IAuthorRepository
    {
        public AuthorDetailsEntity Get(int id)
        {
            var catalogContext = new CatalogContext();
            var authorEntity = catalogContext.GetAuthors().SingleOrDefault(a => a.Id == id);
            if (authorEntity == null)
                return null;

            var authorBooks = catalogContext.GetAuthorBooks().Where(a => a.AuthorId == id).Select(a=>a.BookId).ToArray();
            var books = catalogContext.GetBooks().Where(a => authorBooks.Contains(a.Id));
            var authorDetailsEntity = new AuthorDetailsEntity()
            {
                Id = id,
                FirstName = authorEntity.FirstName,
                LastName = authorEntity.LastName,
                Books = books,
            };

            return authorDetailsEntity;
        }
    }
}