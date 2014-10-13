using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace WebShop.Extensions
{
    public static class HtmlHelperExtensions
    {
        private const string ImageTag = "<img src=\"{0}\"/>";

        public static IHtmlString ImageActionLink( this HtmlHelper htmlHelper, string imageUrl, string actionName, string controllerName, RouteValueDictionary routeValues )
        {
            const string fakeContent = "[fakeContent]";

            var link = htmlHelper
                .ActionLink( fakeContent, actionName, controllerName, routeValues, null )
                .ToHtmlString()
                .Replace( fakeContent, String.Format( ImageTag, imageUrl ) );
            
            return htmlHelper.Raw( link );
        }
    }
}