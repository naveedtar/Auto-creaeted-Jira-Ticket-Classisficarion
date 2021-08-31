using HelpDesk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class UserProject
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public bool CreatePermission { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
        public bool ViewPermission { get; set; }
        public virtual Project Project { get; set; }
        public virtual ApplicationUser User { get; set; }



    }
}
