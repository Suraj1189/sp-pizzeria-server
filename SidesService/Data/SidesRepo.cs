using System.Collections.Generic;
using System.Linq;
using SidesService.Models;

namespace SidesService.Data
{
    public class SidesRepo : ISidesRepo
    {
        private readonly AppDbContext _context;

        public SidesRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Side> GetAllSides()
        {
            return _context.Sides.ToList();
        }

        public Side GetSideById(int id)
        {
             return _context.Sides.FirstOrDefault(s=> s.NonPizzaId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}