using WebShop.Data.Entities;

namespace WebShop.Data
{
    public interface IAuthorRepository
    {
        AuthorDetailsEntity Get(int id);
    }

    public class AuthorRepository : IAuthorRepository
    {
        public AuthorDetailsEntity Get(int id)
        {
            var authorEntity = EntityStubs.GetAuthor();
            var authorDetailsEntity = new AuthorDetailsEntity()
            {
                Id = id,
                FirstName = authorEntity.FirstName,
                LastName = authorEntity.LastName,
                Books = EntityStubs.GetBooks(),
            };

            return authorDetailsEntity;
        }
    }
}