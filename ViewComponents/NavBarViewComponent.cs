using HelpDesk.Model;
using HelpDesk.Models;
using HelpDesk.Services;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HelpDesk.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
       private IMenuService _menuService;
        private RoleManager<IdentityRole> _roleManger;
        private readonly UserManager<ApplicationUser> _userManager;

        public NavBarViewComponent(IMenuService menuService, RoleManager<IdentityRole> roleManger, UserManager<ApplicationUser> userManager)
        {
            _menuService = menuService;
            _roleManger = roleManger;
            _userManager = userManager;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var userId = (User as ClaimsPrincipal).Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = await _userManager.FindByIdAsync(userId);
                var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
                var UserRolesId = await GetRoleIdsAsync(userRoles);
                MenusViewModel model = new MenusViewModel(UserRolesId,_menuService);
               return await Task.FromResult(View(model)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //this._logger.LogError(ex, ex.Message, null);
                return View(new MenusViewModel(null,_menuService));
            }
        }

        public async Task<List<string>> GetRoleIdsAsync(List<string> roleNames)
        {
            var roleIds = new List<string>();

            foreach (var item in roleNames)
            {
                roleIds.Add((await _roleManger.FindByNameAsync(item))?.Id);

            }
            return roleIds;
            
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }

    
}
