using System.Collections.Generic;
using ECommerceApplication.Sales.Order;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class OrderDetailsModel : PageModel
    {
        public OrderViewModel OrderVM { get; private set; }
        public IList<OrderLineVM> OrderLines { get; } = new List<OrderLineVM>();

        public OrderDetailsModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet(string id)
        {
            var orderId = int.Parse(id);
            /*
            var order = _orderService.GetOrderById(orderId);

            OrderVM = new OrderViewModel
            {
                Id = order.Id,
                DateTime = order.Created,
                CustomerId = order.CustomerId,
                StreetAddress = order.ShippingAddress.Street,
                City = order.ShippingAddress.City,
                State = order.ShippingAddress.State,
                Country = order.ShippingAddress.Country,
                Zipcode = order.ShippingAddress.Zipcode
            };

            foreach (var orderLine in order.OrderLines)
            {
                OrderLines.Add(new OrderLineVM
                {
                    SKU = orderLine.SKU,
                    Quantity = orderLine.Quantity,
                    Price = orderLine.Price
                });

            }*/
        }

        private readonly OrderService _orderService;
    }
}