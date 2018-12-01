using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApplication.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class RegisterModel : PageModel
    {
       
        public RegisterModel(AuthService authService)
        {
            _authService = authService;
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password, string firstName, string lastName, string email)
        {
            _authService.Register(username, password, firstName, lastName, email);
            
            return RedirectToPage("/Account");
        }

        private AuthService _authService;
        public string userType;
    }
}