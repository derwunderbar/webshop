using System;
using System.Web;
using WebShop.Services.Models;

namespace WebShop.Utilities
{
    public class ShoppingCartProvider
    {
        private const string ShoppingCartKey = "shoppingCart";

        private readonly Func<HttpSessionStateBase> _sessionFunc;


        public ShoppingCartProvider( Func<HttpSessionStateBase> sessionFunc )
        {
            _sessionFunc = sessionFunc;
        }

        public ShoppingCart Get()
        {
            return Get( _sessionFunc() );
        }


        private static ShoppingCart Get( HttpSessionStateBase session )
        {
            if( session[ShoppingCartKey] == null )
                session.Add( ShoppingCartKey, new ShoppingCart() );

            return (ShoppingCart)session[ShoppingCartKey];
        }
    }
}