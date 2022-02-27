using System.Collections.Generic;
using CustomPizzaService.Models;

namespace CustomPizzaService.Data
{
    public interface ICustomPizzaRepo
    {
        bool SaveChanges();
        IEnumerable<CustomPizza> GetAllPizzas();
        CustomPizza GetPizzaById(int id);
        void CreatePizza(CustomPizza plat);
        IEnumerable<Ingredient> GetAllIngrediants();
    }
}