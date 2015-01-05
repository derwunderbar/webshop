using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Services.Models
{
    public class ShoppingCartItemsEqualityComparer : IEqualityComparer<ShoppingCartItem[]>
    {
        public bool Equals(ShoppingCartItem[] a, ShoppingCartItem[] b)
        {
            if( ReferenceEquals(a, b) )
                return true;

            if( a == null || b == null )
                return false;

            if( a.Length != b.Length )
                return false;

            return a.All(e1 => b.SingleOrDefault(e2 => e2 == e1) != null);
        }

        public int GetHashCode(ShoppingCartItem[] items)
        {
            if( items == null )
                throw new ArgumentNullException("items");

            return items.Aggregate(0, (accumulated, next) => (accumulated * 367) + next.GetHashCode());
        }
    }
}