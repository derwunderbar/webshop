using System;

namespace WebShop.Utilities
{
    public class UrlHelpers
    {
        public static string Combine( string url1, string url2 )
        {
            if(url1 == null)
                throw new ArgumentNullException("url1");

            if(url2 == null)
                throw new ArgumentNullException("url2");

            if( url1.Length == 0 )
                return url2;

            if( url2.Length == 0 )
                return url1;

            url1 = url1.TrimEnd( '/', '\\' );
            url2 = url2.TrimStart( '/', '\\' );

            return String.Format( "{0}/{1}", url1, url2 );
        }
    }
}