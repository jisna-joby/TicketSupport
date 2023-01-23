using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketSupport.Data;
using TicketSupport.Models;

namespace TicketSupport.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Ticket obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Ticket created successfully";
                //return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}