using Microsoft.AspNet.Identity.EntityFramework;
using SchoDotCom.WebUI.Models;
using System.Collections.Generic;

namespace SchoDotCom.WebUI.Areas.Admin.Models
{
    public class RoleUsersViewModel
    {
        public IdentityRole Role { get; set; } 

        public IEnumerable<ApplicationUser> Users { get;  set; }

        public RoleUsersViewModel()
        {

        }

        public RoleUsersViewModel(IdentityRole role, IEnumerable<ApplicationUser> users)
        {
            Users = users;
            Role = role;
        }
    }
}