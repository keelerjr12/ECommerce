using System.Linq;
using System.Security.Claims;
using ECommerceApplication;
using ECommerceDomain.Sales.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public CustomerViewModel CustomerView { get; private set; }

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
            BindModelToView(customer);
        }

        public IActionResult OnPost()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _orderService.PlaceOrder(customerId, CustomerView.Street, CustomerView.City, CustomerView.State, CustomerView.Country, CustomerView.ZipCode);

            return RedirectToPage("/Index");
        }

        private void BindModelToView(Customer customer)
        {
            CustomerView = new CustomerViewModel {
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Street = customer.StreetAddress,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                ZipCode = customer.ZipCode
            };
        }

        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
    }
}