using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HelpDesk.ViewModel
{
    public class IncidentSearchViewModel
    {
        public IPagedList<IncidentMasterViewModel> IncidentViewModels { get; set; }

        public List<SelectListItem> ProjectsDD { get; set; }

        public List<SelectListItem> IncidentNoDD{ get; set; }

        public List<SelectListItem> StatusDD { get; set; }
        public List<SelectListItem> SortByDD { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FormDate { get; set; }

        public List<int>  ProjectId { get; set; }

        public List<string> IncidentNo { get; set; }

        public List<int> Status { get; set; }
        public string SortBy { get; set; }

        public bool Submitted { get; set; }





    }
}
