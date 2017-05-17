using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoDotCom.WebUI.ViewModels.Contact;


namespace SchoDotCom.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        [HttpGet]
        [Route("contact")]
        public ActionResult Index()
        {
            var viewModel = new ContactCreateViewModel();
            return View(viewModel);
        }
        
        [HttpPost]
        [Route("contact")]
        public ActionResult Index(ContactCreateViewModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    throw new System.NotImplementedException();
                    //var msg = new MailMessage()
                    //{
                    //    Body = contact.Message,
                    //    Subject = $"SchoDotCom::Contact: {contact.Name} ({contact.Email})",
                    //};
                    //msg.ReplyToList.Add(new MailAddress(contact.Email, contact.Name));
                    //msg.To.Add(ConfigurationManager.AppSettings["schodotcom:DefaultUsername"] as string);
                    //EmailService.SendAsync(msg).Wait();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError("message", "Something went wrong on my side! Sending message failed!");
                }
            }

            contact.IsSent = ModelState.IsValid;
            return View(contact);
        }
    }
}