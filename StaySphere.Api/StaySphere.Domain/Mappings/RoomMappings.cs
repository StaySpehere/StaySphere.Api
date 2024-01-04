using AutoMapper;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class RoomMappings : Profile
    {
        public RoomMappings()
        {
            CreateMap<Room,RoomDto>();
            CreateMap<RoomDto, Room>();
            CreateMap<RoomForCreateDto, Room>();
            CreateMap<RoomForUpdateDto, Room>();
        }
    }
}
