using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Core.Collections.Generic;
using WebShop.Data.Repositories;
using WebShop.Services.Models.Catalog;

namespace WebShop.Services.Catalog
{
    public interface IBookService
    {
        IPagedEnumerable<Book> Get( int page, int pageSize );

        IEnumerable<Book> Get(int[] ids);

        BookDetails Get( int id );
    }

    public class BookService : IBookService
    {
        private const string DefaultDescription = "This book has no description yet.";

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

        public IEnumerable<Book> Get( int[] ids )
        {
            var bookEntities = _bookRepository.Get( ids );
            var books = bookEntities
                .Select( a => new Book()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Cover = a.ThumbImage,
                } );

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
                Description = !String.IsNullOrEmpty(entity.Description) ? entity.Description : DefaultDescription,
            };

            return bookDetails;
        }
    }
}