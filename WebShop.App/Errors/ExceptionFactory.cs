using System;
using System.Web;

namespace WebShop.Errors
{
    public static class ExceptionFactory
    {
        public static Exception GetInvalidUserException(string userName)
        {
            return new InvalidOperationException(String.Format("User {0} not found", userName));
        }

        public static Exception GetHttpNotFoundException()
        {
            return new HttpException(404, "Not Found");
        }
    }
}