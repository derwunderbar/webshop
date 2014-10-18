using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;
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
            _bookService = new BookService(new BookRepository());
            _authorService = new AuthorService(new AuthorRepository());
            _appConfig = new ApplicationConfig();
        }

        public ActionResult Index()
        {
            var books = _bookService.GetAll().Take( 10 );

            return View( books );
        }

        public ActionResult Details(int id)
        {
            var book = _bookService.Get(id);

            if (book == null)
                throw new HttpException(404, "Not Found");

            var imageUrlProvider = new ImageUrlProvider();
            var viewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Cover = imageUrlProvider.GetUrl(_appConfig.BookImagesVirtualPath, book.Cover),
                Author = book.Author,
                Publisher = book.Publisher,
                Description = book.Description,
            };
            
            return View(viewModel);
        }

        public ActionResult Author(int id)
        {
            var author = _authorService.Get(id);
            var imageUrlProvider = new ImageUrlProvider();
            author.Avatar = imageUrlProvider.GetUrl(_appConfig.AuthorImagesVirtualPath, author.Avatar);
            foreach (var book in author.Books)
                book.Cover = imageUrlProvider.GetUrl(_appConfig.BookThumbsVirtualPath, book.Cover);
            
            return View(author);
        }
    }
}
