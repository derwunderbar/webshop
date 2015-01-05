using System;

namespace WebShop.Services.Models.Shopping
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Count { get; set; }


        public override bool Equals(object obj)
        {
            if( obj == null || !(obj is ShoppingCartItem) )
                return false;

            if( ReferenceEquals(this, obj) )
                return true;

            var other = (ShoppingCartItem)obj;
            return Id == other.Id && Count == other.Count;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 367) ^ Count;
            }
        }

        public override string ToString()
        {
            return String.Format("Id = {0}, Count = {1}", Id, Count);
        }


        public static bool operator ==(ShoppingCartItem a, ShoppingCartItem b)
        {
            if( ReferenceEquals(a, b) )
                return true;

            // Cast to object to avoid recursion
            if( (object)a == null || (object)b == null )
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ShoppingCartItem a, ShoppingCartItem b)
        {
            return !(a == b);
        }
    }
}