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
    }
}
