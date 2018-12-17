using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.EmailCustomerBase
{
    public class EmailCustomerBase : PageModel
    {
        public EmailCustomerBase()
        {
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
                //TODO get all emails from database
                _emailAddressList.Add(new MailAddress("varunpat@umich.edu"));
                _emailAddressList.Add(new MailAddress("varunpatel0917@gmail.com"));

                _emailService.SendEmailList(_emailAddressList, "Weekly Ads", emailBody);
            }
      
            return RedirectToPage("/Account/Seller");

        }

        private readonly EmailService _emailService;
        private MailAddressCollection _emailAddressList;
    }
}