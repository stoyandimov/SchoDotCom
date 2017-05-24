using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SchoDotCom.WebUI.Models;
using SchoDotCom.WebUI.ViewModels.Contact;
using System.Threading.Tasks;

namespace SchoDotCom.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private EmailService _service;
        private SmtpSettings _smtpConfig;
        private ILogger<ContactController> _logger;

        public ContactController(EmailService service, ILoggerFactory logFac, IOptions<SmtpSettings> smtpConfig)
        {
            _service = service;
            _smtpConfig = smtpConfig.Value;
            _logger = logFac.CreateLogger<ContactController>();
        }

        [HttpGet]
        [Route("contact")]
        public ActionResult Index()
        {
            var viewModel = new ContactCreateViewModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [Route("contact")]
        public async Task<ActionResult> Index(ContactCreateViewModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.SendMailAsync((_smtpConfig.FromName, _smtpConfig.FromEmail), 
                        $"SchoDotCom::Contact: {contact.Name} ({contact.Email})", contact.Message);
                    contact.IsSent = true;
                }
                catch (System.Exception ex)
                {
                    _logger.LogCritical(new EventId(1), ex, "Sending email failed!");
                    ModelState.AddModelError("message", "Something went wrong on my side! Sending message failed!");
                }
            }

            return View(contact);
        }
    }
}