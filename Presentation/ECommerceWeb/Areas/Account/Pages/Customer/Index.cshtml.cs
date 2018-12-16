using System.Threading.Tasks;
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
                //TODO set the flag in database
                SubscriptionMessage = "You are subscribed.";
            }
            else if (subject == "unsubscribe")
            {
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