using System.Collections.Generic;
using System.Linq;
using CustomPizzaService.Dtos;
using CustomPizzaService.Models;

namespace CustomPizzaService.Data
{
    public class CustomPizzaRepo : ICustomPizzaRepo
    {
        private readonly AppDbContext _context;

        public CustomPizzaRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePizza(CustomPizza pizza)
        {
            _context.CustomPizzas.Add(pizza);
        }

        public IEnumerable<Ingredient> GetAllIngrediants()
        {
            return _context.Ingredients.ToList();
        }

        public IEnumerable<CustomPizza> GetAllPizzas()
        {
            return _context.CustomPizzas.ToList();
        }

        public CustomPizza GetPizzaById(int id)
        {
            return _context.CustomPizzas.FirstOrDefault(p => p.PizzaId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}