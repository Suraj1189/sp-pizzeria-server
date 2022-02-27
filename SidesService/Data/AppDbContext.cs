using Microsoft.EntityFrameworkCore;
using SidesService.Models;

namespace SidesService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Side> Sides { get; set; }
    }
}