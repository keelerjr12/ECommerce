using System.Collections.Generic;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class OrdersModel : PageModel
    {
        public List<OrderViewModel> Orders { get; } = new List<OrderViewModel>();

        public OrdersModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
            var orders = _orderService.GetAllOrders();

            foreach (var order in orders)
            {
                var orderVM = new OrderViewModel
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

                Orders.Add(orderVM);
            }
        }

        private readonly OrderService _orderService;
    }
}