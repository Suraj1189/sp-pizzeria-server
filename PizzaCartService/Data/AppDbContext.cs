using Microsoft.EntityFrameworkCore;
using PizzaCartService.Models;

namespace PizzaCartService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Cart> Carts { get; set; }
    }
}