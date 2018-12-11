using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ECommerceApplication.Ordering.Customer;
using ECommerceApplication.Ordering.Order.Commands;
using ECommerceWeb.Areas.Sales.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        public CustomerViewModel CustomerView { get; set; }

        public CheckoutModel(IMediator mediator)
        {
            _mediator = mediator;
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

            _mediator.Send(new CreateOrderCommand.Request
            {
                CustomerId = customerId
            });

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
    }
}