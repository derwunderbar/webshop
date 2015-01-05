using WebShop.Data;
using WebShop.Services.Catalog;

namespace WebShop.Services
{
    public interface IServiceFactory
    {
        IBookService GetBookService();
        IAuthorService GetAuthorService();
        IOrderService GetOrderService();
        IUserService GetUserService();
    }

    public class ServiceFactory : IServiceFactory
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public ServiceFactory(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IBookService GetBookService()
        {
            return new BookService(_repositoryFactory.GetBookRepository());
        }

        public IAuthorService GetAuthorService()
        {
            return new AuthorService(_repositoryFactory.GetAuthorRepository());
        }

        public IOrderService GetOrderService()
        {
            return new OrderService(_repositoryFactory.GetOrderRepository(), _repositoryFactory.GetCustomerRepository());
        }

        public IUserService GetUserService()
        {
            return new UserService(_repositoryFactory.GetUserRepository());
        }
    }
}