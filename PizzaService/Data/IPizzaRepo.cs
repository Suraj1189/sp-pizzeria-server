using System.Collections.Generic;
using PizzaService.Models;

namespace PizzaService.Data
{
    public interface IPizzaRepo
    {
        bool SaveChanges();
        IEnumerable<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        void CreatePizza(Pizza plat);
    }
}