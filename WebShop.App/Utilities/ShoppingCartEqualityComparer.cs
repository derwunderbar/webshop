using System.Linq;
using WebShop.Services.Models;
using WebShop.ViewModels;

namespace WebShop.Utilities
{
    public class ShoppingCartEqualityComparer
    {
        public bool Equals(ShoppingCart shoppingCart, CheckoutViewModel checkoutVm)
        {
            if( checkoutVm.Items.Count != shoppingCart.Items.Count() )
                return false;

            var itemsEqualityComparer = new ShoppingCartItemsEqualityComparer();
            var checkoutItems = checkoutVm.Items
                .Select(a =>
                    new ShoppingCartItem()
                    {
                        Id = a.Id,
                        Count = a.Count
                    })
                .ToArray();
            return itemsEqualityComparer.Equals(shoppingCart.Items, checkoutItems);
        }
    }
}