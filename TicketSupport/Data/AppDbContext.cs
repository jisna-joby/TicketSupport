using Microsoft.EntityFrameworkCore;
using TicketSupport.Models;

namespace TicketSupport.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
