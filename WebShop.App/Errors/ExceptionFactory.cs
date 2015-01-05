using System;

namespace WebShop.Errors
{
    public static class ExceptionFactory
    {
        public static Exception GetInvalidUserException(string userName)
        {
            return new InvalidOperationException(String.Format("User {0} not found", userName));
        }
    }
}