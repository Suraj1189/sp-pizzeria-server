using Microsoft.EntityFrameworkCore;
using DessertsService.Models;

namespace DessertsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Dessert> Desserts { get; set; }
    }
}