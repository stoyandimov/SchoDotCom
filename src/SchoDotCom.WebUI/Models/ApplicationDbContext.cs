using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoDotCom.WebUI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}