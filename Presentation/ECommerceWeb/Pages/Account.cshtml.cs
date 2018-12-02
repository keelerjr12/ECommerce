using ECommerceApplication.AuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.IO;

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

                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("fivejewelers@gmail.com");
                    message.To.Add(new MailAddress("hardedu1@gmail.com")); // replace with account email address
                    message.Subject = "Test";
                    // message.IsBodyHtml = true; //to make message body as html  
                    message.Body = "hi, how are you";
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("fivejewelers@gmail.com", "FiveJewelers123");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (MailServiceFailedException ex) { }

                //Send an email here 
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