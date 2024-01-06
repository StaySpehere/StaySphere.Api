using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        Task<PaginatedList<BookingDto>>GetBookings(BookingResourceParameters bookingResourceParameters);
        Task<BookingDto?> GetBookingById(int id);
        Task<BookingDto> CreateBooking(BookingForCreateDto bookingForCreateDto);
        Task UpdateBooking(BookingForUpdateDto bookingForUpdateDto);
        Task DeleteBooking(int id); 
    }
}
