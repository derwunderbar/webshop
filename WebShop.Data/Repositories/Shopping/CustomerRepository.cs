using System;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data.Repositories.Shopping
{
    public interface ICustomerRepository
    {
        int Create(CustomerEntity customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public int Create(CustomerEntity customer)
        {
            // todo: implement
            return -1;
        }
    }
}