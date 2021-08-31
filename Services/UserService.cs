using HelpDesk.Data;
using HelpDesk.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Linq;

namespace HelpDesk.Services
{


    public interface IUserService
    {
        IQueryable<ApplicationUser> GetAllValidUsers();
    }
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        //public async Task<ApplicationUser> GetUser(string id)
        //{

        //    return await _userManager.ll(id);
        //}
        public IQueryable<ApplicationUser> GetAllValidUsers()
        {
            
            return _userManager.Users;
        }

    }
}