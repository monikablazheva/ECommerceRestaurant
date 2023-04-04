using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace UserManagementMVCExample.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("yoan040707@gmail.com", "zryftrdtpzcqmhfr") //rozamvkionjfwewm
            };

            return client.SendMailAsync("monitob875@gmail.com", email, subject, htmlMessage);
        }
    }
}
