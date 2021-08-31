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

namespace IspdHelpDesk.Controllers
{
    public class IncidentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncidentController(ApplicationDbContext context)
        {         
            this._context = context;       
        }
        public IActionResult Index()
        {          
            return View(_context.IncidentViewModel
                .FromSqlRaw("[dbo].[IncidentMaster_GetIncidentsByAll]").ToList());
        }
    }
}
