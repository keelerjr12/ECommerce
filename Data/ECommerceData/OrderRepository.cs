using ECommerceData.Order;
using ECommerceDomain.Sales.Order;

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
            var orderDTO = new OrderDTO()
            {
                CustomerId = order.CustomerId
            };

            _eCommerceContext.Orders.Add(orderDTO);
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
