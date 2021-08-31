using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Data;
using HelpDesk.Models;
using HelpDesk.Services;
using Microsoft.AspNetCore.Identity;
using HelpDesk.Model;

namespace HelpDesk.Controllers
{
    public class UserProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManger;

        public UserProjectsController(IProjectService projectService, UserManager<ApplicationUser> userManger)
        {
            _projectService = projectService;
            _userManger = userManger;
        }

        // GET: UserProjects
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.userName = (await _userManger.FindByIdAsync(id)).Name;
            ViewBag.UserId = id;
            return View(_projectService.GetAllValidUserProjectList().Where(u => u.UserId == id).ToList());
        }


        // GET: UserProjects/Create
        public  async Task<IActionResult> Create(string id)
        {
            ViewBag.projects = _projectService.ProjectListDD();
            UserProject userProject = new UserProject();
            ViewBag.userName = (await _userManger.FindByIdAsync(id)).Name;
            userProject.UserId = id;
            return View(userProject);
        }

        // POST: UserProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProject userProject)
        {
            if (!ModelState.IsValid && userProject.ProjectId > 0)
            {
                _projectService.CreateUpdateUserProjectAsync(userProject);
                return RedirectToAction(nameof(Index), new { id = userProject.UserId });
            }
            ViewBag.projects = _projectService.ProjectListDD();
            ViewBag.userName = (await _userManger.FindByIdAsync(userProject.UserId)).Name;
            return View(userProject);
        }

        // GET: UserProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProject = _projectService.GetAllValidUserProjectList().FirstOrDefault(u => u.Id == id);
            if (userProject == null)
            {
                return NotFound();
            }
            ViewBag.userName = (await _userManger.FindByIdAsync(userProject.UserId)).Name;
            ViewBag.projects = _projectService.ProjectListDD();
            return View(userProject);
        }

        // POST: UserProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                _projectService.CreateUpdateUserProjectAsync(userProject);
                return RedirectToAction(nameof(Index), new { id = userProject.UserId });
            }
            ViewBag.projects = _projectService.ProjectListDD();
            ViewBag.userName = (await _userManger.FindByIdAsync(userProject.UserId)).Name;
            return View(userProject);
        }

        public IActionResult Delete(int id, string userId)
        {
            _projectService.DeleteUserProject(id);
            return RedirectToAction(nameof(Index), new { id = userId });
        }


    }
}
