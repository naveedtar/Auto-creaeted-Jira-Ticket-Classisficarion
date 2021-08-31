using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Model
{
    public class ApplicationUser : IdentityUser
    {

        
        public int? ClientsID { get; set; }
        public string MobileNo01 { get; set; }

        [Required]
        public string Name { get; set; }
        public string Position { get; set; }


    }
}
