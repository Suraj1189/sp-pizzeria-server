using Microsoft.EntityFrameworkCore;
using BeveragesService.Models;

namespace BeveragesService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Beverage> Beverages { get; set; }
    }
}