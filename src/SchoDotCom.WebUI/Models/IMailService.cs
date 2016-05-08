using System.Net.Mail;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Models
{
    public interface IMailService
    {
        Task SendAsync(MailMessage message);
    }
}