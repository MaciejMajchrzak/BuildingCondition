using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.BuildingViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
    public class BuildingController : Controller
    {
        private readonly IApartmentService apartmentService;
        private readonly IBuildingManagerService buildingManagerService;
        private readonly IBuildingService buildingService;

        public BuildingController(IApartmentService _apartmentService,
            IBuildingManagerService _buildingManagerService,
            IBuildingService _buildingService)
        {
            apartmentService = _apartmentService;
            buildingManagerService = _buildingManagerService;
            buildingService = _buildingService;
        }

        /// <param name="id">BuildingManager.Id</param>
        [Authorize(Roles = "BuildingAdd")]
        [HttpGet]
        public IActionResult Add(int id)
        {
            BuildingAddViewModel buildingAddViewModel = new BuildingAddViewModel()
            {
                BuildingManagerId = id
            };

            return View(buildingAddViewModel);
        }

        [Authorize(Roles = "BuildingAdd")]
        [HttpPost]
        public IActionResult Add(BuildingAddViewModel buildingAddViewModel)
        {
            buildingAddViewModel.Apartments = new List<Apartment>();

            for (int i = 1; i <= buildingAddViewModel.NumberOfApartments; i++)
            {
                for (int j = 1; j <= buildingAddViewModel.NumberOfGates; j++)
                {
                    if (i <= (decimal)buildingAddViewModel.NumberOfApartments / (decimal)buildingAddViewModel.NumberOfGates * j)
                    {
                        buildingAddViewModel.Apartments.Add(new Apartment() { ApartmentNumber = $"{i}", GateNumber = $"{j}" });

                        break;
                    }
                }
            }

            return View(buildingAddViewModel);
        }

        [Authorize(Roles = "BuildingAdd")]
        [HttpPost]
        public IActionResult AddConfirm(BuildingAddViewModel buildingAddViewModel)
        {
            if(ModelState.IsValid)
            {
                Building building = new Building()
                {
                    Country = buildingAddViewModel.Country,
                    State = buildingAddViewModel.Street,
                    City = buildingAddViewModel.City,
                    Street = buildingAddViewModel.Street,
                    BuildingNumber = buildingAddViewModel.BuildingNumber,
                    BuildingManagerId = buildingAddViewModel.BuildingManagerId,
                    Apartments = buildingAddViewModel.Apartments
                };

                buildingService.Create(building);

                BuildingManager buildingManager = buildingManagerService.Get(buildingAddViewModel.BuildingManagerId);

                buildingManager.Buildings = buildingService.GetAllByBuildingManagerId(buildingAddViewModel.BuildingManagerId);

                return RedirectToAction("Details", "BuildingManager", buildingManager);
            }

            return RedirectToAction("Add", "Building", buildingAddViewModel);
        }

        [Authorize(Roles = "BuildingDelete")]
        [HttpGet]
        public IActionResult Delete(int buildingManagerId, int buildingId)
        {
            buildingService.Delete(buildingId);

            BuildingManager buildingManager = buildingManagerService.Get(buildingManagerId);

            buildingManager.Buildings = buildingService.GetAllByBuildingManagerId(buildingManagerId);

            return RedirectToAction("Details", "BuildingManager", buildingManager);
        }

        [Authorize(Roles = "BuildingDetails")]
        [HttpGet]
        public IActionResult Details(int id)
        {

            Building building = buildingService.Get(id);

            building.BuildingManager = buildingManagerService.Get(building.BuildingManagerId);

            building.Apartments = apartmentService.GetAllByBuildingId(id);

            return View(building);
        }

        [Authorize(Roles = "BuildingEdit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(buildingService.Get(id));
        }

        [Authorize(Roles = "BuildingEdit")]
        [HttpPost]
        public IActionResult Edit(Building building)
        {
            if(ModelState.IsValid)
            {
               buildingService.Update(building);

                BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

                buildingManager.Buildings = buildingService.GetAllByBuildingManagerId(building.BuildingManagerId);

                return RedirectToAction("Details", "BuildingManager", buildingManager);
            }

            return View(building);
        }

        [Authorize(Roles = "BuildingList")]
        [HttpGet]
        public IActionResult List()
        {
            ICollection<Building> buildings = buildingService.GetAll();

            BuildingListViewModel buildingListViewModel = new BuildingListViewModel()
            {
                Buildings = buildings
            };
            
            return View(buildingListViewModel);
        }
    }
}