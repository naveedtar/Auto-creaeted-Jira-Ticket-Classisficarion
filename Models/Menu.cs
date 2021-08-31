using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Model
{
    public class Menu
    {
        public Menu()
        {
            RoleMenus = new HashSet<RoleMenu>();
        }

        public int Id { get; set; }

        public string MenuName { get; set; }
        public int? ParentID { get; set; }
        public string MenuControllerName { get; set; }
        public string MenuActionName { get; set; }
        public string Icon { get; set; }
        public int? MenuOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
