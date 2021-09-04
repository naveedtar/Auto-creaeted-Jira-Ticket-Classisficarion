using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class IncidentPriorityLevelsLU
    {
        public int ID { get; set; }
        public int FKClientID { get; set; }
        public string PriorityLevel { get; set; }
        public string SLANotes { get; set; }
    }

}
