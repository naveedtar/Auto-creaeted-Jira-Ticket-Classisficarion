using HelpDesk.Data;
using HelpDesk.Model;
using HelpDesk.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenusForRoles(List<string> userRolesId);
        List<string> GetRolesId(List<string> userRoles);
        List<SelectListItem> MenusList(string roleId, bool parent = false);
        bool CreateUpdateMenus(MenuViewModels models);
        MenuViewModels GetMenuById(int id);
        IQueryable<Menu> GetAllValidMenusList();
        IQueryable<RoleMenu> GetAllValidRoleMenusList(string roleId);

        bool CreateUpdateRoleMenus(List<int> menuIds, string roleId);

        bool DeleteMenu(int Id);
    }
    public class MenuService : IMenuService

    {
        private readonly ApplicationDbContext _dbContext;
        public MenuService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Menu> GetMenusForRoles(List<string> userRoleIds)
        {
            var menuIds = _dbContext.RoleMenus.Where(u => userRoleIds.Contains(u.RoleId)).Select(u => u.MenuId).ToList();
            return _dbContext.Menus.Where(u => menuIds.Contains(u.Id)).Distinct().ToList();

        }
        public List<SelectListItem> MenusList(string roleId, bool parent = false)
        {
            var menuIds = new List<int>();
            if (!string.IsNullOrEmpty(roleId))
            {
                menuIds = _dbContext.RoleMenus.Where(u => u.RoleId == roleId).Select(u => u.MenuId).ToList();
            }
            return _dbContext.Menus.Where(u => (menuIds.Count <= 0 || menuIds.Contains(u.Id)) && (!parent || !u.ParentID.HasValue)).Select(u => new SelectListItem { Text = u.MenuName, Value = u.Id.ToString() }).ToList();

        }

        public IQueryable<Menu> GetAllValidMenusList()
        {

            return _dbContext.Menus;

        }

        public bool CreateUpdateMenus(MenuViewModels models)
        {
            var menu = new Menu();
            if (models.Id > 0)
            {
                menu = _dbContext.Menus.FirstOrDefault(u => u.Id == models.Id);
            }
            menu.MenuActionName = models.MenuActionName;
            menu.MenuControllerName = models.MenuControllerName;
            menu.MenuName = models.MenuName;
            menu.ParentID = models.ParentID;
            menu.MenuOrder = models.MenuOrder;
            menu.Icon = models.Icon;
            _dbContext.Entry(menu).State = models.Id > 0 ? EntityState.Modified : EntityState.Added;
            _dbContext.SaveChanges();
            return true;



        }
        public List<string> GetRolesId(List<string> userRoles)
        {
            return default;
            //return _dbContext.ApplicationUserRoles.Where(u => userRoles.Contains(u.Name)).Select(u => u.Id).ToList();
        }

        public MenuViewModels GetMenuById(int id)
        {
            MenuViewModels model = new MenuViewModels();
            var menu = _dbContext.Menus.Find(id);
            if (menu != null)
            {
                model.Id = menu.Id;
                model.MenuActionName = menu.MenuActionName;
                model.MenuControllerName = menu.MenuControllerName;
                model.MenuName = menu.MenuName;
                model.MenuOrder = menu.MenuOrder;
                model.ParentID = menu.ParentID;
                model.Icon = menu.Icon;
                model.MenusDD = MenusList("", true);

            }

            return model;

        }

        public bool CreateUpdateRoleMenus(List<int> menuIds, string roleId)
        {
            var roleNotExist = _dbContext.RoleMenus.Where(u => !menuIds.Contains(u.MenuId) && u.RoleId == roleId).ToList();
            _dbContext.RemoveRange(roleNotExist);
            _dbContext.SaveChanges();
            foreach (var item in menuIds)
            {
                var role = _dbContext.RoleMenus.FirstOrDefault(u => u.MenuId == item && u.RoleId == roleId);
                if (role == null)
                {
                    role = new RoleMenu();
                    role.MenuId = item;
                    role.RoleId = roleId;
                    _dbContext.Add(role);
                    _dbContext.SaveChanges();
                }

            }
            return true;
        }
        public IQueryable<RoleMenu> GetAllValidRoleMenusList(string roleId)
        {
            return _dbContext.RoleMenus.Where(u => u.RoleId == roleId);
        }

        public bool DeleteMenu(int id)
        {
            var menu = _dbContext.Menus.Find(id);
            if (menu != null)
            {
                var rolemenu = _dbContext.RoleMenus.Where(u => u.MenuId == id).ToList();
                _dbContext.RoleMenus.RemoveRange(rolemenu);
                _dbContext.Remove(menu);
                _dbContext.SaveChanges();
            }
            return true;

        }
    }
}
