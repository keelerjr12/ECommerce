using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Common;
using ECommerceDomain.Ordering.Order;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Sales.Order
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void Save(ECommerceDomain.Ordering.Order.Order order)
        {
            var orderLineDTOs = new List<OrderLineDTO>();
            foreach (var orderLine in order.OrderLines)
            {
                orderLineDTOs.Add(new OrderLineDTO
                {
                    SKU = orderLine.SKU,
                    Quantity = orderLine.Quantity,
                    Price = orderLine.Price
                });
            }

            var orderDTO = new OrderDTO
            {
                Created = order.Created,
                CustomerId = order.CustomerId,
                Street = order.ShippingAddress.Street,
                City = order.ShippingAddress.City,
                State = order.ShippingAddress.State,
                Country = order.ShippingAddress.Country,
                Zipcode = order.ShippingAddress.Zipcode,
                OrderLines = orderLineDTOs
            };

            _eCommerceContext.Orders.Add(orderDTO);
        }

        IEnumerable<ECommerceDomain.Ordering.Order.Order> IOrderRepository.GetOrders()
        {
            var ordersDTO = _eCommerceContext.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines);
            var orders = new List<ECommerceDomain.Ordering.Order.Order>();

            foreach (var orderDTO in ordersDTO)
            {
                var order = RehydrateOrder(orderDTO);
                orders.Add(order);
            }

            return orders;
        }

        public ECommerceDomain.Ordering.Order.Order GetOrderById(int orderId)
        {
            var orderDTO = _eCommerceContext.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines).First(o => o.Id == orderId);

            var order = RehydrateOrder(orderDTO);

            return order;
        }

        private ECommerceDomain.Ordering.Order.Order RehydrateOrder(OrderDTO orderDTO)
        {
            var customerDTO = orderDTO.CustomerDTO;

            var orderLines = new List<OrderLine>();

            foreach (var orderLineDto in orderDTO.OrderLines)
            {
                var orderLine = new OrderLine(orderLineDto.SKU, orderLineDto.Quantity, orderLineDto.Price);
                orderLines.Add(orderLine);
            }

            var shippingAddress = new Address(orderDTO.Street, orderDTO.City, orderDTO.State, orderDTO.Country,
                orderDTO.Zipcode);
            var billingAddress = new Address(orderDTO.Street, orderDTO.City, orderDTO.State, orderDTO.Country,
                orderDTO.Zipcode);

            var order = new ECommerceDomain.Ordering.Order.Order(orderDTO.Id, orderDTO.CustomerId, orderDTO.Created, shippingAddress, billingAddress, orderLines.AsReadOnly());

            return order;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
