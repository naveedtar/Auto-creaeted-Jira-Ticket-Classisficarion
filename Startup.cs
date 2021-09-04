using HelpDesk.Data;
using HelpDesk.Model;
using HelpDesk.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static HelpDesk.ViewComponents.RoleEnum.CustomClaimTypes;

namespace HelpDesk
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddHealthChecks();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
            });
            services.AddAuthorization(options =>
            {
                
                options.AddPolicy(PolicyTypes.ApplicationOrTechnicalConsultants.Manage, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.ApplicationOrTechnicalConsultants));
                options.AddPolicy(PolicyTypes.Clients.View, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.Clients));
                options.AddPolicy(PolicyTypes.SuperUser.All, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.SuperUser));
                options.AddPolicy(PolicyTypes.Clients2.Admin, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.Clients2));
                options.AddPolicy(PolicyTypes.CompanyStaff.admin, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.CompanyStaff));
                options.AddPolicy(PolicyTypes.DedicatedSupportStaff.Admin, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.DedicatedSupportStaff));
                options.AddPolicy(PolicyTypes.ManagingDirectorOrDirectors.Admin, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.ManagingDirectorOrDirectors));
                options.AddPolicy(PolicyTypes.ProjectDirectors.admin, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.ProjectDirectors));
                options.AddPolicy(PolicyTypes.ProjectManager.Manage, policy => policy.RequireClaim(ClaimTypes.Role, SecurityGroups.ProjectManager));
              
            });
            services.AddControllersWithViews();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IIncidentService, IncidentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                
            });
        }
    }
}
