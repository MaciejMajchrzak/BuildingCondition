using BuildingCondition.Db.Models;
using BuildingCondition.Mvc.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingCondition.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<IdentityUser> _signInManager,
            UserManager<IdentityUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName
                };

                if (!await roleManager.RoleExistsAsync("ActiveUser")) { await roleManager.CreateAsync(new IdentityRole("ActiveUser")); }
                if (!await roleManager.RoleExistsAsync("Admin")) { await roleManager.CreateAsync(new IdentityRole("Admin")); }

                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    var login = await signInManager.PasswordSignInAsync(registerViewModel.UserName, registerViewModel.Password, true, false);

                    if (login.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync(registerViewModel.UserName), "ActiveUser");
                        //await userManager.AddToRoleAsync(await userManager.FindByNameAsync(registerViewModel.UserName), "Admin");

                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to log in!");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, true, false);

                var isInRole = await userManager.IsInRoleAsync(
                    await userManager.FindByNameAsync(
                        loginViewModel.UserName), "ActiveUser");

                if (result.Succeeded && isInRole)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                if (result.Succeeded && !isInRole)
                {
                    ModelState.AddModelError("", "You are blocked!");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to log in!");
                }
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}