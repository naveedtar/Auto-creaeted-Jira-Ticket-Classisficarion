using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using HelpDesk.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HelpDesk.ViewModel;
using System.Security.Claims;
using HelpDesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using HelpDesk.Services;
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
            if (search.ProjectId != null && search.ProjectId.Count > 0)
            {
                data = data.Where(u => search.ProjectId.Contains(u.ProjectsID));
            }
            if (search.Status != null && search.Status.Count > 0)
            {
                data = data.Where(u => search.Status.Contains(u.IncidentStatusLUId));
            }
            if (search.FormDate.HasValue && search.ToDate.HasValue)
            {
                data = data.Where(u => u.IncidentDate >= search.FormDate && u.IncidentDate <= search.ToDate);
            }
            if (search.IncidentNo != null && search.IncidentNo.Count > 0)
            {
                data = data.Where(u => search.IncidentNo.Contains(u.IncidentNo));
            }
            if (!string.IsNullOrEmpty(search.SortBy))
            {
                if (search.SortBy == "1")
                {
                    data = data.OrderBy(u => u.CreatedDate);
                }
                else
                {
                    data = data.OrderByDescending(u => u.LatestRepliedDate);
                }
            }
            search.IncidentViewModels = data.ToPagedList(search.Page ?? 1, 2);

            return PartialView(search);
        }
    }
}
