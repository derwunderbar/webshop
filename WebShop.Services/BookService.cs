using System.Collections.Generic;
using System.Linq;
using WebShop.Data;
using WebShop.Services.Models;

namespace WebShop.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        BookDetails Get(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public IEnumerable<Book> GetAll()
        {
            var bookEntities = _bookRepository.GetAll();
            var books = bookEntities
                .Select(a => new Book()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Cover = a.ThumbImage,
                });
            return books;
        }

        public BookDetails Get(int id)
        {
            var entity = _bookRepository.Get(id);
            if (entity == null)
                return null;

            var bookDetails = new BookDetails()
            {
                Id = entity.Id,
                Title = entity.Title,
                Price = entity.Price,
                Cover = entity.TitleImage,
                Author = new Author()
                {
                    Id = entity.Author.Id,
                    FirstName = entity.Author.FirstName,
                    LastName = entity.Author.LastName,
                },
                Publisher = new Publisher()
                {
                    Id = entity.Publisher.Id,
                    Name = entity.Publisher.Name,
                },
                Description = entity.Description,
            };

            return bookDetails;
        }
    }
}