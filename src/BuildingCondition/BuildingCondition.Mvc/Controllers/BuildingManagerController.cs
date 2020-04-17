using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.BuildingManagerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuildingCondition.Mvc.Controllers
{
    public class BuildingManagerController : Controller
    {
        private readonly IBuildingManagerService buildingManagerService;
        private readonly IBuildingService buildingService;

        public BuildingManagerController(IBuildingManagerService _buildingManagerService,
            IBuildingService _buildingService)
        {
            buildingManagerService = _buildingManagerService;
            buildingService = _buildingService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BuildingManagerAddViewModel buildingManagerAddViewModel)
        {
            if (ModelState.IsValid)
            {
                BuildingManager buildingManager = new BuildingManager()
                {
                    Name = buildingManagerAddViewModel.Name
                };

                buildingManagerService.Create(buildingManager);

                return RedirectToAction("List");
            }

            return View(buildingManagerAddViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            buildingManagerService.Delete(id);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            BuildingManager buildingManager = buildingManagerService.Get(id);

            ICollection<Building> buildings = buildingService.GetAllByBuildingManagerId(id);

            BuildingManagerDetailsViewModel buildingManagerDetailsViewModel = new BuildingManagerDetailsViewModel()
            {
                Id = buildingManager.Id,
                Name = buildingManager.Name,
                Buildings = buildings
            };

            return View(buildingManagerDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BuildingManager buildingManager = buildingManagerService.Get(id);

            BuildingManagerEditViewModel buildingManagerEditViewModel = new BuildingManagerEditViewModel()
            {
                Id = buildingManager.Id,
                Name = buildingManager.Name
            };

            return View(buildingManagerEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BuildingManagerEditViewModel buildingManagerEditViewModel)
        {
            if(ModelState.IsValid)
            {
                BuildingManager buildingManager = new BuildingManager()
                {
                    Id = buildingManagerEditViewModel.Id,
                    Name = buildingManagerEditViewModel.Name
                };

                buildingManagerService.Update(buildingManager);

                return RedirectToAction("List");
            }

            return View(buildingManagerEditViewModel);
        }

        [HttpGet]
        public IActionResult List()
        {
            ICollection<BuildingManagerListViewModel> buildingManagerListViewModels = new List<BuildingManagerListViewModel>();

            ICollection<BuildingManager> buildingManagers = buildingManagerService.GetAll();

            foreach(var buildingManager in buildingManagers)
            {
                buildingManagerListViewModels.Add(new BuildingManagerListViewModel()
                {
                    Id = buildingManager.Id,
                    Name = buildingManager.Name
                });
            }

            return View(buildingManagerListViewModels);
        }
    }
}