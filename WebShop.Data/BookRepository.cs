using System.Collections.Generic;
using System.Linq;
using WebShop.Data.Entities;

namespace WebShop.Data
{
    public interface IBookRepository
    {
        IEnumerable<BookEntity> GetAll();

        BookDetailsEntity Get(int id);
    }

    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookEntity> GetAll()
        {
            // todo: query data from db
            var books = EntityStubs.GetBooks();
            var resultBooks = books;
            for( var i = 0; i < 10; i++ )
                resultBooks = resultBooks.Concat( resultBooks );

            return resultBooks;
        }

        public BookDetailsEntity Get(int id)
        {
            // todo: query data from db
            var bookEntity = GetAll().FirstOrDefault(a => a.Id == id);
            if (bookEntity == null)
                return null;

            var bookDetails = new BookDetailsEntity()
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Price = bookEntity.Price,
                ThumbImage = bookEntity.ThumbImage,
                TitleImage = bookEntity.TitleImage,
                Author = EntityStubs.GetAuthor(),
                Publisher = EntityStubs.GetPublisher(),
                Description = "Couple of words about the book",
            };

            return bookDetails;
        }
    }
}