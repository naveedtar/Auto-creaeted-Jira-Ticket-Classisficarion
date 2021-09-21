using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HelpDesk.ViewModel;
using HelpDesk.Services;
using IspdHelpDesk.Services;
using X.PagedList;

namespace IspdHelpDesk.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IIncidentService _incidentService;



        public IncidentController(IIncidentService incidentService)
        {
            this._incidentService = incidentService;
        }


        public IActionResult Index(IncidentSearchViewModel search, int? page)
        {


            _incidentService.LoadIncidentSearchViewModel(search);
            var data = _incidentService.GetIncidentData();
            search.IncidentViewModels = data.ToPagedList(page ?? 1, 2);
            return View(search);
        }

        public IActionResult _FilterData(IncidentSearchViewModel search)
        {

            var data = _incidentService.GetIncidentData();
            if (search.ProjectId is { Count: > 0 })
            {
                data = data.Where(u => search.ProjectId.Contains(u.ProjectsID));
            }
            if (search.Status is { Count: > 0 })
            {
                if (search.Status.Count < 2)
                {
                    if (search.Status.Any(u => u is 1))
                    {
                        data = data.Where(u => u.LatestIncidentStatusLUId != 5);
                    }
                    else
                    {
                        data = data.Where(u => search.Status.Contains(u.LatestIncidentStatusLUId));
                    }
                }
            }
            if (search.FormDate.HasValue && search.ToDate.HasValue)
            {

                search.ToDate = search.ToDate.Value.AddDays(1);
                data = data.Where(u => u.IncidentDate >= search.FormDate && u.IncidentDate <= search.ToDate);
            }
            if (search.IncidentNo != null && search.IncidentNo.Count > 0)
            {
                data = data.Where(u => search.IncidentNo.Contains(u.IncidentNo));
            }
            if (!string.IsNullOrEmpty(search.SortBy))
            {
                data = search.SortBy == "1" ? data.OrderBy(u => u.CreatedDate) : data.Where(u=> u.LatestRepliedBy != null).OrderByDescending(u => u.LatestRepliedBy);
            }
            search.IncidentViewModels = data.ToPagedList(search.Page ?? 1, 2);

            return PartialView(search);
        }

    }
}
