using BuildingCondition.Db.Models;
using BuildingCondition.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(BuildingManager buildingManager)
        {
            if (ModelState.IsValid)
            {

                buildingManagerService.Create(buildingManager);

                return RedirectToAction("List");
            }

            return View(buildingManager);
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

            buildingManager.Buildings = buildingService.GetAllByBuildingManagerId(id);

            return View(buildingManager);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(buildingManagerService.Get(id));
        }

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

        [HttpGet]
        public IActionResult List()
        {
            return View(buildingManagerService.GetAll());
        }
    }
}