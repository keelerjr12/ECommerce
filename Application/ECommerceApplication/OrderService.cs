using System.Collections.Generic;
using ECommerceData;
using ECommerceDomain.Common;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Order;

namespace ECommerceApplication
{
    public class OrderService
    {
        public OrderService(UnitOfWork uow, ICartRepository cartRepo, IOrderRepository orderRepo, InventoryService.InventoryService inventoryService)
        {
            _uow = uow;
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

        public void PlaceOrder(int customerId, string street, string city, string state, string country, int zipcode)
        {
            var cart = _cartRepo.FindById(customerId);
            var items = cart.Checkout();

            var billing = new Address(street, city, state, country, zipcode);
            var shipping = new Address(street, city, state, country, zipcode);

            var order = Order.Create(customerId, shipping, billing, items);

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
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly InventoryService.InventoryService _inventoryService;
    }
}
