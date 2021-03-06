using System.Linq;
using AutoMapper;
using WebShop.Data.Entities.Shopping;
using WebShop.Services;
using WebShop.Services.Catalog;
using WebShop.Services.Models.Catalog;
using WebShop.ViewModels;
using WebShop.ViewModels.Catalog;

namespace WebShop.Utilities
{
    public interface ICatalogFacade
    {
        PagedEnumerableViewModel<BookViewModel> GetBooks(int? page);
        BookDetailsViewModel GetBook(int id);
        AuthorDetails GetAuthor(int id);
    }

    public class CatalogFacade : ICatalogFacade
    {
        private const int PageSize = 10;

        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IApplicationConfig _appConfig;

        public CatalogFacade(IServiceFactory serviceFactory, IApplicationConfig appConfig)
        {
            _bookService = serviceFactory.GetBookService();
            _authorService = serviceFactory.GetAuthorService();
            _appConfig = appConfig;
        }

        public PagedEnumerableViewModel<BookViewModel> GetBooks(int? page)
        {
            var pageInner = page ?? 1;
            var booksPage = _bookService.Get(pageInner, PageSize);
            var books = booksPage.Items.ToArray();

            var imageUrlProvider = new ImageUrlProvider();
            foreach (var book in books)
                book.Cover = imageUrlProvider.GetUrl(_appConfig.BookThumbsVirtualPath, book.Cover);

            var viewModel = new PagedEnumerableViewModel<BookViewModel>()
            {
                PageNumber = pageInner,
                PageSize = PageSize,
                Items = books.Select(a => Mapper.Map<BookViewModel>(a)),
                TotalItemsCount = booksPage.TotalItemsCount,
            };

            return viewModel;
        }

        public BookDetailsViewModel GetBook(int id)
        {
            var book = _bookService.Get(id);

            if (book == null)
                return null;

            var imageUrlProvider = new ImageUrlProvider();
            var viewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Cover = imageUrlProvider.GetUrl(_appConfig.BookImagesVirtualPath, book.Cover),
                Author = Mapper.Map<AuthorViewModel>(book.Author),
                Publisher = Mapper.Map<PublisherViewModel>(book.Publisher),
                Description = book.Description,
            };

            return viewModel;
        }

        public AuthorDetails GetAuthor(int id)
        {
            var author = _authorService.Get(id);
            if (author == null)
                return null;

            var imageUrlProvider = new ImageUrlProvider();
            var books = author.Books.ToArray();
            foreach (var book in books)
                book.Cover = imageUrlProvider.GetUrl(_appConfig.BookThumbsVirtualPath, book.Cover);
            author.Books = books;

            return author;
        }
    }
}