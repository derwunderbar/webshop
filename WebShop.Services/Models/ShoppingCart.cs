using System;
using System.Diagnostics;
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

        public int TotalItems
        {
            [DebuggerStepThrough]
            get { return Items != null ? Items.Sum(a => a.Count) : 0; }
        }


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

        public void Remove( int id )
        {
            var shoppingCartItem = Items.SingleOrDefault(a => a.Id == id);
            if( shoppingCartItem == null )
                throw new InvalidOperationException();

            if(shoppingCartItem.Count == 0)
                throw new InvalidOperationException();

            shoppingCartItem.Count--;
            if( shoppingCartItem.Count == 0 )
                Items = Items.Where(a => a.Id != id).ToArray();
        }
    }
}