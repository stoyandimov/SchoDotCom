using SchoDotCom.WebUI.ViewModels.Contact;
using System.Web.Mvc;

namespace SchoDotCom.WebUI.Controllers
{
	[AllowAnonymous]
	[RoutePrefix("")]
	public class ContactController : Controller
	{
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
				contact.IsSent = ModelState.IsValid;
			}
			return View(contact);
		}
	}
}