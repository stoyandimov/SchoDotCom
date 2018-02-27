using Microsoft.AspNetCore.Mvc;
using SchoDotCom.WebUI.Models;
using SchoDotCom.WebUI.ViewModels.Home;

namespace SchoDotCom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        PageAccessControlManager _acl;

        public HomeController(PageAccessControlManager acl)
            => _acl = acl;

        [Route("")]
        public ActionResult Index()
        {
            if (_acl.IsPageDisabled("home"))
                return NotFound();

            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            if (_acl.IsPageDisabled("about"))
                return NotFound();

            var viewModel = new AboutViewModel(1987);
            return View(viewModel);
        }

        [Route("resume")]
        public ActionResult Resume()
        {
            if (_acl.IsPageDisabled("resume"))
                return NotFound();

            var viewModel = new ResumeViewModel();
            return View(viewModel);
        }
    }
}