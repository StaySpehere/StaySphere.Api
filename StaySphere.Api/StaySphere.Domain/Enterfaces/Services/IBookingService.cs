using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IBookingService
    {
        BookingDto GetBooking();
        BookingDto? GetBookingById(int id);
        BookingDto CreateBooking(BookingForCreateDto bookingForCreateDto);
        void UpdateBooking(BookingForUpdateDto bookingForUpdateDto);
        void DeleteBooking(int id); 
    }
}
