using System.Collections.Generic;
using System.Linq;
using DessertsService.Data;
using DessertsService.Models;

namespace DessertsService.Data
{
    public class DessertsRepo : IDessertsRepo
    {
        private readonly AppDbContext _context;

        public DessertsRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Dessert> GetAllDesserts()
        {
            return _context.Desserts.ToList();
        }

        public Dessert GetDessertById(int id)
        {
             return _context.Desserts.FirstOrDefault(s=> s.NonPizzaId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}