using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password)
        {
            //check the user name and password in database
            if (username != "demo" || password != "demo") return RedirectToPage();

            //if it exsists in database, then create a user model

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "1"));
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true });

            return RedirectToPage("/Account");
        }
    }
}