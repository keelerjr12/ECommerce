using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ECommerceApplication.Ordering.Customer.Queries;
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
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            var customerQuery = _mediator.Send(new CustomerQuery.Request
            {
                CustomerId = customerId
            }).Result;

            CustomerView = Mapper.Map<CustomerQuery.Result, CustomerViewModel>(customerQuery);
        }

        public IActionResult OnPost()
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            _mediator.Send(new CreateOrderCommand.Request
            {
                CustomerId = customerId
            });

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
    }
}