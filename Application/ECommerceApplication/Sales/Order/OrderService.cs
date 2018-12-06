﻿using System.Collections.Generic;
using ECommerceData;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;

namespace ECommerceApplication.Sales.Order
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

        public void PlaceOrder(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            var cart = _cartRepo.FindById(customerId);
            var cartItems = cart.Checkout();

            var items = new List<LineItem>();
            foreach (var item in cartItems)
            {
                items.Add(new LineItem(item.ProductId, item.Quantity.Value));
            }

            var order = customer.PlaceOrder(items);

            _orderRepo.Save(order);
            _cartRepo.Update(cart);

            foreach (var orderLine in order.OrderLines)
            {
                _inventoryService.SellStock(orderLine.SKU, orderLine.Quantity);
            }

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly ICustomerRepository _customerRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly InventoryService.InventoryService _inventoryService;
    }
}