using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public class SendGridEmailService : IIdentityMessageService, IMailService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(message.Destination),
                Subject = message.Subject,
                Body = message.Body
            };
            mailMessage.To.Add(message.Destination);

            return SendAsync(mailMessage);
        }

        public Task SendAsync(MailMessage message)
        {
            var sendGridMessage = new SendGrid.SendGridMessage()
            {
                From = new MailAddress(message.From.Address, message.From.DisplayName),
                Subject = message.Subject,
                Text = message.Body
            };
            sendGridMessage.AddTo(message.To.Select(m => m.Address));

            return SendAsync(sendGridMessage);
        }

        protected Task SendAsync(SendGrid.SendGridMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["sendgrid:ApiKey"] as string;

            // Create an Web transport for sending email.
            var transportWeb = new SendGrid.Web(apiKey);

            return transportWeb.DeliverAsync(message);
        }
    }
}