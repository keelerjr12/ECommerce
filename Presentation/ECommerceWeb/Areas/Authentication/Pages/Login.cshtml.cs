using System.Collections.Generic;
using System.Security.Claims;
using ECommerceApplication.AuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class LoginModel : PageModel
    {
        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password, string action, string submit)
        {
            if (!_authService.CanLogin(username, password))
            {
                return RedirectToPage();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            identity.AddClaim(new Claim(ClaimTypes.Name, username));
            identity.AddClaim(new Claim(ClaimTypes.Role, "customer"));
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true });

            //want to redirect to Product but does not work
            return RedirectToPage("/Account");

        }

        private readonly AuthService _authService;
    }
}