using Microsoft.AspNet.Identity;
using Owin;
using SchoDotCom.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

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

			var DefaultUsername = ConfigurationManager.AppSettings["schodotcom:DefaultUsername"];
			var DefaultPassword = ConfigurationManager.AppSettings["schodotcom:DefaultPassword"];

			ApplicationUser user = userManager.FindByEmail(DefaultUsername);
			if (user == null)
				userManager.Create(new ApplicationUser { UserName = DefaultUsername, Email = DefaultUsername, PasswordHash = userManager.PasswordHasher.HashPassword(DefaultPassword) });

			user = userManager.FindByName(DefaultUsername);

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