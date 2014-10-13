using System;
using System.Configuration;
using System.Diagnostics;

namespace WebShop
{
    public interface IApplicationConfig
    {
        string ImageVirtualPath { get; }

        string ThumbVirtualPath { get; }
    }

    public class ApplicationConfig : IApplicationConfig
    {
        private const string ThumbPathKey = "ThumbVirtualPath";
        private const string ImagePathKey = "ImageVirtualPath";

        private static readonly Lazy<string> _thumbPathLazy = new Lazy<string>( () => GetConfigurationParameter( ThumbPathKey ) );
        private static readonly Lazy<string> _imagePathLazy = new Lazy<string>( () => GetConfigurationParameter( ImagePathKey ) );
     

        public string ImageVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _imagePathLazy.Value;
            }
        }

        public string ThumbVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _thumbPathLazy.Value;
            }
        }


        private static string GetConfigurationParameter( string key )
        {
            return ConfigurationManager.AppSettings.Get( key );
        }
    }
}