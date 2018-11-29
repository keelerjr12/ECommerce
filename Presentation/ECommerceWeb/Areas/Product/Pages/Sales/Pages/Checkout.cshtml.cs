using System.Linq;
using System.Security.Claims;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public CustomerModel Customer { get; set; }

        public CheckoutModel(CustomerService customerService, OrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        public void OnGet()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            var customer = _customerService.GetCustomer(customerId);
            Customer = new CustomerModel(customer);
        }

        public void OnPost()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _orderService.PlaceOrder(customerId);
        }

        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
    }
}