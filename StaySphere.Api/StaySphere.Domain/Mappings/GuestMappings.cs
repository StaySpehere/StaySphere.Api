using AutoMapper;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class GuestMappings : Profile
    {
        public GuestMappings()
        {
            CreateMap<Guest,GuestDto>();
            CreateMap<GuestDto, Guest>();
            CreateMap<GuestForCreateDto, Guest>();
            CreateMap<GuestForUpdateDto, Guest>();
        }
    }
}
