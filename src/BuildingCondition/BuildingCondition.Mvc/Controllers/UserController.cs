using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingCondition.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IElectricalQualificationCertificateService electricalQualificationCertificateService;
        private readonly IGasQualificationCertificateService gasQualificationCertificateService;
        private readonly IUserService userService;

        public UserController(UserManager<IdentityUser> _userManager,
            IElectricalQualificationCertificateService _electricalQualificationCertificateService,
            IGasQualificationCertificateService _gasQualificationCertificateService,
            IUserService _userService)
        {
            userManager = _userManager;
            electricalQualificationCertificateService = _electricalQualificationCertificateService;
            gasQualificationCertificateService = _gasQualificationCertificateService;
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), roleName);

            return RedirectToAction("List");
        }

        public IActionResult Details(string id)
        {
            User user = userService.Get(id);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            User user = userService.Get(id);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditData(User user)
        {
            if(ModelState.IsValid)
            {
                User oldUser = userService.Get(user.Id);

                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.Email = user.Email;
                oldUser.NormalizedEmail = user.Email.ToUpper();

                userService.Update(user);

                return RedirectToAction("List");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditPassword(User user)
        {
            if (ModelState.IsValid)
            {
                User oldUser = userService.Get(user.Id);

                IdentityUser identityUser = userManager.FindByIdAsync(user.Id).Result;

                var result = userManager.RemovePasswordAsync(identityUser).Result;

                if (result.Succeeded)
                {
                    result = userManager.AddPasswordAsync(identityUser, user.PasswordHash).Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction("List");
                    }

                    return View(user);
                }
                else
                {
                    return View(user);
                }
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(userService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Lock(string id)
        {
            await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Unlock(string id)
        {
            await userManager.AddToRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View(userService.Get(userManager.GetUserId(HttpContext.User)));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleName)
        {
            await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), roleName);

            return RedirectToAction("List");
        }
    }
}