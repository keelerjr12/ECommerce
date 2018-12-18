using System.Net.Mail;
using System.Threading.Tasks;
using ECommerceApplication;
using ECommerceApplication.Ordering.Customer.Queries;
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


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string subject, string emailBody)
        {
            if (subject == "sendMailingList")
            {
                var result = await _mediator.Send(new GetAllCustomerEmailsQuery.Request());
                var subscribedEmails = result.SubscribedEmails;

                _emailAddressList.Add(new MailAddress("varunpat@umich.edu"));
                _emailAddressList.Add(new MailAddress("varunpatel0917@gmail.com"));

                _emailService.SendEmailList(_emailAddressList, "Weekly Ads", emailBody);
            }
      
            return RedirectToPage("/Seller/Index");

        }

        private readonly EmailService _emailService;
        private MailAddressCollection _emailAddressList;
        private readonly IMediator _mediator;
    }
}