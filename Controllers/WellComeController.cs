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

        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _context.users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (result != null)
            {
                return RedirectToAction("Get", "Product");
            }
            else {
                
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword model)
        {
            var user = _context.users.FirstOrDefault(u => u.Username == model.Username);


            if (user != null&& user.Password == model.CurrentPassword)
            {
                ModelState.AddModelError("", "User not found.");
                user.Password = model.ConfirmPassword;
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Password or username is invalid");
            }
            return RedirectToAction("Login");
        }
    }
}
