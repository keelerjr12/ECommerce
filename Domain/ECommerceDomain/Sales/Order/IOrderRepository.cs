using System.Collections.Generic;

namespace ECommerceDomain.Sales.Order
{
    public interface IOrderRepository
    {
        void Save(Order order);
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
    }
}
