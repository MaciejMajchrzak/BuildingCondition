using BuildingCondition.Db.Models;
using BuildingCondition.Mvc.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "AccountRegister")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "AccountRegister")]
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

                if (!await roleManager.RoleExistsAsync("ActiveUser"))                   { await roleManager.CreateAsync(new IdentityRole("ActiveUser")); }
                if (!await roleManager.RoleExistsAsync("Admin"))                        { await roleManager.CreateAsync(new IdentityRole("Admin")); }
                
                if (!await roleManager.RoleExistsAsync("AccountRegister"))              { await roleManager.CreateAsync(new IdentityRole("AccountRegister")); }
                
                if (!await roleManager.RoleExistsAsync("ApartmentAdd"))                 { await roleManager.CreateAsync(new IdentityRole("ApartmentAdd")); }
                if (!await roleManager.RoleExistsAsync("ApartmentAddElectricalReport")) { await roleManager.CreateAsync(new IdentityRole("ApartmentAddElectricalReport")); }
                if (!await roleManager.RoleExistsAsync("ApartmentAddGasReport"))        { await roleManager.CreateAsync(new IdentityRole("ApartmentAddGasReport")); }
                if (!await roleManager.RoleExistsAsync("ApartmentDelete"))              { await roleManager.CreateAsync(new IdentityRole("ApartmentDelete")); }
                if (!await roleManager.RoleExistsAsync("ApartmentDeleteGasReport"))     { await roleManager.CreateAsync(new IdentityRole("ApartmentDeleteGasReport")); }
                if (!await roleManager.RoleExistsAsync("ApartmentDetails"))             { await roleManager.CreateAsync(new IdentityRole("ApartmentDetails")); }
                if (!await roleManager.RoleExistsAsync("ApartmentDetailsGasReport"))    { await roleManager.CreateAsync(new IdentityRole("ApartmentDetailsGasReport")); }
                if (!await roleManager.RoleExistsAsync("ApartmentEdit"))                { await roleManager.CreateAsync(new IdentityRole("ApartmentEdit")); }
                if (!await roleManager.RoleExistsAsync("ApartmentEditGasReport"))       { await roleManager.CreateAsync(new IdentityRole("ApartmentEditGasReport")); }
                
                if (!await roleManager.RoleExistsAsync("BuildingAdd"))                  { await roleManager.CreateAsync(new IdentityRole("BuildingAdd")); }
                if (!await roleManager.RoleExistsAsync("BuildingAddElectricalReport"))  { await roleManager.CreateAsync(new IdentityRole("BuildingAddElectricalReport")); }
                if (!await roleManager.RoleExistsAsync("BuildingAddGasReport"))         { await roleManager.CreateAsync(new IdentityRole("BuildingAddGasReport")); }
                if (!await roleManager.RoleExistsAsync("BuildingDelete"))               { await roleManager.CreateAsync(new IdentityRole("BuildingDelete")); }
                if (!await roleManager.RoleExistsAsync("BuildingDetails"))              { await roleManager.CreateAsync(new IdentityRole("BuildingDetails")); }
                if (!await roleManager.RoleExistsAsync("BuildingEdit"))                 { await roleManager.CreateAsync(new IdentityRole("BuildingEdit")); }
                if (!await roleManager.RoleExistsAsync("BuildingList"))                 { await roleManager.CreateAsync(new IdentityRole("BuildingList")); }
                
                if (!await roleManager.RoleExistsAsync("BuildingManagerAdd"))           { await roleManager.CreateAsync(new IdentityRole("BuildingManagerAdd")); }
                if (!await roleManager.RoleExistsAsync("BuildingManagerDelete"))        { await roleManager.CreateAsync(new IdentityRole("BuildingManagerDelete")); }
                if (!await roleManager.RoleExistsAsync("BuildingManagerDetails"))       { await roleManager.CreateAsync(new IdentityRole("BuildingManagerDetails")); }
                if (!await roleManager.RoleExistsAsync("BuildingManagerEdit"))          { await roleManager.CreateAsync(new IdentityRole("BuildingManagerEdit")); }
                if (!await roleManager.RoleExistsAsync("BuildingManagerList"))          { await roleManager.CreateAsync(new IdentityRole("BuildingManagerList")); }
                
                if (!await roleManager.RoleExistsAsync("CertificateAddElectrical"))     { await roleManager.CreateAsync(new IdentityRole("CertificateAddElectrical")); }
                if (!await roleManager.RoleExistsAsync("CertificateAddGas"))            { await roleManager.CreateAsync(new IdentityRole("CertificateAddGas")); }
                if (!await roleManager.RoleExistsAsync("CertificateDeleteElectrical"))  { await roleManager.CreateAsync(new IdentityRole("CertificateDeleteElectrical")); }
                if (!await roleManager.RoleExistsAsync("CertificateDeleteGas"))         { await roleManager.CreateAsync(new IdentityRole("CertificateDeleteGas")); }
                if (!await roleManager.RoleExistsAsync("CertificateEditElectrical"))    { await roleManager.CreateAsync(new IdentityRole("CertificateEditElectrical")); }
                if (!await roleManager.RoleExistsAsync("CertificateEditGas"))           { await roleManager.CreateAsync(new IdentityRole("CertificateEditGas")); }
                
                if (!await roleManager.RoleExistsAsync("DeviceAddElectrical"))          { await roleManager.CreateAsync(new IdentityRole("DeviceAddElectrical")); }
                if (!await roleManager.RoleExistsAsync("DeviceAddGas"))                 { await roleManager.CreateAsync(new IdentityRole("DeviceAddGas")); }
                if (!await roleManager.RoleExistsAsync("DeviceDeleteElectrical"))       { await roleManager.CreateAsync(new IdentityRole("DeviceDeleteGas")); }
                if (!await roleManager.RoleExistsAsync("DeviceDeleteGas"))              { await roleManager.CreateAsync(new IdentityRole("DeviceDeleteGas")); }
                if (!await roleManager.RoleExistsAsync("DeviceEditElectrical"))         { await roleManager.CreateAsync(new IdentityRole("DeviceEditElectrical")); }
                if (!await roleManager.RoleExistsAsync("DeviceEditGas"))                { await roleManager.CreateAsync(new IdentityRole("DeviceEditGas")); }
                if (!await roleManager.RoleExistsAsync("DeviceList"))                   { await roleManager.CreateAsync(new IdentityRole("DeviceList")); }
                
                if (!await roleManager.RoleExistsAsync("UserAddToRole"))                { await roleManager.CreateAsync(new IdentityRole("UserAddToRole")); }
                if (!await roleManager.RoleExistsAsync("UserDetails"))                  { await roleManager.CreateAsync(new IdentityRole("UserDetails")); }
                if (!await roleManager.RoleExistsAsync("UserEdit"))                     { await roleManager.CreateAsync(new IdentityRole("UserEdit")); }
                if (!await roleManager.RoleExistsAsync("UserEditData"))                 { await roleManager.CreateAsync(new IdentityRole("UserEditData")); }
                if (!await roleManager.RoleExistsAsync("UserEditPassword"))             { await roleManager.CreateAsync(new IdentityRole("UserEditPassword")); }
                if (!await roleManager.RoleExistsAsync("UserList"))                     { await roleManager.CreateAsync(new IdentityRole("UserList")); }
                if (!await roleManager.RoleExistsAsync("UserLock"))                     { await roleManager.CreateAsync(new IdentityRole("UserLock")); }
                if (!await roleManager.RoleExistsAsync("UserUnlock"))                   { await roleManager.CreateAsync(new IdentityRole("UserUnlock")); }
                if (!await roleManager.RoleExistsAsync("UserProfile"))                  { await roleManager.CreateAsync(new IdentityRole("UserProfile")); }
                if (!await roleManager.RoleExistsAsync("UserRemoveFromRole"))           { await roleManager.CreateAsync(new IdentityRole("UserRemoveFromRole")); }

                if(await userManager.FindByNameAsync("admin") == null)
                {
                    var userAdmin = new User()
                    {
                        Email = "admin@admin.com",
                        FirstName = "admin",
                        LastName = "admin",
                        UserName = "admin"
                    };

                    var resultAdmin = await userManager.CreateAsync(userAdmin, "!Admin123");

                    if(resultAdmin.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ActiveUser");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "Admin");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "AccountRegister");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentAdd");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentAddElectricalReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentAddGasReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentDelete");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentDeleteGasReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentDetails");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentDetailsGasReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentEdit");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "ApartmentEditGasReport");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingAdd");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingAddElectricalReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingAddGasReport");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingDelete");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingDetails");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingEdit");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingList");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingManagerAdd");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingManagerDelete");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingManagerDetails");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingManagerEdit");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "BuildingManagerList");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateAddElectrical");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateAddGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateDeleteElectrical");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateDeleteGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateEditElectrical");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "CertificateEditGas");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceAddElectrical");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceAddGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceDeleteGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceDeleteGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceEditElectrical");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceEditGas");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "DeviceList");

                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserAddToRole");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserDetails");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserEdit");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserEditData");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserEditPassword");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserList");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserLock");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserUnlock");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserProfile");
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("admin"), "UserRemoveFromRole");
                    }
                }

                if (await userManager.FindByNameAsync("user") == null)
                {
                    var userAdmin = new User()
                    {
                        Email = "user@user.com",
                        FirstName = "user",
                        LastName = "user",
                        UserName = "user"
                    };

                    var resultAdmin = await userManager.CreateAsync(userAdmin, "!User123");

                    if (resultAdmin.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync("user"), "ActiveUser");
                    }
                }

                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    var login = await signInManager.PasswordSignInAsync(registerViewModel.UserName, registerViewModel.Password, true, false);

                    if (login.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByNameAsync(registerViewModel.UserName), "ActiveUser");

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
            if(signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Index", "Dashboard");
            }

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