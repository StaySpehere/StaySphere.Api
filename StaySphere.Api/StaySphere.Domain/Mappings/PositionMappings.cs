using AutoMapper;
using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class PositionMappings : Profile
    {
        public PositionMappings()
        {
            CreateMap<Position, PositionDto>();
            CreateMap<PositionDto, Position>();
            CreateMap<PositionForCreateDto, Position>();
            CreateMap<PositionForUpdateDto, Position>();
        }
    }
}
