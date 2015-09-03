using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using SchoDotCom.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoDotCom.WebUI
{
    public partial class Startup
    {
        public void Seed(IAppBuilder app)
		{
			// Creates default user if not exist
			var userManager = new ApplicationUserManager(
				new UserStore<ApplicationUser>(
					new ApplicationDbContext()));

			var DefaultEmail = "stoyandimov@hotmail.com";

			ApplicationUser user = userManager.FindByEmail(DefaultEmail);
			if (user == null)
				userManager.Create(new ApplicationUser { UserName = DefaultEmail, Email = DefaultEmail, PasswordHash = userManager.PasswordHasher.HashPassword("01068")});

			user = userManager.FindByName(DefaultEmail);

			// Creates admin role if not exist

			var roleManager = new RoleManager<IdentityRole, string>(
				new RoleStore<IdentityRole>(
					new ApplicationDbContext()));

			var AdminRole = "admin";

			IdentityRole role = roleManager.FindByName(AdminRole);
			if (role == null)
				roleManager.Create(new IdentityRole { Name = AdminRole });

			// Add default user as admin
			if (!userManager.IsInRole(user.Id, AdminRole))
                userManager.AddToRole(user.Id, AdminRole);
		}

    }
}