using System;
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
            // todo: create order record
            // todo: create order line records using order id
        }
    }
}