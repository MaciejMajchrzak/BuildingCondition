using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.DashboardViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildingCondition.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserService userService;

        public DashboardController(UserManager<IdentityUser> _userManager, 
            IUserService _userService)
        {
            userManager = _userManager;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            ICollection<User> users = userService.GetAll();

            DashboardUsersViewModel dashboardUsersViewModel = new DashboardUsersViewModel()
            {
                Users = users
            };

            return View(dashboardUsersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserLock(string id)
        {
            await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> UserUnlock(string id)
        {
            await userManager.AddToRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("Users");
        }
    }
}