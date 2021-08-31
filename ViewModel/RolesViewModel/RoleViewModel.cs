using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.ViewModel
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public List<SelectListItem> RolesDD { get; set; }

        public List<int> MenuIds { get; set; }

        public List<string> RoleNames { get; set; }
        public List<SelectListItem> MenusDD { get; set; }


    }
}
