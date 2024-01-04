using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IBookingService
    {
        Task<BookingDto> GetBooking();
        Task<BookingDto?> GetBookingById(int id);
        Task<BookingDto> CreateBooking(BookingForCreateDto bookingForCreateDto);
        Task UpdateBooking(BookingForUpdateDto bookingForUpdateDto);
        Task DeleteBooking(int id); 
    }
}
