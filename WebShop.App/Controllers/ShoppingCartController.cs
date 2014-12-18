using System;
using System.Linq;
using System.Web.Mvc;
using WebShop.Data;
using WebShop.Services;
using WebShop.Services.Models;
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
            var shoppingCartVm = GetShoppingCartViewModel(shoppingCart.Items);
            
            var view = shoppingCartVm.Items.Any()
                ? View( shoppingCartVm )
                : View( "IndexEmpty" );

            return view;
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            var shoppingCart = _shoppingCartProvider.Get();
            shoppingCart.Add(id);

            var shoppingCartUpdate = GetShoppingCartUpdate(shoppingCart.Items, id);
            return Json(shoppingCartUpdate, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove( int id )
        {
            var shoppingCart = _shoppingCartProvider.Get();
            shoppingCart.Remove( id );

            var shoppingCartUpdate = GetShoppingCartUpdate( shoppingCart.Items, id );
            return Json( shoppingCartUpdate, JsonRequestBehavior.AllowGet );
        }

        private ShoppingCartViewModel GetShoppingCartViewModel(ShoppingCartItem[] shoppingCartItems)
        {
            var shoppingCartViewModel = new ShoppingCartViewModel();
            if( shoppingCartItems.Any() )
            {
                var books = _bookService.Get( shoppingCartItems.Select( a => a.Id ).ToArray() );
                var shoppingCartItemViewModels = shoppingCartItems
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

            return shoppingCartViewModel;
        }

        private ShoppingCartUpdateViewModel GetShoppingCartUpdate(ShoppingCartItem[] shoppingCartItems, int updatedItemId)
        {
            var shoppingCartVm = GetShoppingCartViewModel(shoppingCartItems);
            var itemUpdate = shoppingCartVm.Items.SingleOrDefault(a => a.Id == updatedItemId);
            if( itemUpdate == null )
            {
                // The last item for id was removed from shopping cart
                itemUpdate = new ShoppingCartItemViewModel()
                {
                    Id = updatedItemId,
                    Title = null,
                    Count = 0,
                    Price = 0
                };
            }

            var shoppingCartUpdate = new ShoppingCartUpdateViewModel()
            {
                UpdatedItem = itemUpdate,
                TotalItems = shoppingCartVm.TotalItems,
                TotalPrice = shoppingCartVm.TotalPrice,
            };

            return shoppingCartUpdate;
        }
    }
}