using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using HelpDesk.Models;

namespace HelpDesk.ViewModel
{
    public class IncidentMasterViewModel
    {
       
       
        public Nullable<DateTime> IncidentDate { get; set; }
        public string IncidentDateDisplay { get; set; }
        public string IncidentNo { get; set; }
        public string ProjectName { get; set; }
        public string Categories { get; set; }

        public int ProjectId { get; set; }


        public string PriorityLevel { get; set; }
        public string IncidentDescription { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public Nullable<int> IncidentStatusLUId { get; set; }
        public string LatestRepliedBy { get; set; }
        public Nullable<DateTime> LatestRepliedDate { get; set; }
        public string LatestRepliedDateDisplay { get; set; }
        public Nullable<int> LatestIncidentStatusLUId { get; set; }
        public string IncidentStatus { get; set; }
        public ICollection <IncidentProgress> IncidentProgress { get; set; }

    }
}
