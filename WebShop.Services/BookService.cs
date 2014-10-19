using System.Linq;
using WebShop.Core.Collections.Generic;
using WebShop.Data;
using WebShop.Services.Models;

namespace WebShop.Services
{
    public interface IBookService
    {
        IPagedEnumerable<Book> Get( int page, int pageSize );

        BookDetails Get(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public IPagedEnumerable<Book> Get( int page, int pageSize )
        {
            var bookEntities = _bookRepository.Get(page, pageSize);
            var books = bookEntities.Items
                .Select(a => new Book()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Cover = a.ThumbImage,
                });
            return new PagedEnumerable<Book>( books, bookEntities.TotalItemsCount );
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