using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class IncidentCategoriesLU
    {
        [Key]
        public int ID { get; set; }
        public string Categories { get; set; }
        public int FKClientID { get; set; }

    }
}
