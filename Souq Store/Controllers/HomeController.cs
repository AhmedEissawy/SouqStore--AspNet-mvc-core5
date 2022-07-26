using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Souq_Store.Data;
using Souq_Store.Models;
using Souq_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Souq_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cats = _context.Categories.ToList();

            var latestProducts = _context.Products.OrderByDescending(p=>p.EntryDate).Take(4).ToList();

            var reviews = _context.Reviews.ToList();

            IndexViewModel result = new IndexViewModel()
            {
                 Categories = cats,

                 LatestProducts = latestProducts,

                 reviews = reviews
            };

            return View(result);
        }

        public IActionResult Categories()
        {
            var cats = _context.Categories.ToList();

            ViewBag.isAdmin = true;

            return View(cats);
        }

        [HttpPost]
        public IActionResult CategorySearch(string term)
        {
            var categories = _context.Categories.Where(c => c.Name.Contains(term) || c.Description.Contains(term)).ToList();

            return View(categories);
        }

        public IActionResult ProductsByCategoryId(int id)
        {
            var category = _context.Categories.Find(id);

            TempData["CategoryId"] = id;

            ViewBag.category = category.Name;

            var products = _context.Products.Where(p => p.CategoryId == id).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult SearchAllProducts()
        {
            
              var  products = _context.Products.ToList();
            
            return View(products);
        }

        [HttpPost]
        public IActionResult SearchAllProducts(string term)
        {
           
            var result = _context.Products.Where(c => c.Name.Contains(term) || c.Description.Contains(term)).ToList();

            return View(result);
        }

       
        public IActionResult CurrentProduct(int id)
        {

            var currentProduct = _context.Products.Include(p=>p.Category).Include(p=>p.ProductImages).SingleOrDefault(p=>p.Id==id);

            return View(currentProduct);
        }

       
       

        [HttpPost]
        public IActionResult ProductSearchWithRelatedCategory(string term)
        {
            var categoryId = Convert.ToInt32(TempData["CategoryId"]);

            var relatedProducts = _context.Products.Where(p => p.CategoryId == categoryId).ToList();

            var searchedProducts = relatedProducts.Where(p => p.Name.Contains(term) || p.Description.Contains(term)).ToList();

            return View(searchedProducts);

        }

        [HttpPost]
        public IActionResult ReviewMessages(ReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Review review = new Review()
                {
                    Email = viewModel.Email,
                    Message = viewModel.Message,
                    Name = viewModel.Name,
                    Subject = viewModel.Subject
                };

                _context.Reviews.Add(review);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
