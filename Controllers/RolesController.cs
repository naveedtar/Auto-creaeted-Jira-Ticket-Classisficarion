using HelpDesk.Model;
using HelpDesk.Models;
using HelpDesk.Services;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IMenuService _menuService;
        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMenuService menuService)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                var result = await _roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            RoleViewModel model = new RoleViewModel { RoleName = role.Name, Id = role.Id };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                role.Name = model.RoleName;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");

            }

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> AssignMenuToRole(string id)
        {
            var menuIds = _menuService.GetAllValidRoleMenusList(id).Select(u=>u.MenuId).ToList();
            var roleName = (await _roleManager.FindByIdAsync(id))?.Name ;
            RoleViewModel model = new RoleViewModel { MenusDD = _menuService.MenusList(""), Id = id, MenuIds = menuIds,RoleName= roleName };
            return View(model);
        }
        [HttpPost]
        public IActionResult AssignMenuToRole(List<int> MenuIds, string Id)
        {
            _menuService.CreateUpdateRoleMenus(MenuIds, Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }


    }
}
