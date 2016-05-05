using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            throw new NotImplementedException();
        }
    }
}