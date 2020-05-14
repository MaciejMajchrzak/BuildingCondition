using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BuildingCondition.Mvc.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IApartmentElectricalInstalationReportService apartmentElectricalInstalationReportService;
        private readonly IApartmentGasInstalationReportService apartmentGasInstalationReportService;
        private readonly IApartmentService apartmentService;
        private readonly IBuildingManagerService buildingManagerService;
        private readonly IBuildingService buildingService;

        public ApartmentController(UserManager<IdentityUser> _userManager,
            IApartmentElectricalInstalationReportService _apartmentElectricalInstalationReportService,
            IApartmentGasInstalationReportService _apartmentGasInstalationReportService,
            IApartmentService _apartmentService,
            IBuildingManagerService _buildingManagerService,
            IBuildingService _buildingService)
        {
            userManager = _userManager;
            apartmentElectricalInstalationReportService = _apartmentElectricalInstalationReportService;
            apartmentGasInstalationReportService = _apartmentGasInstalationReportService;
            apartmentService = _apartmentService;
            buildingManagerService = _buildingManagerService;
            buildingService = _buildingService;
        }

        /// <param name="id">Building.Id</param>
        [HttpGet]
        public IActionResult Add(int id)
        {
            Apartment apartment = new Apartment()
            {
                BuildingId = id
            };

            return View(apartment);
        }

        [HttpPost]
        public IActionResult Add(Apartment apartment)
        {
            if(ModelState.IsValid)
            {
                apartmentService.Create(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

                building.Apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                return RedirectToAction("Details", "Building", building);
            }

            return View(apartment);
        }

        [HttpGet]
        public IActionResult AddGasReport(int id)
        {
            ApartmentGasInstalationReport apartmentGasInstalationReport = new ApartmentGasInstalationReport()
            {
                Id = id,
                UserId = userManager.GetUserId(HttpContext.User),
                DateOfInspection = DateTime.UtcNow,
                DateOfNextInspection = DateTime.UtcNow.AddYears(1)
            };

            return View(apartmentGasInstalationReport);
        }

        [HttpPost]
        public IActionResult AddGasReport(ApartmentGasInstalationReport apartmentGasInstalationReport)
        {
            apartmentGasInstalationReportService.Create(apartmentGasInstalationReport);

            Apartment apartment = apartmentService.Get(apartmentGasInstalationReport.ApartmentId);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(apartment.Id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(apartment.Id);

            return RedirectToAction("Details", "Apartment", apartment);
        }

        [HttpGet]
        public IActionResult Delete(int buildingId, int apartmentId)
        {
            apartmentService.Delete(apartmentId);

            Building building = buildingService.Get(buildingId);

            building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

            building.Apartments = apartmentService.GetAllByBuildingId(buildingId);

            return RedirectToAction("Details", "Building", building);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Apartment apartment = apartmentService.Get(id);

            apartment.Building = buildingService.Get(apartment.BuildingId);

            apartment.Building.BuildingManager = buildingManagerService.Get(apartment.Building.BuildingManagerId);

            apartment.ApartmentElectricalInstalationReports = apartmentElectricalInstalationReportService.GetAllByApartmentId(id);

            apartment.ApartmentGasInstalationReports = apartmentGasInstalationReportService.GetAllByApartmentId(id);

            return View(apartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(apartmentService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Apartment apartment)
        {
            if(ModelState.IsValid)
            {
                apartmentService.Update(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

                building.Apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                return RedirectToAction("Details", "Building", building);
            }

            return View(apartment);
        }
    }
}