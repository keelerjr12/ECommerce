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
                    DateTime = order.DateTime,
                    CustomerId = order.Customer.Id,
                    StreetAddress = order.Customer.StreetAddress,
                    City = order.Customer.City,
                    State = order.Customer.State,
                    Country = order.Customer.Country,
                    Zipcode = order.Customer.ZipCode
                };

                Orders.Add(orderVM);
            }
        }

        private readonly OrderService _orderService;
    }
}