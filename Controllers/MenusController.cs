using HelpDesk.Model;
using HelpDesk.Services;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HelpDesk.ViewComponents.RoleEnum.CustomClaimTypes;

namespace HelpDesk.Controllers
{
    [Authorize(Roles = SecurityGroups.SuperUser + "," + SecurityGroups.ProjectManager)]
    public class MenusController : Controller
    {
        private readonly IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public IActionResult Index()
        {
            
            return View(_menuService.GetAllValidMenusList().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            MenuViewModels model = new MenuViewModels { MenusDD = _menuService.MenusList("", true)};
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MenuViewModels menus)
        {
            if (ModelState.IsValid)
            {
                var status = _menuService.CreateUpdateMenus(menus);
                if (status)
                    return RedirectToAction("Index");
                return View(menus);


            }
            return View(menus);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menu = _menuService.GetMenuById(id);

            return View(menu);
        }

        [HttpPost]
        public IActionResult Edit(MenuViewModels menus)
        {
            if (ModelState.IsValid)
            {
                var status = _menuService.CreateUpdateMenus(menus);
                if (status)
                    return RedirectToAction("Index");
                return View(menus);


            }
            return View(menus);
        }

        public IActionResult Delete(int id)
        {
            var menu = _menuService.DeleteMenu(id);
            return RedirectToAction("Index");
        }
    }
}
