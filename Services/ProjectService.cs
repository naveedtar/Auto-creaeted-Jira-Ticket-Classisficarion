using HelpDesk.Data;
using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Services
{
    public interface IProjectService
    {
        List<SelectListItem> ProjectListDD();
        bool CreateUpdateProjectAsync(Project models);
        Project GetProjectById(int id);
        IQueryable<Project> GetAllValidProjectList();
        bool DeleteProject(int id);

        IQueryable<UserProject> GetAllValidUserProjectList();

        bool CreateUpdateUserProjectAsync(UserProject models);
        bool DeleteUserProject(int id);



    }

    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> ProjectListDD()
        {
            return _context.Projects.Select(u => new SelectListItem { Text = u.ProjectName, Value = u.Id.ToString() }).ToList();


        }
        public bool CreateUpdateProjectAsync(Project models)
        {
            string StoredProc = @"exec sp_ProjectInsert " +
           "@projectName = '" + models.ProjectName + "'," +
           "@id = " + models.Id + "";
            var result = _context.Database.ExecuteSqlRaw(StoredProc);
            return true;
        }
        public Project GetProjectById(int id)
        {
            return _context.Projects.Find(id);
        }
        public IQueryable<Project> GetAllValidProjectList()
        {
            return _context.Projects;
        }

        public bool DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Entry(project).State=EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public IQueryable<UserProject> GetAllValidUserProjectList()
        {
            return _context.UserProjects.Include(u => u.Project).Include(u => u.User);
        }

        public bool CreateUpdateUserProjectAsync(UserProject models)
        {
            var data = _context.UserProjects.FirstOrDefault(u => u.Id == models.Id);
            if (data == null)
            {
                data = new UserProject();
            }
            data.UserId = models.UserId;
            data.ProjectId = models.ProjectId;
            data.ViewPermission = models.ViewPermission;
            data.EditPermission = models.EditPermission;
            data.CreatePermission = models.CreatePermission;
            data.DeletePermission = models.DeletePermission;
            _context.Entry(data).State = models.Id > 0 ? EntityState.Modified : EntityState.Added;
            _context.SaveChanges();
            return true;
        }
        public bool DeleteUserProject(int id)
        {
            var data = _context.UserProjects.FirstOrDefault(u => u.Id == id);
            _context.Entry(data).State = EntityState.Deleted;
            
            _context.SaveChanges();
            return true;

        }


    }
}
