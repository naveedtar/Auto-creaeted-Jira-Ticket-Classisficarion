using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class IncidentMaster
    {

        public IncidentMaster()
        {
            IncidentProgress = new HashSet<IncidentProgress>();
        }
        public int ID { get; set; }
        public int ProjectsID { get; set; }
        public DateTime IncidentDate { get; set; }
        public TimeSpan IncidentTime { get; set; }
        public string IncidentNo { get; set; }
        public string AlternateIncidentNo { get; set; }
        public string IncidentDescription { get; set; }
        public DateTime LoggedDate { get; set; }
        public TimeSpan LoggedTime { get; set; }
        public string FKReporttedBy { get; set; }
        public int FKIncidentCategory { get; set; }
        public int FKIncidentLevel { get; set; }
        public int FKIncidentStatus { get; set; }
        public int? FKLoggedBy { get; set; }   
        public string Attachment { get; set; }   

        [ForeignKey("ProjectsID")]
        public virtual Project Project { get; set; } 
        
        [ForeignKey("FKIncidentCategory")]
        public virtual IncidentCategoriesLU IncidentCategoriesLU { get; set; } 
        
        [ForeignKey("FKIncidentLevel")]
        public virtual IncidentPriorityLevelsLU IncidentPriorityLevelsLU { get; set; }    
        
        public virtual ICollection<IncidentProgress> IncidentProgress { get; set; }




    }
}
