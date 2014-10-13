using System.Collections.Generic;
using System.Linq;

namespace WebShop.Data
{
    public interface IBookRepository
    {
        IEnumerable<BookEntity> GetAll();
    }

    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookEntity> GetAll()
        {
            var books = new[]
            {
                new BookEntity()
                {
                    Id = 1,
                    Title = "Dependency Injection in .NET",
                    Price = 19.0f,
                    ThumbImage = "dependency-injection-in-dotnet.jpg",
                    TitleImage = "dependency-injection-in-dotnet.jpg",
                },

                new BookEntity()
                {
                    Id = 2,
                    Title = "C# in Depth, 3rd Edition",
                    Price = 30.0f,
                    ThumbImage = "c-sharp-in-depth.jpg",
                    TitleImage = "c-sharp-in-depth.jpg",
                },

                new BookEntity()
                {
                    Id = 3,
                    Title = "Professional Test Driven Development",
                    Price = 24.0f,
                    ThumbImage = "test-driven-development-with-c-sharp.jpg",
                    TitleImage = "test-driven-development-with-c-sharp.jpg",
                },
            };

            var resultBooks = (IEnumerable<BookEntity>)books;
            for( var i = 0; i < 10; i++ )
                resultBooks = resultBooks.Concat( resultBooks );

            return resultBooks;
        }
    }
}