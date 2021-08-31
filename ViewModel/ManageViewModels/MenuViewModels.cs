using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.ViewModel
{
    public class MenuViewModels
    {
        public int Id { get; set; }

        [Required]
        public string MenuName { get; set; }
        public int? ParentID { get; set; }
        public string MenuControllerName { get; set; }
        public string MenuActionName { get; set; }
        public string Icon { get; set; }

        public int? MenuOrder { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> MenusDD { get; set; }
    }
}
