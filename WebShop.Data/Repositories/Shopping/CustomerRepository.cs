using WebShop.Data.Contexts;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data.Repositories.Shopping
{
    public interface ICustomerRepository
    {
        void Create(CustomerEntity customerEntity);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public void Create(CustomerEntity customerEntity)
        {
            using( var context = new ShoppingContext() )
            {
                context.Customers.Add(customerEntity);
                context.SaveChanges();
            }
        }
    }
}