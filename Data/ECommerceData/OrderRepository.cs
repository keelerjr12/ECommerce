using System.Collections.Generic;
using System.Linq;
using ECommerceData.Order;
using ECommerceDomain.Sales.Order;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void Create(ECommerceDomain.Sales.Order.Order order)
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

            var orderDTO = new OrderInfoDTO
            {
                DateTime = order.DateTime,
                CustomerId = order.Customer.Id,
                Street = order.Customer.StreetAddress,
                City = order.Customer.City,
                State = order.Customer.State,
                Country = order.Customer.Country,
                Zipcode = order.Customer.ZipCode,
                OrderLines = orderLineDTOs
            };

            _eCommerceContext.Orders.Add(orderDTO);
        }

        IEnumerable<ECommerceDomain.Sales.Order.Order> IOrderRepository.GetOrders()
        {
            var ordersDTO = _eCommerceContext.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines);
            var orders = new List<ECommerceDomain.Sales.Order.Order>();

            foreach (var orderDTO in ordersDTO)
            {
                var order = RehydrateOrder(orderDTO);
                orders.Add(order);
            }

            return orders;
        }

        public ECommerceDomain.Sales.Order.Order GetOrderById(int orderId)
        {
            var orderDTO = _eCommerceContext.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines).First(o => o.Id == orderId);

            var order = RehydrateOrder(orderDTO);

            return order;
        }

        private ECommerceDomain.Sales.Order.Order RehydrateOrder(OrderInfoDTO orderDTO)
        {
            var customerDTO = orderDTO.CustomerDTO;

            var customer = new ECommerceDomain.Sales.Customer.Customer(customerDTO.Id, customerDTO.FirstName,
                customerDTO.MiddleName, customerDTO.LastName, orderDTO.Street, orderDTO.City,
                orderDTO.State, orderDTO.Country, orderDTO.Zipcode);

            var orderLines = new List<OrderLine>();

            foreach (var orderLineDto in orderDTO.OrderLines)
            {
                var orderLine = new OrderLine(orderLineDto.SKU, orderLineDto.Quantity, orderLineDto.Price);
                orderLines.Add(orderLine);
            }

            var order = new ECommerceDomain.Sales.Order.Order(orderDTO.Id, orderDTO.DateTime, customer, orderLines.AsReadOnly());
            return order;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
