using Microsoft.AspNetCore.Mvc;
using MVC_Project_13_April.Data;
using MVC_Project_13_April.Models;

namespace MVC_Project_13_April.Controllers
{
    public class WellComeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WellComeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) 
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return View();
        }

      
        public IActionResult Login() 
        {
            return View();
        }

    }
}
