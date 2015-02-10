using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebShop.Core.Collections.Generic;
using WebShop.Data.Contexts;
using WebShop.Data.Entities;
using WebShop.Data.Entities.Catalog;

namespace WebShop.Data.Repositories.Catalog
{
    public interface IBookRepository
    {
        IPagedEnumerable<BookEntity> Get(int page, int pageSize);

        IEnumerable<BookEntity> Get(int[] ids);

        BookDetailsEntity Get(int id);
    }

    public class BookRepository : IBookRepository
    {
        public IPagedEnumerable<BookEntity> Get(int page, int pageSize)
        {
            var context = new CatalogContext();
            var books = context.GetBooks();
            
            var resultBooksForTitleUpdate = books.ToArray();
            for (var i = 0; i < resultBooksForTitleUpdate.Length; i++)
            {
                var bookEntity = resultBooksForTitleUpdate[i];
                bookEntity.Title = String.Format("{0} {1}", i + 1, bookEntity.Title);
            }

            books = resultBooksForTitleUpdate
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var totalCount = resultBooksForTitleUpdate.Count();

            return new PagedEnumerable<BookEntity>(books, totalCount);
        }

        public IEnumerable<BookEntity> Get(int[] ids)
        {
            var context = new CatalogContext();
            var books = context.GetBooks()
                .Where(a => ids.Contains(a.Id));

            return books;
        }

        public BookDetailsEntity Get(int id)
        {
            var context = new CatalogContext();
            var bookEntity = context.GetBooks().SingleOrDefault(a => a.Id == id);
            if (bookEntity == null)
                return null;

            var bookAuthor = context.GetAuthorBooks().FirstOrDefault(a => a.BookId == bookEntity.Id);
            if (bookAuthor == null)
                throw new InvalidDataException("Book has no author(s)");

            var bookPublisher = context.GetPublisherBooks().FirstOrDefault(a => a.BookId == bookEntity.Id);
            if (bookPublisher == null)
                throw new InvalidDataException("Book has no publisher(s)");

            var bookDetails = new BookDetailsEntity()
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Price = bookEntity.Price,
                ThumbImage = bookEntity.ThumbImage,
                TitleImage = bookEntity.TitleImage,
                Author = context.GetAuthors().FirstOrDefault(a => a.Id == bookAuthor.AuthorId),
                Publisher = context.GetPublishers().FirstOrDefault(a => a.Id == bookPublisher.PublisherId),
                Description = bookEntity.Description,
            };

            return bookDetails;
        }
    }
}