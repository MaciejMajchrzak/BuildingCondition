using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Mvc;

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