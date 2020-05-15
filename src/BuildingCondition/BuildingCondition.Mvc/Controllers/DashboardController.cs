using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCondition.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "ActiveUser")]
        public IActionResult Index()
        {
            return View();
        }
    }
}