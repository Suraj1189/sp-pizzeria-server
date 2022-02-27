using Microsoft.EntityFrameworkCore;
using CustomPizzaService.Models;

namespace CustomPizzaService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<CustomPizza> CustomPizzas { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}