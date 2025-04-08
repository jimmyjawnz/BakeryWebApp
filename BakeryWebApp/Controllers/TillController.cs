using BakeryWebApp.Models;
using BakeryWebApp.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BakeryWebApp.Controllers
{
    public class TillController : Controller
    {
        private BakeryContext _dbContext { get; set; }

        public TillController(BakeryContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("/front-till")]
        public async Task<IActionResult> FrontTill(FrontTillViewModel viewModel)
        {
            // If null make new
            viewModel ??= new();

            // If there are no current loaded products collect them
            if (viewModel.AvailableProducts.IsNullOrEmpty())
            {
                viewModel.AvailableProducts = await _dbContext.Products
                    .Where(p => p.IsAvailable == true)
                    .OrderBy(p => p.ProductName)
                    .ToListAsync();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(FrontTillViewModel viewModel)
        {
            // Create customer object out of View Model values
            Customer newCustomer = new()
            {
                CustomerName = viewModel.CustomerName,
                CustomerPhoneNumber = viewModel.CustomerPhoneNumber
            };

            // Reset View Model values
            viewModel.CustomerPhoneNumber = string.Empty;
            viewModel.CustomerName = string.Empty;

            // Add and Save Customer to Database
            await _dbContext.Customers.AddAsync(newCustomer);
            await _dbContext.SaveChangesAsync();

            // Return Front Till with View Model
            return RedirectToAction("FrontTill", "Till", new { viewModel });
        }
    }
}
