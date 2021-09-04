using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class IncidentProgress
    {
        public int Id { get; set; }
        public int IncidentMasterId { get; set; }
        public string FromUserId { get; set; }
        public int IncidentStatusLUId { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ToUserId { get; set; }

        [Timestamp]
        public byte[] dtVersion { get; set; } 
        
        [ForeignKey("IncidentMasterId")]
        public virtual IncidentMaster IncidentMaster { get; set; }
    }
}
 