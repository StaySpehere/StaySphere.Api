using AutoMapper;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class BookingMappings : Profile
    {
        public BookingMappings()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(x => x.StayDuration, r => r.MapFrom(x => x.CheckOutData - x.CheckInData));
            CreateMap<BookingDto, Booking>();
            CreateMap<BookingForCreateDto, Booking>();
            CreateMap<BookingForUpdateDto, Booking>();
        }
    }
}
