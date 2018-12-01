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
            //var selectedItem = fruit.Fruits.Find(p => p.Value == fruit.FruitId.ToString());

            if (action == "loginButton")
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
            else if (action == "registerButton")
            {

                //just play code, this should be done in register model
                _authService.Register(username, password, "varun", "patel", "email");

                //want to redirect to Register but does not work
                return RedirectToPage("/Account");
            }
            else
            {
                return RedirectToPage();
            }
        }

        private readonly AuthService _authService;


        //temp stuff..move this to register after
        public readonly List<SelectType> userTypeList;
        public string userType{ get; set; }
    }
}