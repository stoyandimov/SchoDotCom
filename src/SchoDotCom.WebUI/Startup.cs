using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoDotCom.WebUI.Data;
using SchoDotCom.WebUI.Models;
using SchoDotCom.WebUI.Services;

namespace SchoDotCom.WebUI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            // Sets up developer mode for App Insights
            if (env.IsDevelopment())
                builder.AddApplicationInsightsSettings(developerMode: true);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            // Add App inghts (Monitor from Azure)
            services.AddApplicationInsightsTelemetry(Configuration);

            services.Configure<SmtpSettings>(Configuration.GetSection("Smtp"));

            // Add custom settings that don't belong to other secions
            services.Configure<AppSettings>(Configuration.GetSection("SchoDotCom"));
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddTransient<EmailService>();
            services.AddTransient<SmsService>();
            services.AddTransient<PageAccessControlManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Apply any pending ef db migrations
            DatabaseMigrator.Migrate(app);

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
