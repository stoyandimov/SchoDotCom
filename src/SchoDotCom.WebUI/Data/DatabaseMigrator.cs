using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SchoDotCom.WebUI.Data
{
    public class DatabaseMigrator
    {
        public static void Migrate(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider
                     .GetRequiredService<DatabaseContext>()
                     .Database
                     .Migrate();
            }
        }
    }
}
