using BakeryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeryWebApp.Controllers
{
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("db/products")]
        public IActionResult ProductList()
        {
            DatabaseViewModel viewModel = new() { 
                Products =
                [
                    new Product() { 
                        ProductId = 1,
                        ProductName = "White Bread",
                        ProductPrice = 10.0d,
                        ProductDescription = "Loaf of white bread.",
                        GroupId = 1,
                        IsAvailable = true
                    },
                    new Product() {
                        ProductId = 2,
                        ProductName = "Cheese Buns",
                        ProductPrice = 14.0d,
                        ProductDescription = "4 pack of buns.",
                        GroupId = 2,
                        IsAvailable = true
                    },
                    new Product() {
                        ProductId = 3,
                        ProductName = "Slime",
                        ProductPrice = 99999.99d,
                        ProductDescription = "Ew gross.",
                        GroupId = 9,
                        IsAvailable = false
                    }
                ]
            };
            return View(viewModel);
        }

        [HttpGet]
        [Route("db/products/edit/{slug}")]
        public IActionResult ProductEdit(string slug, int id)
        {
            ViewBag.Groups = new List<Group> { new Group() { CategoryId = 1, GroupId = 1, GroupName = "Bread" } };
            return View(new Product()
            {
                ProductId = 1,
                ProductName = "White Bread",
                ProductPrice = 10.0d,
                ProductDescription = "Loaf of white bread.",
                GroupId = 1,
                IsAvailable = false
            });
        }

        [HttpPost]
        public IActionResult ProductEdit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }


            return View("ProductList");
        }

        [HttpGet]
        [Route("db/products/add")]
        public IActionResult ProductAdd()
        {
            ViewBag.Groups = new List<Group> { new Group() { CategoryId = 1, GroupId = 1, GroupName = "Bread" } };
            return View();
        }
    }
}
