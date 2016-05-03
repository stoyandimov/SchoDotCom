using System.Web.Mvc;

namespace SchoDotCom.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [RouteArea("admin")]
    [RoutePrefix("")]
    public class AdminHomeController : Controller
    {
        // GET: Admin/Home
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}