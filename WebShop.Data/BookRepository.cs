using System.Collections.Generic;

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
            return new[]
            {
                new BookEntity()
                {
                    Id = 1,
                    Title = "Dependency Injection in .NET ",
                    Price = 19.0f,
                },

                new BookEntity()
                {
                    Id = 2,
                    Title = "C# in Depth, 3rd Edition",
                    Price = 30.0f,
                },

                new BookEntity()
                {
                    Id = 3,
                    Title = "Professional Test Driven Development",
                    Price = 24.0f,
                },
            };
        }
    }
}