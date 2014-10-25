using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;
using WebShop.Utilities;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartProvider _shoppingCartProvider;
        private readonly BookService _bookService;


        public ShoppingCartController()
        {
            _shoppingCartProvider = new ShoppingCartProvider( () => Session );
            _bookService = new BookService( new BookRepository() );
        }


        public ActionResult Index()
        {
            var shoppingCart = _shoppingCartProvider.Get();
            var shoppingCartViewModel = new ShoppingCartViewModel();
            if( shoppingCart.Items.Any() )
            {
                var books = _bookService.Get( shoppingCart.Items.Select( a => a.Id ).ToArray() );
                var shoppingCartItemViewModels = shoppingCart.Items
                    .Select( a =>
                    {
                        var book = books.Single( b => b.Id == a.Id );
                        return new ShoppingCartItemViewModel()
                        {
                            Id = a.Id,
                            Title = book.Title,
                            Price = book.Price,
                            Count = a.Count,
                        };
                    } );

                shoppingCartViewModel.Items = shoppingCartItemViewModels.ToArray();
            }

            return View( shoppingCartViewModel );
        }

        [HttpPost]
        public ActionResult Add( int id )
        {
            var shoppingCart = _shoppingCartProvider.Get();
            shoppingCart.Add( id );
            return Json( "", JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public ActionResult Remove( int id )
        {
            throw new NotImplementedException();
        }
    }
}