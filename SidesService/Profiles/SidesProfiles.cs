using AutoMapper;
using SidesService.Dtos;
using SidesService.Models;

namespace SidesService.Profiles
{
    public class SidesProfiles : Profile
    {
        public SidesProfiles()
        {
            CreateMap<Side,SideReadDto>();
        }
    }
}