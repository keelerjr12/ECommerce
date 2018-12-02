using System.Collections.Generic;
using ECommerceApplication;
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

            var order = _orderService.GetOrderById(orderId);

            OrderVM = new OrderViewModel
            {
                Id = order.Id,
                DateTime = order.DateTime,
                CustomerId = order.Customer.Id,
                StreetAddress = order.Customer.StreetAddress,
                City = order.Customer.City,
                State = order.Customer.State,
                Country = order.Customer.Country,
                Zipcode = order.Customer.ZipCode
            };

            foreach (var orderLine in order.OrderLines)
            {
                OrderLines.Add(new OrderLineVM
                {
                    SKU = orderLine.SKU,
                    Quantity = orderLine.Quantity,
                    Price = orderLine.Price
                });

            }
        }

        private readonly OrderService _orderService;
    }
}