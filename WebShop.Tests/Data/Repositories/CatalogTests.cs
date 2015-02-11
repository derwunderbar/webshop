using System.Linq;
using NUnit.Framework;
using WebShop.Core.Collections.Generic;
using WebShop.Data.Entities.Catalog;
using WebShop.Data.Repositories.Catalog;

namespace WebShop.Tests.Data.Repositories
{
    [TestFixture]
    public class CatalogTests
    {
        private IPagedEnumerable<BookEntity> _books;

        [SetUp]
        public void SetUp()
        {
            var bookRepository = new BookRepository();
            _books = bookRepository.Get(1, int.MaxValue);
        }

        [Test]
        public void AllBooksAreLoaded()
        {
            Assert.That(_books, Is.Not.Null);
            Assert.That(_books.Items, Is.Not.Empty);
            Assert.That(_books.Items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void BookDataIsLoaded()
        {
            var book = _books.Items.First();
            Assert.That(book.Id, Is.EqualTo(1));
            Assert.That(book.Title, Is.EqualTo("C# in Depth"));
            Assert.That(book.Price, Is.EqualTo(30.00));
            Assert.That(book.ThumbImage, Is.EqualTo("c-sharp-in-depth-thumb.jpg"));
            Assert.That(book.TitleImage, Is.EqualTo("c-sharp-in-depth.jpg"));
            Assert.That(book.Description, Is.EqualTo("C# in Depth description"));
        }

        [Test]
        public void MissedXmlElementResultsInNullValue()
        {
            var book = _books.Items.Skip(1).First();
            Assert.That(book.Id, Is.EqualTo(3));
            Assert.That(book.Description, Is.Null);
        }
    }
}