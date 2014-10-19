using System.Collections.Generic;
using WebShop.Data.Entities;

namespace WebShop.Data
{
    internal static class EntityStubs
    {
        internal static IEnumerable<BookEntity> GetBooks()
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

            return books;
        }

        internal static AuthorEntity GetAuthor()
        {
            return new AuthorEntity() { Id = 1, FirstName = "FirstName", LastName = "LastName" };
        }

        internal static PublisherEntity GetPublisher()
        {
            return new PublisherEntity() { Id = 1, Name = "Publisher #1" };
        }
    }
}