using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoDotCom.WebUI.Areas.Admin.Models;
using SchoDotCom.WebUI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoDotCom.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    [RouteArea("Admin")]
    public class UsersController : Controller
    {

        private ApplicationSignInManager SignInManager { get; set; }
        private ApplicationUserManager UserManager { get; set; }
        private RoleManager<IdentityRole, string> RoleManager { get; set; }

        // To be used with dependency injection
        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, RoleManager<IdentityRole, string> roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            //var model = UserManager.Users.Select(U => new UserViewModel(U)).ToArray();
            var model = UserManager.Users.Select(U => new UserViewModel()
            {
                Id = U.Id,
                Email = U.Email,
                EmailConfirmed = U.EmailConfirmed,
                UserName = U.UserName
            });
            return View(model);
        }

        // GET: Admin/Users/Details/a
        public ActionResult Details(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // GET: Admin/Users/Delete/a
        public ActionResult Delete(string id)
        {
            ApplicationUser appUser = UserManager.FindById(id);
            if (appUser == null)
                return HttpNotFound();

            var user = new UserViewModel(appUser);

            return View(user);
        }

        // POST: Admin/Users/Delete/a
        [HttpPost]
        public async Task<ActionResult> Delete(string id, UserViewModel user)
        {
            ApplicationUser appUser = UserManager.FindById(id);
            if (appUser == null)
                return HttpNotFound();

            if (appUser.UserName == User.Identity.Name)
                throw new InvalidOperationException("Deleteing current user is not allowed!");

            await UserManager.DeleteAsync(appUser);
            RedirectToAction("Index");

            return View(user);
        }

        public ActionResult Roles(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
                return HttpNotFound();

            var roles = RoleManager.Roles;
            var model = new UserRolesViewModel(user, roles);

            return View(model);
        }

        [Route("AddRole/{userId}/{role}")]
        public ActionResult AddRole(string userId, string role)
        {
            ApplicationUser user = UserManager.FindById(userId);
            if (user == null)
                return HttpNotFound();

            if (!RoleManager.RoleExists(role))
                return HttpNotFound();

            UserManager.AddToRole(userId, role);

            return RedirectToAction("Roles", new { id = userId });
        }

        [Route("RemoveRole/{userId}/{role}")]
        public ActionResult RemoveRole(string userId, string role)
        {
            ApplicationUser user = UserManager.FindById(userId);
            if (user == null)
                return HttpNotFound();

            if (!RoleManager.RoleExists(role))
                return HttpNotFound();

            UserManager.RemoveFromRole(userId, role);
            return RedirectToAction("Roles", new { id = userId });
        }

    }
}
