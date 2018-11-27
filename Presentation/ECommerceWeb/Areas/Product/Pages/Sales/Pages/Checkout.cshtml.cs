using ECommerceApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public int CustomerId { get; set; }

        public CheckoutModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            CustomerId = 1;
            _orderService.PlaceOrder(CustomerId);
        }

        private readonly OrderService _orderService;
    }
}