using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DigitizedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DigitizedApi.Controllers {
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ContactController : ControllerBase {

        public ContactController(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Sends a mail to me
        /// </summary>
        /// <param name="contactMessage"></param>
        /// <returns>true or false, depending on the success of the sent mail</returns>
        [HttpPost]
        public bool Send(ContactMessage contactMessage) {
            return SendMail(contactMessage).Result;
        }

        private async Task<bool> SendMail(ContactMessage contactMessage) {
            MailAddress from = new MailAddress(Configuration["Mail:From"]);
            MailAddress to = new MailAddress(Configuration["Mail:To"]);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = contactMessage.Topic;
            mail.IsBodyHtml = true;
            mail.Body = 
                "<h3> From: "+ contactMessage.Author +"</h3>" +
                "<h4>Date: " + contactMessage.Date + "</h4>" +
                "<p>Message: " + contactMessage.Content + "<p>";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(Configuration["Mail:From"], Configuration["Mail:Password"]);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.SendCompleted += (s, e) => {
                client.Dispose();
                mail.Dispose();
            };

            try {
                await client.SendMailAsync(mail);
            } catch (Exception e) {
                ModelState.AddModelError("", e.Message);
                ModelState.AddModelError("", "Something went wrong when sending the mail, please do try again!");
                return false;
            }
            return true;
        }
    }
}