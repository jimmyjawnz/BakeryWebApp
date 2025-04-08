using BakeryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeryWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Products", "Database", new { viewModel });
            }



            return RedirectToAction("Products", "Database", new { viewModel });
        }
    }
}
