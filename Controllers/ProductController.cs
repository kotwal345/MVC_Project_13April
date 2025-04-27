using Microsoft.AspNetCore.Mvc;
using MVC_Project_13_April.Data;
using MVC_Project_13_April.Models;

namespace MVC_Project_13_April.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult Get(Product product)
        {
            var prodList = _context.products.ToList();
            
            return View(prodList);
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            var Products = _context.products.FirstOrDefault(p => p.Id == id);

            return View(Products);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Products = _context.products.FirstOrDefault(p => p.Id == id);

            _context.products.Remove(Products);
            _context.SaveChanges();

            return RedirectToAction("Get");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var Products = _context.products.FirstOrDefault(p => p.Id == id);

            return View(Products);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            var producUpdate = _context.products.FirstOrDefault(p => p.Id == product.Id);

            producUpdate.Name = product.Name;
            producUpdate.Description = product.Description;
            product.Category = product.Category;

            _context.SaveChanges();

            return RedirectToAction("Get");




        }
    }
}
