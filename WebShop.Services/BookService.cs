using System.Collections.Generic;
using System.Linq;
using WebShop.Data;

namespace WebShop.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
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
                .Select( a => new Book()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Author = null,
                    Price = a.Price,
                    ThumbImage = a.ThumbImage,
                    TitleImage = a.TitleImage,
                } );
            return books;
        }
    }
}