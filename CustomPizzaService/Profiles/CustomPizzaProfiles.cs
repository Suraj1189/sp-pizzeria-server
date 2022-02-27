using AutoMapper;
using CustomPizzaService.Dtos;
using CustomPizzaService.Models;

namespace CustomPizzaService.Profiles
{
    public class CustomPizzaProfiles : Profile
    {
        public CustomPizzaProfiles()
        {
            CreateMap<CustomPizza, CustomPizzaReadDto>();
            CreateMap<Ingredient, IngredientReadDto>();
            CreateMap<CustomPizzaCreateDto, CustomPizza>();
        }
    }
}