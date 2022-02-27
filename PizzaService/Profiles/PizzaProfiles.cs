using AutoMapper;
using PizzaService.Dtos;
using PizzaService.Models;

namespace PizzaService.Profiles
{
    public class PizzaProfiles : Profile
    {
        public PizzaProfiles()
        {
            CreateMap<PizzaReadDto, Pizza>();
            CreateMap<Pizza, PizzaReadDto>();
        }
    }
}