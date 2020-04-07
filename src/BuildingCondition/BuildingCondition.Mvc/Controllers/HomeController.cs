using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard", null);
        }
    }
}