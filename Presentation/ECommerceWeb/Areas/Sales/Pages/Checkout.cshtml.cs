using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ECommerceApplication;
using ECommerceApplication.EmailService;
using ECommerceApplication.Ordering.Customer.Queries;
using ECommerceApplication.Ordering.Order.Commands;
using ECommerceWeb.Areas.Sales.Models;
using ECommerceWeb.Pages;
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
            _emailService = new EmailService();
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

            try
            {
                //TODO: get customer email here
                //var customer = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                var customerEmail = "varunpat@umich.edu";
                var emailBody = "Your order is placed. Wait for shipping confirmation.";
                _emailService.SendEmail(customerEmail, "Order is placed.", emailBody);
            }
            catch (MailServiceFailedException ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
        private EmailService _emailService;
    }
}