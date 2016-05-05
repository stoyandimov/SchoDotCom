using Microsoft.AspNet.Identity;
using SendGrid;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Create the email object first, then add the properties.
            var sendGridMessage = new SendGridMessage()
            {
                From = new MailAddress("john@example.com", "John Smith"),
                Subject = message.Subject,
                Text = message.Body
            };
            sendGridMessage.AddTo(message.Destination);

            return SendAsync(sendGridMessage);
        }

        public Task SendAsync(SendGridMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["sendgrid:ApiKey"] as string;

            // Create an Web transport for sending email.
            var transportWeb = new Web(apiKey);

            return transportWeb.DeliverAsync(message);
        }
    }
}