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
                .ForCtorParam(nameof(BookingDto.StayDuration),
                    opt => opt.MapFrom(src => src.CheckOutDate.Day - src.CheckInDate.Day));
            CreateMap<BookingDto, Booking>();
            CreateMap<BookingForCreateDto, Booking>();
            CreateMap<BookingForUpdateDto, Booking>();
        }
    }
}
