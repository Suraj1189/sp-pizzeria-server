using AutoMapper;
using DessertsService.Dtos;
using DessertsService.Models;

namespace DessertsService.Profiles
{
    public class DessertsProfiles : Profile
    {
        public DessertsProfiles()
        {
            CreateMap<Dessert, DessertReadDto>();
        }
    }
}