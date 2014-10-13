using System.Linq;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;
using WebShop.Utilities;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IApplicationConfig _appConfig;

        public HomeController()
        {
            _bookService = new BookService( new BookRepository() );
            _appConfig = new ApplicationConfig();
        }

        public ActionResult Index()
        {
            var books = _bookService.GetAll().Take( 23 );

            var thumbVirtualPath = _appConfig.ThumbVirtualPath;
            var imageUrlProvider = new ImageUrlProvider();
            var viewModels = books.Select( a =>
                new CatalogBookViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Thumb = imageUrlProvider.GetUrl( thumbVirtualPath, a.ThumbImage ),
                } );

            return View( viewModels );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
