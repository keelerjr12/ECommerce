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

            var types = new List<SelectType>();
            types.Add(new SelectType() { Value = "userType", Text = "Select user type" });
            types.Add(new SelectType() { Value = "customer", Text = "Customer" });
            types.Add(new SelectType() { Value = "seller", Text = "Seller" });
            userTypeList = types;


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
            identity.AddClaim(new Claim(ClaimTypes.Role, "Customer"));
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = true });

            //want to redirect to Product but does not work
            return RedirectToPage("/Account");

        }

        private readonly AuthService _authService;


        //temp stuff..move this to register after
        public readonly List<SelectType> userTypeList;
        public string userType{ get; set; }
    }
}