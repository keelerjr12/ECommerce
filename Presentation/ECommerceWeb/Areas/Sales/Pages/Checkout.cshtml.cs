using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ECommerceApplication.CustomerService;
using ECommerceApplication.OrderService;
using ECommerceData.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        public CustomerViewModel CustomerView { get; set; }

        public CheckoutModel(IMediator mediator, OrderService orderService)
        {
            _mediator = mediator;

            _orderService = orderService;
        }

        public void OnGet()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            var customerQuery = _mediator.Send(new CustomerQueryRequest
            {
                CustomerId = customerId
            }).Result;

            CustomerView = Mapper.Map<CustomerQueryResult, CustomerViewModel>(customerQuery);
        }

        public IActionResult OnPost()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _orderService.PlaceOrder(customerId);

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
        private readonly OrderService _orderService;
    }
}