using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoDotCom.WebUI.Models;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Services
{
    public class EmailService
    {
        private ILogger<EmailService> _logger;

        private SmtpSettings _config;

        public EmailService(ILoggerFactory loggerFac, IOptions<SmtpSettings> config)
        {
            _logger = loggerFac.CreateLogger<EmailService>();
            _config = config.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            await SendEmailAsync(("", email), subject, body, true);
        }

        public async Task SendEmailAsync((string Name, string Email) to, string subject, string body, bool isHtml = false)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config.FromName, _config.FromEmail));
            message.To.Add(new MailboxAddress(to.Name, to.Email));
            message.Subject = subject;
            message.Body = new TextPart(isHtml ? "html" : "plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                _logger.LogTrace($"Connecting to '{_config.Server}'...");
                // Explains why useSsl = false https://github.com/jstedfast/MailKit/issues/131
                await client.ConnectAsync(_config.Server, _config.Port, false);
                _logger.LogTrace($"Authenticting '{_config.Server}'...");
                await client.AuthenticateAsync(_config.Username, _config.Password);
                _logger.LogTrace($"Sending emal to '{to.Name} <{to.Email}>'...");
                await client.SendAsync(message);
                _logger.LogInformation($"Email sent to '{to.Name} <{to.Email}>'");

                await client.DisconnectAsync(true);
            }
        }
    }
}
