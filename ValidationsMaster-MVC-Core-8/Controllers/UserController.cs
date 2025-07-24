using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationsMaster_MVC_Core_8.Data;
using ValidationsMaster_MVC_Core_8.Models;
using System.Linq;

namespace ValidationsMaster_MVC_Core_8.Controllers
{
    public class UserController : Controller
    {
        private readonly ProductDbContext _context;

        public UserController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // GET: User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["Success"] = $"Welcome, {user.Name}! 🎉 Your registration was successful.";
                return RedirectToAction("Success");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

    }
}
