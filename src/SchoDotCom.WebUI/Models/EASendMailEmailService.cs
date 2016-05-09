using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public class EASendMailEmailService : IIdentityMessageService, IMailService
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

        public Task SendAsync(System.Net.Mail.MailMessage message)
        {
            var mail = new EASendMail.SmtpMail("TryIt");
            var smtp = new EASendMail.SmtpClient();
            var server = new EASendMail.SmtpServer("");

            mail.From = new EASendMail.MailAddress(message.From.Address, message.From.DisplayName);
            mail.To = message.To.First().Address;
            mail.Subject = message.Subject;
            if (message.IsBodyHtml)
            {
                mail.HtmlBody = message.Body;
            }
            else
            {
                mail.TextBody = message.Body;
            }

            try
            {
                return Task.Run(() => smtp.SendMail(server, mail));
            }
            catch(Exception ex)
            {
                throw new Exception("Sending email failed (see inner exception.)", ex);
            }
        }
    }
}