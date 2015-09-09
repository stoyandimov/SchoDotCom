using System.Web.Mvc;

namespace SchoDotCom.WebUI.Controllers
{
	[RoutePrefix("")]
	public class HomeController : Controller
	{
		[Route]
		public ActionResult Index()
		{
			return View();
		}

		[Route("about")]
		public ActionResult About()
		{
			return View();
		}

		[Route("contact")]
		public ActionResult Contact()
		{
			return View();
		}
	}
}