using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IGuestService
    {
        Task<PaginatedList<GuestDto>> GetGuestsAsync(GuestResourceParameters guestResourceParameters);
        Task<GuestDto?> GetGuestByIdAsync(int id);
        Task<GuestDto> CreateGuestAsync(GuestForCreateDto guestForCreateDto);
        Task UpdateGuestAsync(GuestForUpdateDto guestForUpdateDto);
        Task DeleteGuest(int id);
    }
}
