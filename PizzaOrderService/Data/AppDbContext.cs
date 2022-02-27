using Microsoft.EntityFrameworkCore;
using PizzaOrderService.Models;

namespace PizzaOrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}