﻿using BakeryWebApp.Models;
using BakeryWebApp.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;

namespace BakeryWebApp.Controllers
{
    public class DatabaseController : Controller
    {
        public DatabaseController(BakeryContext context)
        {
            _context = context;
        }

        public BakeryContext _context;

        [HttpPost]
        public IActionResult ProductList(int id)
        {
            return View();
        }

        /// <summary>
        /// Populates the Dropdown list for Groups that include a GroupName containing GroupName + CategoryName
        /// </summary>
        /// <param name="selectedGroup"></param>
        private void PopulateGroupsDropDownList(object selectedGroup = null)
        {
            var groupsQuery = from g in _context.Groups
                              join c in _context.Categories on g.CategoryId equals c.CategoryId into groupCat
                              from gc in groupCat.DefaultIfEmpty() // Optional if you want to include groups with no members
                              orderby g.GroupName
                              select new
                              {
                                  g.GroupId,
                                  GroupName = g.GroupName + " " + (gc != null ? gc.CategoryName : "") // Include related data here
                              };
            ViewBag.GroupId = new SelectList(groupsQuery.AsNoTracking(), "GroupId", "GroupName", selectedGroup);
        }

        /// <summary>
        /// Populates the Select list of Groups from given Category ID
        /// </summary>
        /// <param name="selectedGroup"></param>
        private void PopulateGroupsSelectList(int categoryID, object selectedGroup = null)
        {
            var groupsQuery = from g in _context.Groups
                              where g.CategoryId == categoryID
                              select new
                              {
                                  g.GroupId,
                                  g.GroupName
                              };
            ViewBag.GroupId = new SelectList(groupsQuery.AsNoTracking(), "GroupId", "GroupName", selectedGroup);
        }

        [Route("db")]
        public IActionResult Index()
        {
            return View();
        }


        //
        // PRODUCTS
        //

        [HttpGet]
        [Route("db/products")]
        public IActionResult ProductList()
        {
            DatabaseViewModel viewModel = new()
            {
                Products = _context.Products
                .Include(p => p.ProductGroup)
                    .ThenInclude(p => p.GroupCategory)
                .AsNoTracking()
                .OrderBy(p => p.ProductName)
                .ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        [Route("db/products/edit/{slug}")]
        public IActionResult ProductEdit(int? id, string slug)
        {
            Product? product = _context.Products.Find(id);
            if (product == null) return NotFound();

            PopulateGroupsDropDownList(product.GroupId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("db/products/edit/{slug?}/{product?}")]
        public IActionResult ProductEdit(Product product, string? slug)
        {
            if (!ModelState.IsValid)
            {
                PopulateGroupsDropDownList(product.GroupId);
                return View(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }


        [HttpGet]
        [Route("db/products/add")]
        public IActionResult ProductAdd()
        {
            PopulateGroupsDropDownList();
            return View(new Product());
        }

        [HttpPost]
        [Route("db/products/add/{product?}")]
        [ValidateAntiForgeryToken]
        public IActionResult ProductAdd(Product product)
        {
            if (!ModelState.IsValid)
            {
                PopulateGroupsDropDownList(product.GroupId);
                return View(product);
            }

            product.ProductGroup = _context.Groups.Find(product.GroupId);

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }

        [HttpGet]
        [Route("db/products/delete/{slug}")]
        public IActionResult ProductDelete(int id, string slug)
        {
            Product? product = _context.Products.Find(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [Route("db/products/delete/{slug?}/{product?}")]
        [ValidateAntiForgeryToken]
        public IActionResult ProductDelete(Product product, string? slug)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }



        //
        // CATEGORIES
        //

        [HttpGet]
        [Route("db/categories")]
        public IActionResult CategoryList()
        {
            DatabaseViewModel viewModel = new()
            {
                Categories = _context.Categories
                .Include(c => c.Groups)
                    .ThenInclude(c => c.Products)
                .AsNoTracking()
                .OrderBy(c => c.CategoryName)
                .ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        [Route("db/categories/edit/{slug}")]
        public IActionResult CategoryEdit(int? id, string slug)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            ViewBag.Groups = _context.Groups
                                .Where(g => g.CategoryId == category.CategoryId)
                                .OrderBy(g => g.GroupName).ToList();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("db/categories/edit/{slug?}/{product?}")]
        public IActionResult CategoryEdit(Category category, string? slug)
        {
            if (!ModelState.IsValid)
            {
                PopulateGroupsSelectList(category.CategoryId);
                return View(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("CategoryList");
        }
    }
}
