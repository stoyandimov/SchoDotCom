using Microsoft.ApplicationInsights;
using SchoDotCom.WebUI.Models;
using SchoDotCom.WebUI.ViewModels.Contact;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;

namespace SchoDotCom.WebUI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("")]
    public class ContactController : Controller
    {

        private IMailService EmailService;

        public ContactController(IMailService emailService)
        {
            EmailService = emailService;
        }

        [HttpGet]
        [Route("contact")]
        public ActionResult Index()
        {
            var viewModel = new ContactViewModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [Route("contact")]
        public ActionResult Index(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var msg = new MailMessage()
                    {
                        Body = contact.Message,
                        Subject = "SchoDotCom contact form submission",
                        From = new MailAddress(contact.Email, contact.Name)
                    };
                    msg.To.Add(ConfigurationManager.AppSettings["schodotcom:DefaultUsername"] as string);
                    EmailService.SendAsync(msg).Wait();
                }
                catch (System.Exception ex)
                {
                    var ai = new TelemetryClient();
                    ai.TrackException(ex);
                    ModelState.AddModelError("message", "Something went wrong on our side! Sending message failed!");
                }
            }

            contact.IsSent = ModelState.IsValid;
            return View(contact);
        }
    }
}