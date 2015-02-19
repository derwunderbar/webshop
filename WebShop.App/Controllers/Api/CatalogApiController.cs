using System.Net;
using System.Web.Http;
using WebShop.Utilities;
using WebShop.ViewModels.Catalog;

namespace WebShop.Controllers.Api
{
    [RoutePrefix("api/catalog")]
    public class CatalogApiController : ApiController
    {
        private readonly ICatalogFacade _catalogFacade;

        public CatalogApiController(ICatalogFacade catalogFacade)
        {
            _catalogFacade = catalogFacade;
        }

        [Route("{page:int?}")]
        public PagedEnumerableViewModel<BookViewModel> GetBooks(int page = 1)
        {
            var books = _catalogFacade.GetBooks(page);
            if (books.TotalItemsCount == 0 || (books.PageNumber - 1) * books.PageSize + 1 > books.TotalItemsCount)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return books;
        }

        [Route("book/{id}")]
        public BookDetailsViewModel GetBook(int id)
        {
            var book = _catalogFacade.GetBook(id);
            if(book == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return book;
        }
    }
}
