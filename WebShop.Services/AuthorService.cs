using System.Linq;
using WebShop.Data;
using WebShop.Services.Models;

namespace WebShop.Services
{
    public interface IAuthorService
    {
        AuthorDetails Get(int id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public AuthorDetails Get(int id)
        {
            var entity = _repository.Get(id);
            var authorDetails = new AuthorDetails()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Avatar = entity.Avatar,
                Books = entity.Books
                    .Select(a => new Book()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Cover = a.ThumbImage,
                        Price = a.Price,
                    }),
            };

            return authorDetails;
        }
    }
}