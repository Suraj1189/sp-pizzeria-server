using System.Collections.Generic;
using System.Linq;
using BeveragesService.Data;
using BeveragesService.Models;

namespace BeveragesService.Data
{
    public class BeveragesRepo : IBeveragesRepo
    {
        private readonly AppDbContext _context;

        public BeveragesRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Beverage> GetAllBeverages()
        {
            return _context.Beverages.ToList();
        }

        public Beverage GetBeverageById(int id)
        {
             return _context.Beverages.FirstOrDefault(s=> s.NonPizzaId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}