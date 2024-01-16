using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        Task<PaginatedList<BookingDto>> GetBookingsAsync(BookingResourceParameters bookingResourceParameters);
        Task<BookingDto?> GetBookingByIdAsync(int id);
        Task<BookingDto> CreateBookingAsync(BookingForCreateDto bookingForCreateDto);
        Task UpdateBookingAsync(BookingForUpdateDto bookingForUpdateDto);
        Task DeleteBookingAsync(int id);
    }
}
