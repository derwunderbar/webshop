using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var bookService = new BookService( new BookRepository() );
            var books = bookService.GetAll().Take( 10 );

            return View( books );
        }

        public ActionResult Details(int id)
        {
            if(id != 1)
                throw new HttpException(404, "Not Found");

            return View(new Book());
        }
    }
}
