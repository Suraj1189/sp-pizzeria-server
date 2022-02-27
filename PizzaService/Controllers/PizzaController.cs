using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaService.Components;
using PizzaService.Data;
using PizzaService.Dtos;

namespace PizzaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaComponent _pizzaComponent;

        public PizzaController(IPizzaComponent pizzaComponent)
        {
            _pizzaComponent = pizzaComponent;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PizzaReadDto>> GetAllPizza()
        {
           Console.WriteLine("--> Getting Pizzas...");

            return Ok(_pizzaComponent.GetAllPizzas());
        }
    }
}
