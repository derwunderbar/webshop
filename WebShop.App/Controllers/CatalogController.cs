using System.Web.Mvc;
using WebShop.Errors;
using WebShop.Utilities;
using WebShop.ViewModels.Catalog;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogFacade _catalogFacade;

        public CatalogController(ICatalogFacade catalogFacade)
        {
            _catalogFacade = catalogFacade;
        }

        public ActionResult Index(int? page)
        {
            var viewModel = new PageViewModel() { PageNumber = page };
            return View(viewModel);
        }

        public PartialViewResult BookListViewPartial(int? page)
        {
            var books = _catalogFacade.GetBooks(page);
            if (books.TotalItemsCount == 0 || (books.PageNumber - 1) * books.PageSize + 1 > books.TotalItemsCount)
                throw ExceptionFactory.GetHttpNotFoundException();

            return PartialView("_BookListViewPagedPartial", books);
        }

        public ActionResult Details(int id)
        {
            var book = _catalogFacade.GetBook(id);
            if (book == null)
                throw ExceptionFactory.GetHttpNotFoundException();

            return View(book);
        }

        public ActionResult Author(int id)
        {
            var author = _catalogFacade.GetAuthor(id);
            if (author == null)
                throw ExceptionFactory.GetHttpNotFoundException();

            return View(author);
        }
    }
}