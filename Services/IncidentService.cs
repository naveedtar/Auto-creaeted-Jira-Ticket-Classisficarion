using HelpDesk.Data;
using HelpDesk.Models;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Services
{

    public interface IIncidentService
    {

        IQueryable<IncidentMaster> GetAllIncident();
        IncidentSearchViewModel LoadIncidentSearchViewModel(IncidentSearchViewModel model);

    }
    public class IncidentService : IIncidentService
    {
        private readonly ApplicationDbContext _context;

        public IncidentService(ApplicationDbContext context)
        {
            _context = context;

        }
        public IQueryable<IncidentMaster> GetAllIncident()
        {
            return _context.IncidentMaster.Include(c => c.Project).Include(g => g.IncidentCategoriesLU).Include(c => c.IncidentPriorityLevelsLU);
           


        }
        public IncidentSearchViewModel LoadIncidentSearchViewModel(IncidentSearchViewModel model)
        {
            model.SortByDD = new List<SelectListItem>();
            model.StatusDD = new List<SelectListItem>();
            model.IncidentNoDD = _context.IncidentMaster.Select(u => new SelectListItem { Text = u.IncidentNo, Value = u.IncidentNo }).ToList();
            model.SortByDD.Add(new SelectListItem() { Text = "Created", Value = "1" });
            model.SortByDD.Add(new SelectListItem() { Text = "Updated", Value = "2" });
            model.StatusDD.Add(new SelectListItem() { Text = "Open", Value = "1" });
            model.StatusDD.Add(new SelectListItem() { Text = "Close", Value = "5" });
            model.ProjectsDD = _context.Projects.Select(u => new SelectListItem { Text = u.ProjectName, Value = u.Id.ToString() }).ToList();

            return model;
        }


    }
}
