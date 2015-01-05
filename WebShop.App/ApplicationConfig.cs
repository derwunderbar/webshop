using System;
using System.Configuration;
using System.Diagnostics;

namespace WebShop
{
    public interface IApplicationConfig
    {
        string BookImagesVirtualPath { get; }

        string BookThumbsVirtualPath { get; }

        string AuthorImagesVirtualPath { get; }

        string PublisherImagesVirtualPath { get; }

        float VatPercents { get; }
    }

    public class ApplicationConfig : IApplicationConfig
    {
        private const string BookImagesPathKey = "BookImagesVirtualPath";
        private const string BookThumbsPathKey = "BookThumbsVirtualPath";
        private const string AuthorImagesPathKey = "AuthorImagesVirtualPath";
        private const string PublisherImagesPathKey = "PublisherImagesVirtualPath";
        private const string VatPercentsKey = "VatPercents";

        private static readonly Lazy<string> _bookImagesPathLazy = new Lazy<string>(() => GetConfigurationParameter(BookImagesPathKey));
        private static readonly Lazy<string> _bookThumbsPathLazy = new Lazy<string>( () => GetConfigurationParameter( BookThumbsPathKey ) );
        private static readonly Lazy<string> _authorImagesPathLazy = new Lazy<string>( () => GetConfigurationParameter( AuthorImagesPathKey ) );
        private static readonly Lazy<string> _publisherImagesPathLazy = new Lazy<string>( () => GetConfigurationParameter( PublisherImagesPathKey ) );
        private static readonly Lazy<float> _vatPercentsLazy = new Lazy<float>(() => float.Parse(GetConfigurationParameter(VatPercentsKey)));
     

        public string BookImagesVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _bookImagesPathLazy.Value;
            }
        }

        public string BookThumbsVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _bookThumbsPathLazy.Value;
            }
        }

        public string AuthorImagesVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _authorImagesPathLazy.Value;
            }
        }

        public string PublisherImagesVirtualPath
        {
            [DebuggerStepThrough]
            get
            {
                return _publisherImagesPathLazy.Value;
            }
        }

        public float VatPercents
        {
            [DebuggerStepThrough]
            get
            {
                return _vatPercentsLazy.Value;
            }
        }


        private static string GetConfigurationParameter( string key )
        {
            return ConfigurationManager.AppSettings.Get( key );
        }
    }
}