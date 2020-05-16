using BuildingCondition.Interfaces;
using BuildingCondition.Mvc.Models.ViewModels.DashboardViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    [Authorize(Roles = "ActiveUser")]
    public class DashboardController : Controller
    {
        private readonly IApartmentService apartmentService;
        private readonly IBuildingService buildingService;
        private readonly IBuildingManagerService buildingManagerService;

        public DashboardController(IApartmentService _apartmentService,
            IBuildingService _buildingService,
            IBuildingManagerService _buildingManagerService)
        {
            apartmentService = _apartmentService;
            buildingService = _buildingService;
            buildingManagerService = _buildingManagerService;
        }

        public IActionResult Index()
        {
            DashboardIndexViewModel dashboardIndexViewModel = new DashboardIndexViewModel()
            {
                BuildingManagersCount = buildingManagerService.GetAll().Count,
                BuildingsCount = buildingService.GetAll().Count,
                ApartmentsCount = apartmentService.GetAll().Count
            };

            return View(dashboardIndexViewModel);
        }
    }
}