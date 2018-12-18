using System.Net.Mail;
using System.Threading.Tasks;
using ECommerceApplication.EmailService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.EmailCustomerBase
{
    public class EmailCustomerBase : PageModel
    {
        public EmailCustomerBase(IMediator mediator)
        {
            _mediator = mediator;
            _emailService = new EmailService();
            _emailAddressList = new MailAddressCollection();
        }

        public async Task<IActionResult> OnPost(string subject, string subjectField, string emailBody)
        {
            if (subject == "sendMailingList")
            {
                var result = await _mediator.Send(new GetAllCustomerEmailsQuery.Request());
                var subscribedEmails = result.SubscribedEmails;
                foreach (var email in subscribedEmails)
                {
                    _emailAddressList.Add(new MailAddress(email));

                }

                _emailService.SendEmailList(_emailAddressList, subjectField, emailBody);
            }
      
            return RedirectToPage("/Seller/Index");

        }

        private readonly EmailService _emailService;
        private MailAddressCollection _emailAddressList;
        private readonly IMediator _mediator;
    }
}