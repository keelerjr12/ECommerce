using ECommerceApplication.AuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class LogoutModel : PageModel
    {
        public LogoutModel(AuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string action)
        {
            if (action == "logoutButton")
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                //want to redirect to Product but does not work
                return RedirectToPage("/Account");
            }
            else
            {
                return RedirectToPage();
            }
        }

        private readonly AuthService _authService;
    }
}