using System.Collections.Generic;
using PizzaService.Dtos;

namespace PizzaService.Components
{
    public interface IPizzaComponent
    {
        IEnumerable<PizzaReadDto> GetAllPizzas();
    }
}