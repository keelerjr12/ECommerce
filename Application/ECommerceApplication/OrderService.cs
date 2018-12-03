using System.Collections.Generic;
using ECommerceApplication.InventoryService;
using ECommerceData;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;

namespace ECommerceApplication
{
    public class OrderService
    {
        public OrderService(UnitOfWork uow, ICustomerRepository customerRepo, ICartRepository cartRepo, IOrderRepository orderRepo, InventoryService.InventoryService inventoryService)
        {
            _uow = uow;
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _inventoryService = inventoryService;
        }

        public int GetQuantityOrdered(string productSKU)
        {
            var quantity = 0;
            var orders = _orderRepo.GetOrders();

            foreach (var order in orders)
            {
                foreach (var orderLine in order.OrderLines)
                {
                    if (orderLine.SKU == productSKU)
                    {
                        quantity++;
                    }
                }
            }

            return quantity;
        }

        public void PlaceOrder(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            var cart = _cartRepo.FindById(customerId);
            var items = cart.Checkout();

            var order = new Order(customer, items);

            _orderRepo.Create(order);
            _cartRepo.Update(cart);

            foreach (var orderLine in order.OrderLines)
            {
                _inventoryService.SellStock(orderLine.SKU, orderLine.Quantity);
            }

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
        private readonly InventoryService.InventoryService _inventoryService;
    }
}
