using System.Collections.Generic;
using System.Linq;
using PizzaService.Dtos;
using PizzaService.Models;

namespace PizzaService.Data
{
    public class PizzaRepo : IPizzaRepo
    {
        private readonly AppDbContext _context;

        public PizzaRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePizza(Pizza pizza)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pizza> GetAllPizzas()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetPizzaById(int id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.PizzaId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}