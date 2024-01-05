using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        Task<BookingDto> GetBookings();
        Task<BookingDto?> GetBookingById(int id);
        Task<BookingDto> CreateBooking(BookingForCreateDto bookingForCreateDto);
        Task UpdateBooking(BookingForUpdateDto bookingForUpdateDto);
        Task DeleteBooking(int id); 
    }
}
