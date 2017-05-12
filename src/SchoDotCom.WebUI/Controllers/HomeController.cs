using Microsoft.AspNetCore.Mvc;
using SchoDotCom.WebUI.ViewModels.Home;

namespace SchoDotCom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
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