using AutoMapper;
using PizzaCartService.Dtos;
using PizzaCartService.Models;

namespace PizzaCartService.PizzaCartProfiles
{
    public class PizzaCartProfiles : Profile
    {
        public PizzaCartProfiles()
        {
            CreateMap<Cart, CartReadDto>();
            CreateMap<CartCreateDto, Cart>();
        }
    }
}