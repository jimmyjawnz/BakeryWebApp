using System.Diagnostics;
using System.Reflection;
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
        }

        public IActionResult Index()
        {
            Employee? currentEmployee = (Employee)TempData.Peek("CurrentEmployee");
            if (currentEmployee != null)
            {
                PropertyInfo prop = currentEmployee.GetType().GetProperty("Id", BindingFlags.Instance | BindingFlags.Public);
                if (prop != null)
                {
                    var model = new HomeViewModel()
                    {
                        CurrentEmployee = (Employee)TempData["CurrentEmployee"],
                    };
                    TempData.Keep();
                    return View(model);
                }
            }
            TempData.Keep();
            return RedirectToAction("Login", "Home");
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
