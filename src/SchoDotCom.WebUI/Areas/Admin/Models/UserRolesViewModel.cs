using Microsoft.AspNet.Identity.EntityFramework;
using SchoDotCom.WebUI.Models;
using System.Collections.Generic;

namespace SchoDotCom.WebUI.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }

        public ApplicationUser User { get;  set; }

        public UserRolesViewModel()
        {

        }

        public UserRolesViewModel(ApplicationUser user, IEnumerable<IdentityRole> roles)
        {
            User = user;
            Roles = roles;
        }
    }
}