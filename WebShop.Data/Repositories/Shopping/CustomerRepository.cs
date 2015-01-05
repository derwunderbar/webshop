using WebShop.Data.Entities.Shopping;

namespace WebShop.Data.Repositories.Shopping
{
    public interface ICustomerRepository
    {
        CustomerEntity Create(CustomerEntity customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public CustomerEntity Create(CustomerEntity customer)
        {
            using( var context = new ShoppingContext() )
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return customer;
            }
        }
    }
}