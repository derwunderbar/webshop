using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Schema;
using WebShop.Core.Resources;

namespace WebShop.Data.Contexts.Validation
{
    public class ValidationSchemas
    {
        private const string BooksResourceKey = "WebShop.Data.Contexts.Validation.ValidationSchemas.books.xsd";
        private const string AuthorBooksResourceKey = "WebShop.Data.Contexts.Validation.ValidationSchemas.author-books.xsd";
        private const string PublisherBooksResourceKey = "WebShop.Data.Contexts.Validation.ValidationSchemas.publisher-books.xsd";


        private static readonly IResourceProvider _resourdeProvider = new ResourceProviderCachingDecorator(new ResourceProvider(Assembly.GetExecutingAssembly()));


        public static XmlSchema Books
        {
            [DebuggerStepThrough]
            get { return GetSchema(_resourdeProvider.Get(BooksResourceKey)); }
        }

        public static XmlSchema AuthorBooks
        {
            [DebuggerStepThrough]
            get { return GetSchema(_resourdeProvider.Get(AuthorBooksResourceKey)); }
        }

        public static XmlSchema PublisherBooks
        {
            [DebuggerStepThrough]
            get { return GetSchema(_resourdeProvider.Get(PublisherBooksResourceKey)); }
        }


        private static XmlSchema GetSchema(string xsd)
        {
            var schema = XmlSchema.Read(new StringReader(xsd),
                (sender, e) =>
                {
                    throw new InvalidOperationException("Invalid xsd schema", e.Exception);
                });

            return schema;
        }
    }
}