using System.Data;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data.Repositories.Shopping
{
    public interface IOrderRepository
    {
        void Create(OrderEntity orderEntity);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Create(OrderEntity orderEntity)
        {
            using( var context = new ShoppingContext() )
            {
                context.Entry(orderEntity).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}