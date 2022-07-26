using Microsoft.AspNetCore.Mvc;
using Souq_Store.Data;
using Souq_Store.Models;
using Souq_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            ViewBag.categories = categories;

            return View();
        }

        public IActionResult Charts()
        {
            
            return View();
        }

        public IActionResult GetAllProducts()
        {
            var products = _context.Products.Select(p => new { p.Name, p.Price, p.Qty }).ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                 Category c = new Category();

                c.Name = productViewModel.CatName;

                _context.Products.Add(new Product() {

                    Name = productViewModel.ProductName,
                    Price = productViewModel.ProductPrice,
                    Qty = productViewModel.Productquantity,
                    Category = c }

                );

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
