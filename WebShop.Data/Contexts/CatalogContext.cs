using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WebShop.Data.Entities;
using WebShop.Data.Entities.Catalog;
using WebShop.Data.Entities.Catalog.XmlContainers;

namespace WebShop.Data.Contexts
{
    public class CatalogContext
    {
        private const string DataDirectory = "|DataDirectory|";
        private const string BooksPath = @"books.xml";
        private const string AuthorBooksPath = @"author-books.xml";
        private const string PublisherBooksPath = @"publisher-books.xml";

        private readonly string _path;

        public CatalogContext()
            : this(ApplicationConfig.CatalogPath)
        {
        }

        public CatalogContext(string path)
        {
            _path = path;
        }


        public IEnumerable<BookEntity> GetBooks()
        {
            var catalog = Get<BooksCatalog>(GetFilePath(_path, BooksPath));
            return catalog.Books;
        }

        public IEnumerable<AuthorEntity> GetAuthors()
        {
            var catalog = Get<AuthorBooksCatalog>(GetFilePath(_path, AuthorBooksPath));
            return catalog.Authors;
        }

        public IEnumerable<BookAuthorEntity> GetAuthorBooks()
        {
            var catalog = Get<AuthorBooksCatalog>(GetFilePath(_path, AuthorBooksPath));
            return catalog.BookAuthors;
        }

        public IEnumerable<PublisherEntity> GetPublishers()
        {
            var catalog = Get<PublisherBooksCatalog>(GetFilePath(_path, PublisherBooksPath));
            return catalog.Publishers;
        }

        public IEnumerable<BookPublisherEntity> GetPublisherBooks()
        {
            var catalog = Get<PublisherBooksCatalog>(GetFilePath(_path, PublisherBooksPath));
            return catalog.BookPublishers;
        }


        private static T Get<T>(string path)
        {
            var physicalPath = path;
            if (physicalPath.Contains(DataDirectory))
            {
                var dataDirectoryValue = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
                if (dataDirectoryValue != null)
                    physicalPath = physicalPath.Replace(DataDirectory, dataDirectoryValue);
                else
                    throw new InvalidOperationException("DataDirectory is undefined");
            }

            var serializer = new XmlSerializer(typeof (T));
            using (var reader = new StreamReader(physicalPath))
            {
                var result = (T) serializer.Deserialize(reader);
                return result;
            }
        }

        private static string GetFilePath(string directoryPath, string fileName)
        {
            return directoryPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? directoryPath + fileName : directoryPath + Path.DirectorySeparatorChar + fileName;
        }
    }
}