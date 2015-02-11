using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using WebShop.Data.Contexts.Validation;
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
            var catalog = Get<BooksCatalog>(GetFilePath(_path, BooksPath), ValidationSchemas.Books);
            return catalog.Books;
        }

        public IEnumerable<AuthorEntity> GetAuthors()
        {
            var catalog = Get<AuthorBooksCatalog>(GetFilePath(_path, AuthorBooksPath), ValidationSchemas.AuthorBooks);
            return catalog.Authors;
        }

        public IEnumerable<BookAuthorEntity> GetAuthorBooks()
        {
            var catalog = Get<AuthorBooksCatalog>(GetFilePath(_path, AuthorBooksPath), ValidationSchemas.AuthorBooks);
            return catalog.BookAuthors;
        }

        public IEnumerable<PublisherEntity> GetPublishers()
        {
            var catalog = Get<PublisherBooksCatalog>(GetFilePath(_path, PublisherBooksPath), ValidationSchemas.PublisherBooks);
            return catalog.Publishers;
        }

        public IEnumerable<BookPublisherEntity> GetPublisherBooks()
        {
            var catalog = Get<PublisherBooksCatalog>(GetFilePath(_path, PublisherBooksPath), ValidationSchemas.PublisherBooks);
            return catalog.BookPublishers;
        }


        private static T Get<T>(string path, XmlSchema schema)
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

            using (var memoryStream = new MemoryStream(File.ReadAllBytes(physicalPath)))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(memoryStream);
                EnsureIsValid(xmlDoc, schema);

                var serializer = new XmlSerializer(typeof(T));
                memoryStream.Position = 0;
                using (var reader = new StreamReader(memoryStream))
                {
                    var result = (T)serializer.Deserialize(reader);
                    return result;
                }
            }
        }

        private static string GetFilePath(string directoryPath, string fileName)
        {
            return directoryPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? directoryPath + fileName : directoryPath + Path.DirectorySeparatorChar + fileName;
        }

        private static void EnsureIsValid(XmlDocument xmlDocument, XmlSchema schema)
        {
            xmlDocument.Schemas.Add(schema);
            xmlDocument.Validate((sender, e) =>
            {
                if (e.Severity == XmlSeverityType.Error)
                {
                    throw new ValidationException(e.Message, e.Exception);
                }
            });
        }
    }
}