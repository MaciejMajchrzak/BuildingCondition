using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}