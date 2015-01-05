using System.Linq;
using WebShop.Data.Entities.Shopping;

namespace WebShop.Data.Repositories.Shopping
{
    public interface IOrderRepository
    {
        void Create(OrderEntity order, OrderLineEntity[] lines);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Create(OrderEntity order, OrderLineEntity[] lines)
        {
            using( var context = new ShoppingContext() )
            {
                context.Orders.Add(order);
                context.SaveChanges();

                foreach( var orderLine in lines )
                {
                    orderLine.OrderId = order.Id;
                    context.OrderLines.Add(orderLine);
                }

                if( lines.Any() )
                    context.SaveChanges();
            }
        }
    }
}