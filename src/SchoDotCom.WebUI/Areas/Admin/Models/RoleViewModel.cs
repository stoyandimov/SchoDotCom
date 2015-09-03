using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoDotCom.WebUI.Areas.Admin.Models
{
	public class RoleViewModel
	{

		public RoleViewModel()
		{
		}

		public RoleViewModel(IdentityRole role)
		{
			Id = role.Id;
			Name = role.Name;
			UsersInRole = role.Users.Count;
		}

		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		public int UsersInRole { get; set; }
	}
}