using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
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

        [Authorize(Roles = "BuildingManagerAdd")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "BuildingManagerAdd")]
        [HttpPost]
        public IActionResult Add(BuildingManager buildingManager)
        {
            if (ModelState.IsValid)
            {

                buildingManagerService.Create(buildingManager);

                return RedirectToAction("List");
            }

            return View(buildingManager);
        }

        [Authorize(Roles = "BuildingManagerDelete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            buildingManagerService.Delete(id);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "BuildingManagerDetails")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            BuildingManager buildingManager = buildingManagerService.Get(id);

            buildingManager.Buildings = buildingService.GetAllByBuildingManagerId(id);

            return View(buildingManager);
        }

        [Authorize(Roles = "BuildingManagerEdit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(buildingManagerService.Get(id));
        }

        [Authorize(Roles = "BuildingManagerEdit")]
        [HttpPost]
        public IActionResult Edit(BuildingManager buildingManager)
        {
            if(ModelState.IsValid)
            {
                buildingManagerService.Update(buildingManager);

                return RedirectToAction("List");
            }

            return View(buildingManager);
        }

        [Authorize(Roles = "BuildingManagerList")]
        [HttpGet]
        public IActionResult List()
        {
            return View(buildingManagerService.GetAll());
        }
    }
}