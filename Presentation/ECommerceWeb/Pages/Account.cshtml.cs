using ECommerceApplication.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class LogoutModel : PageModel
    {
        public LogoutModel(IdentityService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string action)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }

        private readonly IdentityService _authService;
    }
}