using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ECommerceApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CheckoutModel : PageModel
    {
        public CustomerModel Customer { get; set; }

        public CheckoutModel(IMediator mediator, CustomerService customerService, OrderService orderService)
        {
            _mediator = mediator;

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

        public IActionResult OnPost()
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _mediator.Send(new OrderCreateCommand
            {
                CustomerId = customerId,
                Items = new List<CartItemModel>()
            });


            //_orderService.PlaceOrder(customerId);

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
    }
}