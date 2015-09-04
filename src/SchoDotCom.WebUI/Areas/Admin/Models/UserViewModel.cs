using SchoDotCom.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoDotCom.WebUI.Areas.Admin.Models
{
	public class UserViewModel
	{
		public UserViewModel()
		{

		}

		public UserViewModel(ApplicationUser user)
		{
			Id = user.Id;
			UserName = user.UserName;
			Email = user.Email;
			EmailConfirmed = user.EmailConfirmed;
		}

		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
	}


}