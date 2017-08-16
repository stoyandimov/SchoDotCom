using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SchoDotCom.WebUI.Data;

namespace SchoDotCom.WebUI.Data
{
    public class DatabaseContextDesignTimeFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseSqlite("Data Source=database.db;");
            return new DatabaseContext(options.Options);
        }
    }
}
