using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IGuestService
    {
        Task<PaginatedList<GuestDto>> GetGuestsAsync(GuestResourceParameters guestResourceParameters);
        Task<GuestDto?> GetGuestById(int id);
        Task<GuestDto> CreateGuest(GuestForCreateDto guestForCreateDto);
        Task UpdateGuest(GuestForUpdateDto guestForUpdateDto);
        Task DeleteGuest(int id);
    }
}
