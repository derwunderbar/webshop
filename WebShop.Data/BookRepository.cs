using System;
using System.Linq;
using WebShop.Core.Collections.Generic;
using WebShop.Data.Entities;

namespace WebShop.Data
{
    public interface IBookRepository
    {
        IPagedEnumerable<BookEntity> Get( int page, int pageSize );

        BookDetailsEntity Get(int id);
    }

    public class BookRepository : IBookRepository
    {
        public IPagedEnumerable<BookEntity> Get( int page, int pageSize )
        {
            // todo: query data from db
            var books = EntityStubs.GetBooks();

            while( books.Count() < 43 )
                books = books.Concat( EntityStubs.GetBooks() );

            var resultBooksForTitleUpdate = books.ToArray();
            for( var i = 0; i < resultBooksForTitleUpdate.Length; i++ )
            {
                var bookEntity = resultBooksForTitleUpdate[i];
                bookEntity.Title = String.Format( "{0} {1}", i + 1, bookEntity.Title );
            }

            books = resultBooksForTitleUpdate
                .Skip( (page - 1) * pageSize )
                .Take( pageSize );

            var totalCount = resultBooksForTitleUpdate.Count();

            return new PagedEnumerable<BookEntity>(books, totalCount);
        }

        public BookDetailsEntity Get(int id)
        {
            // todo: query data from db
            var bookEntity = EntityStubs.GetBooks().FirstOrDefault( a => a.Id == id );
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