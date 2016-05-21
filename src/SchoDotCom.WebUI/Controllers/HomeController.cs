using SchoDotCom.WebUI.ViewModels.Home;
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
            var viewModel = new AboutViewModel(1987);
            return View(viewModel);
        }

        [Route("resume")]
        public ActionResult Resume()
        {
            var viewModel = new ResumeViewModel();
            return View(viewModel);
        }
    }
}