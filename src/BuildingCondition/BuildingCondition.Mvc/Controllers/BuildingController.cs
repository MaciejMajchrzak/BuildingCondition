using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.BuildingManagerViewModels;
using BuildingCondition.Mvc.Models.ViewModels.BuildingViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Controllers
{
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
        [HttpGet]
        public IActionResult Add(int id)
        {
            BuildingAddViewModel buildingAddViewModel = new BuildingAddViewModel()
            {
                BuildingManagerId = id
            };

            return View(buildingAddViewModel);
        }

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

                ICollection<Building> buildings = buildingService.GetAllByBuildingManagerId(buildingAddViewModel.BuildingManagerId);

                BuildingManagerDetailsViewModel buildingManagerDetailsViewModel = new BuildingManagerDetailsViewModel()
                {
                    Id = buildingManager.Id,
                    Name = buildingManager.Name,
                    Buildings = buildings
                };

                return RedirectToAction("Details", "BuildingManager", buildingManagerDetailsViewModel);
            }

            return RedirectToAction("Add", "Building", buildingAddViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int buildingManagerId, int buildingId)
        {
            buildingService.Delete(buildingId);

            BuildingManager buildingManager = buildingManagerService.Get(buildingManagerId);

            ICollection<Building> buildings = buildingService.GetAllByBuildingManagerId(buildingManagerId);

            BuildingManagerDetailsViewModel buildingManagerDetailsViewModel = new BuildingManagerDetailsViewModel()
            {
                Id = buildingManager.Id,
                Name = buildingManager.Name,
                Buildings = buildings
            };

            return RedirectToAction("Details", "BuildingManager", buildingManagerDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            Building building = buildingService.Get(id);

            BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

            ICollection<Apartment> apartments = apartmentService.GetAllByBuildingId(id);

            BuildingDetailsViewModel buildingDetailsViewModel = new BuildingDetailsViewModel()
            {
                Country = building.Country,
                State = building.Street,
                City = building.City,
                Street = building.Street,
                BuildingNumber = building.BuildingNumber,
                BuildingManager = buildingManager,
                Apartments = apartments
            };

            return View(buildingDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Building building = buildingService.Get(id);

            BuildingEditViewModel buildingEditViewModel = new BuildingEditViewModel()
            {
                Id = building.Id,
                Country = building.Country,
                State = building.State,
                City = building.City,
                Street = building.Street,
                BuildingNumber = building.BuildingNumber,
                BuildingManagerId = building.BuildingManagerId
            };

            return View(buildingEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BuildingEditViewModel buildingEditViewModel)
        {
            if(ModelState.IsValid)
            {
                Building building = new Building()
                {
                    Id = buildingEditViewModel.Id,
                    Country = buildingEditViewModel.Country,
                    State = buildingEditViewModel.State,
                    City = buildingEditViewModel.City,
                    Street = buildingEditViewModel.Street,
                    BuildingNumber = buildingEditViewModel.BuildingNumber,
                    BuildingManagerId = buildingEditViewModel.BuildingManagerId
                };

                buildingService.Update(building);

                BuildingManager buildingManager = buildingManagerService.Get(buildingEditViewModel.BuildingManagerId);

                ICollection<Building> buildings = buildingService.GetAllByBuildingManagerId(buildingEditViewModel.BuildingManagerId);

                BuildingManagerDetailsViewModel buildingManagerDetailsViewModel = new BuildingManagerDetailsViewModel()
                {
                    Id = buildingManager.Id,
                    Name = buildingManager.Name,
                    Buildings = buildings
                };

                return RedirectToAction("Details", "BuildingManager", buildingManagerDetailsViewModel);
            }

            return View(buildingEditViewModel);
        }

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