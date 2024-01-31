using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        Task<GetBookingResponse> GetBookingsAsync(BookingResourceParameters bookingResourceParameters);
        Task<BookingDto?> GetBookingByIdAsync(int id);
        Task<BookingDto> CreateBookingAsync(BookingForCreateDto bookingForCreateDto);
        Task UpdateBookingAsync(BookingForUpdateDto bookingForUpdateDto);
        Task DeleteBookingAsync(int id);
    }
}
