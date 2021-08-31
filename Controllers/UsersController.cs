using HelpDesk.Model;
using HelpDesk.Models;
using HelpDesk.Services;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()

        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            RoleViewModel model = new RoleViewModel();
            model.RoleNames = (await _userManager.GetRolesAsync(user)).ToList();
            model.RolesDD = _roleManager.Roles.Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
            model.UserId = id;
            ViewBag.UserName = user.Name;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<string> RoleNames, string UserId)
        {

            var user = await _userManager.FindByIdAsync(UserId);
            ViewBag.UserName = user.Name;
            var previousRoles = (await _userManager.GetRolesAsync(user)).ToList();
            foreach (var item in previousRoles)
            {
                 await _userManager.RemoveFromRoleAsync(user, item);
            }

            foreach (var item in RoleNames)
            {
                await _userManager.AddToRoleAsync(user, item);
            }

            return RedirectToAction("Index");
        }

    }
}
