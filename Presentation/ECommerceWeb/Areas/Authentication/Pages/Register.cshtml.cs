using System;
using ECommerceApplication;
using ECommerceApplication.Identity.Commands;
using ECommerceData.Identity.User;
using ECommerceWeb.Pages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Authentication.Pages
{
    public class RegisterModel : PageModel
    {
       
        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
            _emailService = new EmailService();
        }

        public IActionResult OnPost(string username, string password, string firstName, string lastName, string email)
        {
            try
            {
                _mediator.Send(new RegisterUserCommand.Request(username, password, email, "Customer"));
            }
            catch (UserInfoInvalidException e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                var emailBody = "Dear " + firstName + " " + lastName + ",\n" + "Hope you find everything you are looking for. \n\n" + "P.S. Nice Password ;)";
                _emailService.SendEmail(email, "Welcome to The Five Jewelers", emailBody);
            }
            catch (MailServiceFailedException ex)
            {
                Console.WriteLine(ex);
                throw;
            }


            return RedirectToPage("/Login");
        }

        private readonly IMediator _mediator;
        private readonly EmailService _emailService;
    }
}