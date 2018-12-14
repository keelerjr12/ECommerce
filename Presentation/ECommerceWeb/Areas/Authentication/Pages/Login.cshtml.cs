using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceApplication.Identity.Queries;
using ECommerceWeb.Areas.Authentication.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Authentication.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials Credentials { get; set; }

        public string Message { get; set; }

        public LoginModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var credentials = await _mediator.Send(new AuthenticationQuery.Request
            {
                Username = Credentials.Username,
                Password = Credentials.Password
            });

            if (credentials == null)
            {
                Message = "Invalid username and/or password";
                return Page();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, credentials.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, credentials.Username));
            identity.AddClaim(new Claim(ClaimTypes.Email, credentials.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, credentials.UserType));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true });

            return RedirectToPage("/Index");

        }

        private readonly IMediator _mediator;
    }
}