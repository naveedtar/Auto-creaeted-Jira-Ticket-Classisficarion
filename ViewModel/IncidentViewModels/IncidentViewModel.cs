using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.ViewModel
{
    public class IncidentViewModel
    {
        [Key]
        public string Id { get; set; }
        public Nullable<DateTime> IncidentDate { get; set; }
        public string IncidentDateDisplay { get; set; }
        public string HowLong { get; set; }
        public string IncidentNo { get; set; }
        public string ProjectName { get; set; }
        public string Categories { get; set; }
        /*
         Id	IncidentDate	IncidentDateDisplay	HowLong	IncidentNo	
        ProjectName	Categories	PriorityLevel	IncidentDescription	CreatedBy	
        CreatedDate	CreatedDateDisplay	IncidentStatusLUId	LatestRepliedBy	
        LatestRepliedDate	LatestRepliedDateDisplay   LatestIncidentStatusLUId	  IncidentStatus

         */
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

    }
}
