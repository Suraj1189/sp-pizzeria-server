using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CustomPizzaService.Data;
using CustomPizzaService.Dtos;
using CustomPizzaService.Models;

namespace CustomPizzaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomPizzaController : ControllerBase
    {
        private readonly ICustomPizzaRepo _repository;
        private readonly IMapper _mapper;

        public CustomPizzaController(ICustomPizzaRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomPizzaReadDto>> GetAllPizza()
        {
           Console.WriteLine("--> Getting Custom Pizzas...");

            var pizzas = _repository.GetAllPizzas();

            return Ok(_mapper.Map<IEnumerable<CustomPizzaReadDto>>(pizzas));
        }
        [HttpGet]
        [Route("toppings")]
        public ActionResult<IEnumerable<IngredientReadDto>> GetAllIngrediants()
        {
           Console.WriteLine("--> Getting Ingrediants...");

            var ingrediants = _repository.GetAllIngrediants();

            return Ok(_mapper.Map<IEnumerable<IngredientReadDto>>(ingrediants));
        }
        [HttpPost]
        public ActionResult<CustomPizzaReadDto> SaveCustomPizza(CustomPizzaCreateDto createDto)
        {
            var customPizzaModel = _mapper.Map<CustomPizza>(createDto);
            _repository.CreatePizza(customPizzaModel);
            _repository.SaveChanges();

            var customPizzaReadDto = _mapper.Map<CustomPizzaReadDto>(customPizzaModel);
            return Ok(customPizzaReadDto);
        }
    }
}
