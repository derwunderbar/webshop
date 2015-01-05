using System.Linq;
using AutoMapper;
using WebShop.Data.Entities.Shopping;
using WebShop.Data.Repositories.Shopping;
using WebShop.Services.Models.Shopping;

namespace WebShop.Services
{
    public interface IOrderService
    {
        void Create(OrderModel order, CustomerModel customer);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService( IOrderRepository orderRepository, ICustomerRepository customerRepository )
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public void Create(OrderModel order, CustomerModel customer)
        {
            var customerEntity = Mapper.Map<CustomerEntity>(customer);
            customerEntity.UserId = order.UserId;
            var customerId = _customerRepository.Create(customerEntity);

            var orderEntity = Mapper.Map<OrderEntity>(order);
            orderEntity.CustomerId = customerId;
            var orderLineEntities = order.Lines.Select(a => Mapper.Map<OrderLineEntity>(a)).ToArray();
            _orderRepository.Create(orderEntity, orderLineEntities);
        }
    }
}