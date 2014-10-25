using System.Linq;

namespace WebShop.Services.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new ShoppingCartItem[0];
        }

        public ShoppingCartItem[] Items { get; set; }

        public int TotalItems { get; set; }

        public void Add( int id )
        {
            var shoppingCartItem = Items.SingleOrDefault( a => a.Id == id );
            if( shoppingCartItem == null )
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Id = id,
                    Count = 1,
                };

                var items = Items.ToList();
                items.Add( shoppingCartItem );
                Items = items.ToArray();
            }
            else
            {
                shoppingCartItem.Count++;
            }
        }
    }

    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Count { get; set; }
    }
}