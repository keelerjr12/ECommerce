using System;
using ECommerceApplication;
using ECommerceApplication.Identity;
using ECommerceData.Identity.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
{
    public class RegisterModel : PageModel
    {
       
        public RegisterModel(IdentityService authService)
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
                _emailService.SendEmail(email, "Welcome to The Five Jewelers", emailBody);
            }
            catch (MailServiceFailedException ex)
            {
                Console.WriteLine(ex);
                throw;
            }


            return RedirectToPage("/Login");
        }

        private IdentityService _authService;
        private EmailService _emailService;
        public string userType;
    }
}