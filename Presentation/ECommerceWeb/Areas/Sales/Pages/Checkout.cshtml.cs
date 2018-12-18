using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.EmailService;
using ECommerceApplication.Ordering.Customer.Queries;
using ECommerceApplication.Ordering.Order.Commands;
using ECommerceApplication.Shipping.Queries;
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

        [BindProperty]
        public decimal ShippingCost { get; set; }

        public CheckoutModel(IMediator mediator)
        {
            _mediator = mediator;
            _emailService = new EmailService();
        }

        public async Task OnGetAsync()
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            var customerQuery = _mediator.Send(new CustomerQuery.Request
            {
                CustomerId = customerId
            }).Result;

            var result = await _mediator.Send(new GetShippingCostByStateQuery.Request(customerQuery.State));

            CustomerView = Mapper.Map<CustomerQuery.Result, CustomerViewModel>(customerQuery);
            ShippingCost = result.cost;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);

            await _mediator.Send(new CreateOrderCommand.Request
            {
                CustomerId = customerId,
                ShippingCost = ShippingCost
            });

            try
            {
                var email = User.Claims.First(a => a.Type == ClaimTypes.Email).Value;
                var emailBody = "Your order is placed. Wait for shipping confirmation.";
                _emailService.SendEmail(email, "Order is placed.", emailBody);
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