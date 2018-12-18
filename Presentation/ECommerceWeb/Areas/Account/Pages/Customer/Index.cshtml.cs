using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApplication.EmailService;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Customer
{
    public class CustomerAccountModel : PageModel
    {
        public CustomerAccountModel(IMediator mediator)
        {
            _mediator = mediator;

        }


        public async Task<IActionResult> OnPostAsync(string subject)
        {
            if (subject == "subscribe")
            {
                var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                await _mediator.Send(new UpdateSubscriptionServiceCommand.Request(customerId, true));
                SubscriptionMessage = "You are subscribed.";
            }
            else if (subject == "unsubscribe")
            {
                var customerId = Guid.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                await _mediator.Send(new UpdateSubscriptionServiceCommand.Request(customerId, false));
                SubscriptionMessage = "You are unsubscribed.";
            }
            else if (subject == "logout")
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return Redirect("/");
            }
            //TODO redirect correctly to proper pages
            return Page();
            
        }


        public string SubscriptionMessage { get; set; }

        private readonly IMediator _mediator;

    }

}