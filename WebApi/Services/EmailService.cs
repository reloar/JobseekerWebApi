using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmailService
    {
        private readonly SendGridMessage msg;
        private readonly SendGridClient client;

        public EmailService(string apiKey,
            string senderEmail = "admin@cyberspace.com",
            string senderName = "CyberAcademy")
        {
            msg = new SendGridMessage();
            msg.From = new EmailAddress(senderEmail, senderName);
            client = new SendGridClient(apiKey);
        }

        public async Task<string> SendMail(EmailMessage message, Boolean isHtml)
        {
            msg.AddTo(message.Recipient);
            msg.Subject = message.Subject;
            if (isHtml)
            {
                msg.HtmlContent = message.Body;
            }
            else
            {
                msg.PlainTextContent = message.Body;
            }


            SendGrid.Response response = await client.SendEmailAsync(msg);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return "Message sent successfully";
            else
                return string.Empty;
        }
    }
}