using ECommerceWeb.Pages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECommerceApplication
{
    public class EmailService
    {
        public EmailService()
        {
            _message = new MailMessage(); 
            _message.IsBodyHtml = false;
            _message.From = new MailAddress(_companyEmail);

            _smtp = new SmtpClient();
            _smtp.Port = 587;
            _smtp.Host = "smtp.gmail.com";
            _smtp.EnableSsl = true;
            _smtp.UseDefaultCredentials = false;
            _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtp.Credentials = new NetworkCredential(_companyEmail, _companyEmailPassword);
        }

        public void SendEmail(string emailAddress, string messageSubject, string messageBody)
        {
            _message.To.Clear();
            _message.To.Add(new MailAddress(emailAddress));

            _message.Subject = messageSubject;
            _message.Body = messageBody;

            try
            {
                _smtp.Send(_message);
            }
            catch
            {
                throw new MailServiceFailedException("Email did not send");
            }
        }

        private MailMessage _message;
        private SmtpClient _smtp;
        private string _companyEmail = "fivejewelers@gmail.com";
        private string _companyEmailPassword = "FiveJewelers123";

    }
}
