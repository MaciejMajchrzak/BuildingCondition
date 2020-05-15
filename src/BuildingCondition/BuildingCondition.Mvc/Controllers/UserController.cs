using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
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

        [Authorize(Roles = "UserAddToRole")]
        [HttpGet]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            if(roleName == "Admin")
            {
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "Admin"))                        { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "Admin"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "AccountRegister"))              { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "AccountRegister"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAdd"))                 { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAdd"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddElectricalReport")) { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddElectricalReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddGasReport"))        { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddGasReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDelete"))              { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDelete"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDeleteGasReport"))     { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDeleteGasReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetails"))             { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetails"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetailsGasReport"))    { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetailsGasReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEdit"))                { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEdit"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEditGasReport"))       { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEditGasReport"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAdd"))                  { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAdd"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddElectricalReport"))  { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddElectricalReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddGasReport"))         { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddGasReport"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDelete"))               { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDelete"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDetails"))              { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDetails"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingEdit"))                 { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingEdit"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingList"))                 { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingList"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerAdd"))           { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerAdd"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDelete"))        { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDelete"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDetails"))       { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDetails"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerEdit"))          { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerEdit"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerList"))          { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerList"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddElectrical"))     { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddElectrical"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddGas"))            { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteElectrical"))  { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteElectrical"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteGas"))         { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditElectrical"))    { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditElectrical"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditGas"))           { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditGas"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddElectrical"))          { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddElectrical"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddGas"))                 { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteElectrical"))       { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"))              { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditElectrical"))         { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditElectrical"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditGas"))                { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditGas"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceList"))                   { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "DeviceList"); }
                
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserAddToRole"))                { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserAddToRole"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserDetails"))                  { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserDetails"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEdit"))                     { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserEdit"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEditData"))                 { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserEditData"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEditPassword"))             { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserEditPassword"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserList"))                     { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserList"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserLock"))                     { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserLock"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserUnlock"))                   { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserUnlock"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserProfile"))                  { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserProfile"); }
                if (!await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserRemoveFromRole"))           { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), "UserRemoveFromRole"); }
            }
            else
            {
                await userManager.AddToRoleAsync(await userManager.FindByIdAsync(userId), roleName);
            }

            return RedirectToAction("List");
        }

        [Authorize(Roles = "UserDetails")]
        public IActionResult Details(string id)
        {
            User user = userService.Get(id);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return View(user);
        }

        [Authorize(Roles = "UserEdit")]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            User user = userService.Get(id);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return View(user);
        }

        [Authorize(Roles = "UserEditData")]
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

        [Authorize(Roles = "UserEditPassword")]
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

        [Authorize(Roles = "UserList")]
        [HttpGet]
        public IActionResult List()
        {
            return View(userService.GetAll());
        }

        [Authorize(Roles = "UserLock")]
        [HttpGet]
        public async Task<IActionResult> Lock(string id)
        {
            await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("List");
        }

        [Authorize(Roles = "UserUnlock")]
        [HttpGet]
        public async Task<IActionResult> Unlock(string id)
        {
            await userManager.AddToRoleAsync(await userManager.FindByIdAsync(id), "ActiveUser");

            return RedirectToAction("List");
        }

        [Authorize(Roles = "UserProfile")]
        [HttpGet]
        public IActionResult Profile()
        {
            return View(userService.Get(userManager.GetUserId(HttpContext.User)));
        }

        [Authorize(Roles = "UserRemoveFromRole")]
        [HttpGet]
        public async Task<IActionResult> RemoveFromRole(string userId, string roleName)
        {
            if(roleName == "Admin")
            {
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "Admin"))                        { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "Admin"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "AccountRegister"))              { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "AccountRegister"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAdd"))                 { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAdd"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddElectricalReport")) { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddElectricalReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddGasReport"))        { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentAddGasReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDelete"))              { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDelete"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDeleteGasReport"))     { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDeleteGasReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetails"))             { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetails"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetailsGasReport"))    { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentDetailsGasReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEdit"))                { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEdit"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEditGasReport"))       { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "ApartmentEditGasReport"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAdd"))                  { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAdd"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddElectricalReport"))  { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddElectricalReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddGasReport"))         { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingAddGasReport"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDelete"))               { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDelete"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDetails"))              { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingDetails"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingEdit"))                 { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingEdit"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingList"))                 { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingList"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerAdd"))           { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerAdd"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDelete"))        { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDelete"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDetails"))       { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerDetails"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerEdit"))          { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerEdit"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerList"))          { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "BuildingManagerList"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddElectrical"))     { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddElectrical"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddGas"))            { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateAddGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteElectrical"))  { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteElectrical"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteGas"))         { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateDeleteGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditElectrical"))    { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditElectrical"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditGas"))           { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "CertificateEditGas"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddElectrical"))          { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddElectrical"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddGas"))                 { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceAddGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteElectrical"))       { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"))              { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceDeleteGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditElectrical"))         { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditElectrical"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditGas"))                { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceEditGas"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "DeviceList"))                   { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "DeviceList"); }
                
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserAddToRole"))                { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserAddToRole"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserDetails"))                  { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserDetails"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEdit"))                     { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserEdit"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEditData"))                 { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserEditData"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserEditPassword"))             { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserEditPassword"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserList"))                     { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserList"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserLock"))                     { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserLock"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserUnlock"))                   { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserUnlock"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserProfile"))                  { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserProfile"); }
                if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(userId), "UserRemoveFromRole"))           { await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), "UserRemoveFromRole"); }
            }
            else
            {
                await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(userId), roleName);
            }

            return RedirectToAction("List");
        }
    }
}