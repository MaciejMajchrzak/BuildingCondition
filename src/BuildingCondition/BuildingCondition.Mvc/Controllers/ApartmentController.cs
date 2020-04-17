using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.ApartmentViewModels;
using BuildingCondition.Mvc.Models.ViewModels.BuildingViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService apartmentService;
        private readonly IBuildingManagerService buildingManagerService;
        private readonly IBuildingService buildingService;

        public ApartmentController(IApartmentService _apartmentService,
            IBuildingManagerService _buildingManagerService,
            IBuildingService _buildingService)
        {
            apartmentService = _apartmentService;
            buildingManagerService = _buildingManagerService;
            buildingService = _buildingService;
        }

        /// <param name="id">Building.Id</param>
        [HttpGet]
        public IActionResult Add(int id)
        {
            Building building = buildingService.Get(id);

            ApartmentAddViewModel apartmentAddViewModel = new ApartmentAddViewModel()
            {
                Building = building
            };

            return View(apartmentAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(ApartmentAddViewModel apartmentAddViewModel)
        {
            if(ModelState.IsValid)
            {
                Apartment apartment = new Apartment()
                {
                    ApartmentNumber = apartmentAddViewModel.ApartmentNumber,
                    GateNumber = apartmentAddViewModel.GateNumber,
                    BuildingId = apartmentAddViewModel.BuildingId
                };

                apartmentService.Create(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

                ICollection<Apartment> apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                BuildingDetailsViewModel buildingDetailsViewModel = new BuildingDetailsViewModel()
                {
                    Id = building.Id,
                    Country = building.Country,
                    State = building.Street,
                    City = building.City,
                    Street = building.Street,
                    BuildingNumber = building.BuildingNumber,
                    BuildingManager = buildingManager,
                    Apartments = apartments
                };

                return RedirectToAction("Details", "Building", buildingDetailsViewModel);
            }

            return View(apartmentAddViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int buildingId, int apartmentId)
        {
            apartmentService.Delete(apartmentId);

            Building building = buildingService.Get(buildingId);

            BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

            ICollection<Apartment> apartments = apartmentService.GetAllByBuildingId(buildingId);

            BuildingDetailsViewModel buildingDetailsViewModel = new BuildingDetailsViewModel()
            {
                Id = building.Id,
                Country = building.Country,
                State = building.Street,
                City = building.City,
                Street = building.Street,
                BuildingNumber = building.BuildingNumber,
                BuildingManager = buildingManager,
                Apartments = apartments
            };

            return RedirectToAction("Details", "Building", buildingDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Apartment apartment = apartmentService.Get(id);

            Building building = buildingService.Get(apartment.BuildingId);

            BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

            building.BuildingManager = buildingManager;

            ApartmentDetailsViewModel apartmentDetailsViewModel = new ApartmentDetailsViewModel()
            {
                Id = apartment.Id,
                ApartmentNumber = apartment.ApartmentNumber,
                GateNumber = apartment.GateNumber,
                Building = building
            };

            return View(apartmentDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Apartment apartment = apartmentService.Get(id);

            ApartmentEditViewModel apartmentEditViewModel = new ApartmentEditViewModel()
            {
                Id = apartment.Id,
                ApartmentNumber = apartment.ApartmentNumber,
                GateNumber = apartment.GateNumber,
                BuildingId = apartment.BuildingId
            };

            return View(apartmentEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ApartmentEditViewModel apartmentEditViewModel)
        {
            if(ModelState.IsValid)
            {
                Apartment apartment = new Apartment()
                {
                    Id = apartmentEditViewModel.Id,
                    ApartmentNumber = apartmentEditViewModel.ApartmentNumber,
                    GateNumber = apartmentEditViewModel.GateNumber,
                    BuildingId = apartmentEditViewModel.BuildingId
                };

                apartmentService.Update(apartment);

                Building building = buildingService.Get(apartment.BuildingId);

                BuildingManager buildingManager = buildingManagerService.Get(building.BuildingManagerId);

                ICollection<Apartment> apartments = apartmentService.GetAllByBuildingId(apartment.BuildingId);

                BuildingDetailsViewModel buildingDetailsViewModel = new BuildingDetailsViewModel()
                {
                    Id = building.Id,
                    Country = building.Country,
                    State = building.Street,
                    City = building.City,
                    Street = building.Street,
                    BuildingNumber = building.BuildingNumber,
                    BuildingManager = buildingManager,
                    Apartments = apartments
                };

                return RedirectToAction("Details", "Building", buildingDetailsViewModel);
            }

            return View(apartmentEditViewModel);
        }
    }
}