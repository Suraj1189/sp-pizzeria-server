using Microsoft.EntityFrameworkCore;
using PizzaService.Models;

namespace PizzaService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}