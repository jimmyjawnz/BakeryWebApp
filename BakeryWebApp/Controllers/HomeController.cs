using System.Diagnostics;
using BakeryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            TempData["CurrentEmployee"] = null;
            TempData.Keep();
        }

        public IActionResult Index()
        {
            if (TempData["CurrentEmployee"] is null)
                TempData.Keep();
                return RedirectToAction("Login");

            var model = new HomeViewModel()
            {
                CurrentEmployee = (Employee)TempData["CurrentEmployee"],
            };
            return View(model);
        }

        [Route("[action]/{slug}")]
        public IActionResult Login(string? slug)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
