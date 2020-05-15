using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
    public class CertificateController : Controller
    {
        private readonly IElectricalQualificationCertificateService electricalQualificationCertificateService;
        private readonly IGasQualificationCertificateService gasQualificationCertificateService;
        private readonly IUserService userService;

        public CertificateController(IElectricalQualificationCertificateService _electricalQualificationCertificateService,
            IGasQualificationCertificateService _gasQualificationCertificateService,
            IUserService _userService)
        {
            electricalQualificationCertificateService = _electricalQualificationCertificateService;
            gasQualificationCertificateService = _gasQualificationCertificateService;
            userService = _userService;
        }

        /// <param name="id">User.Id</param>
        [Authorize(Roles = "CertificateAddElectrical")]
        [HttpGet]
        public IActionResult AddElectrical(string id)
        {
            ElectricalQualificationCertificate electricalQualificationCertificate = new ElectricalQualificationCertificate()
            {
                UserId = id,
                ExpirationDate = DateTime.UtcNow,
                ReleaseDate = DateTime.UtcNow.AddYears(5)
            };

            return View(electricalQualificationCertificate);
        }

        [Authorize(Roles = "CertificateAddElectrical")]
        [HttpPost]
        public IActionResult AddElectrical(ElectricalQualificationCertificate electricalQualificationCertificate)
        {
            if(ModelState.IsValid)
            {
                electricalQualificationCertificateService.Create(electricalQualificationCertificate);

                User user = userService.Get(electricalQualificationCertificate.UserId);

                user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

                user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

                return RedirectToAction("Edit", "User", user);
            }

            return View(electricalQualificationCertificate);
        }

        /// <param name="id">User.Id</param>
        [Authorize(Roles = "CertificateAddGas")]
        [HttpGet]
        public IActionResult AddGas(string id)
        {
            GasQualificationCertificate gasQualificationCertificate = new GasQualificationCertificate()
            {
                UserId = id,
                ExpirationDate = DateTime.UtcNow,
                ReleaseDate = DateTime.UtcNow.AddYears(5)
            };

            return View(gasQualificationCertificate);
        }

        [Authorize(Roles = "CertificateAddGas")]
        [HttpPost]
        public IActionResult AddGas(GasQualificationCertificate gasQualificationCertificate)
        {
            if(ModelState.IsValid)
            {
                gasQualificationCertificateService.Create(gasQualificationCertificate);

                User user = userService.Get(gasQualificationCertificate.UserId);

                user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

                user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

                return RedirectToAction("Edit", "User", user);
            }

            return View(gasQualificationCertificate);
        }

        [Authorize(Roles = "CertificateDeleteElectrical")]
        [HttpGet]
        public IActionResult DeleteElectrical(int electricalId, string userId)
        {
            electricalQualificationCertificateService.Delete(electricalId);

            User user = userService.Get(userId);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return RedirectToAction("Edit", "User", user);
        }

        [Authorize(Roles = "CertificateDeleteGas")]
        [HttpGet]
        public IActionResult DeleteGas(int gasId, string userId)
        {
            gasQualificationCertificateService.Delete(gasId);

            User user = userService.Get(userId);

            user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

            user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

            return RedirectToAction("Edit", "User", user);
        }

        [Authorize(Roles = "CertificateEditElectrical")]
        [HttpGet]
        public IActionResult EditElectrical(int id)
        {
            return View(electricalQualificationCertificateService.Get(id));
        }

        [Authorize(Roles = "CertificateEditElectrical")]
        [HttpGet]
        public IActionResult EditGas(int id)
        {
            return View(gasQualificationCertificateService.Get(id));
        }

        [Authorize(Roles = "CertificateEditGas")]
        [HttpPost]
        public IActionResult EditElectrical(ElectricalQualificationCertificate electricalQualificationCertificate)
        {
            if(ModelState.IsValid)
            {
                electricalQualificationCertificateService.Update(electricalQualificationCertificate);

                User user = userService.Get(electricalQualificationCertificate.UserId);

                user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

                user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

                return RedirectToAction("Edit", "User", user);
            }

            return View(electricalQualificationCertificate);
        }

        [Authorize(Roles = "CertificateEditGas")]
        [HttpPost]
        public IActionResult EditGas(GasQualificationCertificate gasQualificationCertificate)
        {
            if(ModelState.IsValid)
            {
                gasQualificationCertificateService.Update(gasQualificationCertificate);

                User user = userService.Get(gasQualificationCertificate.UserId);

                user.ElectricalQualificationCertificates = electricalQualificationCertificateService.GetAllByUserId(user.Id);

                user.GasQualificationCertificates = gasQualificationCertificateService.GetAllByUserId(user.Id);

                return RedirectToAction("Edit", "User", user);
            }

            return View(gasQualificationCertificate);
        }
    }
}