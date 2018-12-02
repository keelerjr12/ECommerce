using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApplication;
using ECommerceApplication.AuthService;
using ECommerceData.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class RegisterModel : PageModel
    {
       
        public RegisterModel(AuthService authService)
        {
            _authService = authService;
            _emailService = new EmailService();
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password, string firstName, string lastName, string email)
        {
            try
            {
                string userType = null;
                _authService.Register(username, password, firstName, lastName, email, userType);
            }
            catch (UserInfoInvalidException e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                string emailBody = "Dear " + firstName + " " + lastName + ",\n" + "Hope you find everything you are looking for. \n\n" + "P.S. Nice Password ;)";
                _emailService.SendEmail("varunpat@umich.edu", "Welcome to The Five Jewelers", emailBody);
            }
            catch (MailServiceFailedException ex)
            {
                Console.WriteLine(ex);
                throw;
            }


            return RedirectToPage("/Account");
        }

        private AuthService _authService;
        private EmailService _emailService;
        public string userType;
    }
}