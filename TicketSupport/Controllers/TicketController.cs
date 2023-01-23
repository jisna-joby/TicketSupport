using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSupport.Data;
using TicketSupport.Models;

namespace TicketSupport.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDbContext _db;

        public TicketController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ticket> objTicketList = _db.Tickets;
            return View(objTicketList);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Valsearch)
        {
            ViewData["GetDetails"] = Valsearch;
            
            var query = from x in _db.Tickets select x;
            if (!String.IsNullOrEmpty(Valsearch))
            {
                query = query.Where(x => x.ProjectName.Contains(Valsearch) || x.DeptName.Contains(Valsearch) || x.EmployeeName.Contains(Valsearch) || x.Description.Contains(Valsearch));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
    }
}
