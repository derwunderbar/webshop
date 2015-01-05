using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Web.Mvc;
using WebShop.Data.Repositories;
using WebShop.Data.Repositories.Shopping;
using WebShop.Errors;
using WebShop.Filters;
using WebShop.Services;
using WebShop.Services.Catalog;
using WebShop.Services.Models.Shopping;
using WebShop.Utilities;
using WebShop.ViewModels.Shopping;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartProvider _shoppingCartProvider;
        private readonly IBookService _bookService;
        private readonly IOrderService _orderService;
        private readonly IUserRepository _userRepository;
        private readonly IApplicationConfig _appConfig;


        public ShoppingCartController()
        {
            _shoppingCartProvider = new ShoppingCartProvider(() => Session);
            _bookService = new BookService(new BookRepository());
            _orderService = new OrderService(new OrderRepository(), new CustomerRepository());
            _userRepository = new UserRepository();
            _appConfig = new ApplicationConfig();
        }


        public ActionResult Index()
        {
            var shoppingCart = _shoppingCartProvider.Get();
            var shoppingCartVm = GetShoppingCartViewModel(shoppingCart.Items);

            var view = shoppingCartVm.Items.Any()
                ? View(shoppingCartVm)
                : View("IndexEmpty");

            return view;
        }

        public ActionResult Status()
        {
            var shoppingCart = _shoppingCartProvider.Get();
            var totalCount = shoppingCart.TotalItems;
            return PartialView("_Status", totalCount );
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


        public ActionResult CheckoutOverview()
        {
            var shoppingCart = _shoppingCartProvider.Get();
            var checkoutWizardVm = GetCheckoutWizardViewModel(shoppingCart.Items);
            return View(checkoutWizardVm);
        }

        [HttpPost]
        public ActionResult CheckoutOverview([Deserialize] CheckoutViewModel checkoutVm, [Deserialize] CustomerViewModel customerVm)
        {
            if( ModelState.IsValid )
            {
                CheckoutWizardViewModel checkoutWizardUpdate;
                if( IsShoppingCartChanged(checkoutVm, customerVm, out checkoutWizardUpdate) )
                    return View(checkoutWizardUpdate);

                if( !User.Identity.IsAuthenticated )
                {
                    var modelCrossRequestProvider = new ModelCrossRequestProvider(TempData);
                    modelCrossRequestProvider.Set(checkoutVm);
                    return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("CheckoutCustomer") });
                }

                var checkoutWizardVm = new CheckoutWizardViewModel()
                {
                    ShoppingCart = checkoutVm,
                    Customer = GetCustomerViewModel(customerVm),
                };
                return View("CheckoutCustomer", checkoutWizardVm);
            }

            var checkoutWizardVm2 = new CheckoutWizardViewModel()
            {
                ShoppingCart = checkoutVm,
                Customer = customerVm,
            };
            return View(checkoutWizardVm2);
        }

        [Authorize]
        public ActionResult CheckoutCustomer()
        {
            var modelCrossRequestProvider = new ModelCrossRequestProvider(TempData);
            var checkoutVm = modelCrossRequestProvider.Get<CheckoutViewModel>();
            var checkoutWizardVm = new CheckoutWizardViewModel()
            {
                ShoppingCart = checkoutVm,
                Customer = GetCustomerViewModel(),
            };
            return View(checkoutWizardVm);
        }

        [HttpPost]
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult CheckoutSubmit(CustomerViewModel customer, [Deserialize] CheckoutViewModel checkoutVm)
        {
            if( ModelState.IsValid )
            {
                CheckoutWizardViewModel checkoutWizardUpdate;
                if( IsShoppingCartChanged(checkoutVm, customer, out checkoutWizardUpdate) )
                    return View("CheckoutOverview", checkoutWizardUpdate);

                var user = _userRepository.Get(User.Identity.Name);
                if( user == null )
                    throw ExceptionFactory.GetInvalidUserException(User.Identity.Name);

                var orderModel = Mapper.Map<OrderModel>(checkoutVm);
                orderModel.UserId = user.UserId;
                var customerModel = Mapper.Map<CustomerModel>(customer);
                _orderService.Create(orderModel, customerModel);
                
                var shoppingCart = _shoppingCartProvider.Get();
                shoppingCart.Clear();

                return RedirectToAction("ThankYou");
            }
            
            var checkoutWizardVm = new CheckoutWizardViewModel()
            {
                ShoppingCart = checkoutVm,
                Customer = customer,
            };
            return View("CheckoutCustomer", checkoutWizardVm);
        }

        public ActionResult ThankYou()
        {
            return View();
        }


        private bool IsShoppingCartChanged(CheckoutViewModel checkoutVm, CustomerViewModel customer, out CheckoutWizardViewModel checkoutWizardVm)
        {
            var shoppingCart = _shoppingCartProvider.Get();
            var shoppingCartEqualityComparer = new ShoppingCartEqualityComparer();
            if( !shoppingCartEqualityComparer.Equals(shoppingCart, checkoutVm) )
            {
                ModelState.AddModelError(string.Empty, ModelErrors.ShoppingCartWasChanged);
                checkoutWizardVm = GetCheckoutWizardViewModel(shoppingCart.Items, customer);
                return true;
            }

            checkoutWizardVm = null;
            return false;
        }


        private IEnumerable<ShoppingCartItemViewModel> GetShoppingCartItemViewModels( ShoppingCartItem[] shoppingCartItems )
        {
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

                return shoppingCartItemViewModels;
            }

            return Enumerable.Empty<ShoppingCartItemViewModel>();
        }

        private ShoppingCartViewModel GetShoppingCartViewModel(ShoppingCartItem[] shoppingCartItems)
        {
            return new ShoppingCartViewModel()
            {
                Items = GetShoppingCartItemViewModels(shoppingCartItems).ToArray(),
            };
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

        private CheckoutWizardViewModel GetCheckoutWizardViewModel(ShoppingCartItem[] shoppingCartItems, CustomerViewModel customerVm = null)
        {
            return new CheckoutWizardViewModel()
            {
                ShoppingCart = new CheckoutViewModel(_appConfig.VatPercents)
                {
                    Items = GetShoppingCartItemViewModels(shoppingCartItems).ToList(),
                },
                Customer = GetCustomerViewModel(customerVm),
            };
        }


        private static CustomerViewModel GetCustomerViewModel(CustomerViewModel customerVm = null)
        {
#if TESTING
            return customerVm
                ?? new CustomerViewModel()
                {
                    Title = "Good-Company",
                    FirstName = "John",
                    LastName = "Johnson",
                    Email = "john_johnson@good_company.com",
                    City = "City",
                    Address = "Address",
                    HouseNumber = "10",
                    ZipCode = "12121-1234",
                };
#endif

            return customerVm ?? new CustomerViewModel();
        }
    }
}