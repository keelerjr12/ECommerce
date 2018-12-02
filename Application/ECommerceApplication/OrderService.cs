using System.Collections.Generic;
using ECommerceData;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;

namespace ECommerceApplication
{
    public class OrderService
    {
        public OrderService(UnitOfWork uow, ICustomerRepository customerRepo, ICartRepository cartRepo, IOrderRepository orderRepo)
        {
            _uow = uow;
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
        }

        public int GetQuantityOrdered(string productSKU)
        {
            var orders = _orderRepo.GetOrders();

            return 0;
        }

        public void PlaceOrder(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            var cart = _cartRepo.FindById(customerId);
            var items = cart.Checkout();

            var order = new Order(customer, items);

            _orderRepo.Create(order);
            _cartRepo.Update(cart);

            _uow.Save();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepo.GetOrderById(orderId);
        }

        private readonly UnitOfWork _uow;
        private readonly ICustomerRepository _customerRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;

    }
}
