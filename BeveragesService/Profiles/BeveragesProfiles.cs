using AutoMapper;
using BeveragesService.Dtos;
using BeveragesService.Models;

namespace BeveragesService.Profiles
{
    public class BeveragesProfiles : Profile
    {
        public BeveragesProfiles()
        {
            CreateMap<Beverage, BeverageReadDto>();
        }
    }
}