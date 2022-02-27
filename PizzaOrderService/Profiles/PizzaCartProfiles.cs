using AutoMapper;
using PizzaOrderService.Dtos;
using PizzaOrderService.Models;

namespace PizzaOrderService.Profiles
{
    public class OrderProfiles : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderReadDto, Order>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}