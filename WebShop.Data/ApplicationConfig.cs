using System;
using System.Configuration;
using System.Diagnostics;

namespace WebShop.Data
{
    internal static class ApplicationConfig
    {
        private const string CatalogPathKey = "CatalogPath";

        private static readonly Lazy<string> _catalogPathLazy = new Lazy<string>(() => ConfigurationManager.AppSettings.Get( CatalogPathKey));

        internal static string CatalogPath
        {
            [DebuggerStepThrough]
            get
            {
                return _catalogPathLazy.Value;
            }
        }
    }
}