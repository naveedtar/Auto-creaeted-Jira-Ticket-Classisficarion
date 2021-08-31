using HelpDesk.Model;
using HelpDesk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.ViewModel
{
    public class MenusViewModel
    {

        public MenusViewModel(List<string> roles,IMenuService menuService)
        {

            this.TotalMenus = menuService.GetMenusForRoles(roles); 

        }
        public List<Menu> TotalMenus { get; set; }

    }

    
}
