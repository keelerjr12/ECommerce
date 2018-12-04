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
                DateTime = order.Created,
                CustomerId = order.CustomerId,
                StreetAddress = order.BillingAddress.Street,
                City = order.BillingAddress.City,
                State = order.BillingAddress.State,
                Country = order.BillingAddress.Country,
                Zipcode = order.BillingAddress.Zipcode
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