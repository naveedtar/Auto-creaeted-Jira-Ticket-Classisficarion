using HelpDesk.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HelpDesk.Models;
using HelpDesk.ViewModel;

namespace HelpDesk.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        public DbSet<IncidentViewModel> IncidentViewModel { get; set; }
        public DbSet<IncidentMaster> IncidentMaster { get; set; }
        public DbSet<IncidentCategoriesLU> IncidentCategoriesLU { get; set; }
        public DbSet<IncidentPriorityLevelsLU> IncidentPriorityLevelsLU { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
           
          
            base.OnModelCreating(builder);

        }





    }
}
