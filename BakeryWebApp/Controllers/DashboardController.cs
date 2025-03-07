using Microsoft.AspNetCore.Mvc;

namespace BakeryWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(string activeCategory = "all")
        {
            return View();
        }
    }
}
