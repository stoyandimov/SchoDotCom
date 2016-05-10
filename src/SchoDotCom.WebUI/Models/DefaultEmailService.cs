using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public class DefaultEmailService : IIdentityMessageService, IMailService
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
            var client = new SmtpClient();
            return Task.Run(() => client.SendAsync(message, null));
        }
    }
}