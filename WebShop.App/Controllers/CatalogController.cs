using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;
using WebShop.Services.Models;
using WebShop.Utilities;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IApplicationConfig _appConfig;

        public CatalogController()
        {
            _bookService = new BookService( new BookRepository() );
            _authorService = new AuthorService( new AuthorRepository() );
            _appConfig = new ApplicationConfig();
        }

        public ActionResult Index( int? page )
        {
            var viewModel = new PageViewModel() { PageNumber = page };
            return View( viewModel );
        }

        public PartialViewResult BookListViewPartial( int? page )
        {
            const int pageSize = 10;
            var pageInner = page ?? 1;
            var booksPage = _bookService.Get( pageInner, pageSize );
            var books = booksPage.Items.ToArray();

            var imageUrlProvider = new ImageUrlProvider();
            foreach( var book in books )
                book.Cover = imageUrlProvider.GetUrl( _appConfig.BookThumbsVirtualPath, book.Cover );

            var viewModel = new PagedEnumerableViewModel<Book>()
            {
                PageNumber = pageInner,
                PageSize = pageSize,
                Items = books,
                TotalItemsCount = booksPage.TotalItemsCount,
            };
            return PartialView( "_BookListViewPagedPartial", viewModel );
        }

        public ActionResult Details( int id )
        {
            var book = _bookService.Get( id );

            if( book == null )
                throw new HttpException( 404, "Not Found" );

            var imageUrlProvider = new ImageUrlProvider();
            var viewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Cover = imageUrlProvider.GetUrl( _appConfig.BookImagesVirtualPath, book.Cover ),
                Author = book.Author,
                Publisher = book.Publisher,
                Description = book.Description,
            };

            return View( viewModel );
        }

        public ActionResult Author( int id )
        {
            var author = _authorService.Get( id );
            var imageUrlProvider = new ImageUrlProvider();
            var books = author.Books.ToArray();
            foreach( var book in books )
                book.Cover = imageUrlProvider.GetUrl( _appConfig.BookThumbsVirtualPath, book.Cover );
            author.Books = books;

            return View( author );
        }
    }
}