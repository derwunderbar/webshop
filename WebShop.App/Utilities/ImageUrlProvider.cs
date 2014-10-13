namespace WebShop.Utilities
{
    public class ImageUrlProvider
    {
        public string GetUrl( string virtualPath, string fileName )
        {
            var baseUrl = virtualPath.TrimStart( '~' );
            return UrlHelpers.Combine( baseUrl, fileName );
        }
    }
}