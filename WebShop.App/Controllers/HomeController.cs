using System.Linq;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var bookService = new BookService(new BookRepository());
            var books = bookService.GetAll().Take( 10 );

            return View(books);
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
