using Microsoft.AspNet.Identity;
using SchoDotCom.WebUI.Areas.Admin.Models;
using SchoDotCom.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SchoDotCom.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles="admin")]
    public class UsersController : Controller
    {

		private ApplicationSignInManager SignInManager { get; set; }
		private ApplicationUserManager UserManager { get; set; }

		// To be used with dependency injection
		public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		// GET: Admin/Users
		public ActionResult Index()
        {
			IEnumerable<UserViewModel> model = 
				UserManager.Users.Select(U => new UserViewModel() {
					Id = U.Id,
					Email = U.Email,
					EmailConfirmed = U.EmailConfirmed,
					UserName = U.UserName});

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

			var user = new UserViewModel()
			{
				Id = appUser.Id,
				Email = appUser.Email,
				EmailConfirmed = appUser.EmailConfirmed,
				UserName = appUser.UserName
			};

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

    }
}
