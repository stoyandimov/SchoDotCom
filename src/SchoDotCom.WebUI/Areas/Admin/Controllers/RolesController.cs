using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoDotCom.WebUI.Areas.Admin.Models;
using SchoDotCom.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SchoDotCom.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles="admin")]
	public class RolesController : Controller
	{
		private RoleManager<IdentityRole> RoleManager { get; set; }
		private ApplicationUserManager UserManager { get; set; }

		public RolesController(RoleManager<IdentityRole> roleManager, ApplicationUserManager userManager)
		{
			RoleManager = roleManager;
			UserManager = userManager;
		}

		// GET: Admin/Role
		public ActionResult Index()
		{
			return View(RoleManager.Roles.Select(R => new RoleViewModel() { Id = R.Id, Name = R.Name, UsersInRole = R.Users.Count }));
		}

		// GET: Admin/Role/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Role/Create
		[HttpPost]
		public ActionResult Create(RoleViewModel role)
		{
			if (role == null)
				throw new ArgumentNullException("role");

			if (RoleManager.RoleExists(role.Name))
				ModelState.AddModelError("Name", "Role already exists");

			if (ModelState.IsValid)
			{
				IdentityRole r = new IdentityRole(role.Name);
				RoleManager.Create(r);
				return RedirectToAction("Index");
			}

			return View(role);
		}

		// GET: Admin/Role/Edit/5
		public ActionResult Edit(string id)
		{
			IdentityRole r = RoleManager.FindById(id);
			if (r == null)
				return HttpNotFound();

			var role = new RoleViewModel(r);

			return View(role);
		}

		// POST: Admin/Role/Edit/5
		[HttpPost]
		public ActionResult Edit(string id, RoleViewModel role)
		{
			if (role == null)
				throw new ArgumentNullException("role");

			IdentityRole r = RoleManager.FindById(id);
			if (r == null)
				return HttpNotFound();

			if (r.Name != role.Name && RoleManager.RoleExists(role.Name))
				ModelState.AddModelError("Name", "Role already exists");

			if (ModelState.IsValid)
			{
				r.Name = role.Name;
				RoleManager.Update(r);
				return RedirectToAction("Index");
			}

			return View(role);
		}

		// GET: Admin/Role/Delete/5
		public ActionResult Delete(string id)
		{
			IdentityRole r = RoleManager.FindById(id);
			if (r == null)
				return HttpNotFound();

			var role = new RoleViewModel(r);

			return View(role);
		}

		// POST: Admin/Role/Delete/5
		[HttpPost]
		public ActionResult Delete(string id, RoleViewModel role)
		{
			IdentityRole r = RoleManager.FindById(id);
			if (r == null)
				return HttpNotFound();

			RoleManager.Delete(r);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Users(string id)
		{
			IdentityRole role = RoleManager.FindById(id);
			if (role == null)
				return HttpNotFound();

			var Model = new RoleUsersViewModel(role, UserManager.Users.Where(U => U.Roles.Any(R => R.RoleId == id)));

			return View(Model);
		}
	}
}
