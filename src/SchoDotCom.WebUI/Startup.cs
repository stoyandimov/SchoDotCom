using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoDotCom.WebUI.Data;
using SchoDotCom.WebUI.Models;
using SchoDotCom.WebUI.Services;
using System;

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

            // // Add identity options
            // services.Configure<IdentityOptions>(options =>
            // {
            //     // Password settings
            //     options.Password.RequireDigit = true;
            //     options.Password.RequiredLength = 8;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = true;
            //     options.Password.RequireLowercase = false;

            //     // Lockout settings
            //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //     options.Lockout.MaxFailedAccessAttempts = 10;

            //     // Cookie settings
            //     options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
            //     options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
            //     options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

            //     // User settings
            //     options.User.RequireUniqueEmail = true;

            //     // Signin settings
            //     options.SignIn.RequireConfirmedEmail = true;
            // });

            services.AddTransient<EmailService>();
            services.AddTransient<SmsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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
