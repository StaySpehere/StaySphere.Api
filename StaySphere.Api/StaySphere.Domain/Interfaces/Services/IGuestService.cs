using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IGuestService
    {
        Task<GetGuestResponse> GetGuestsAsync(GuestResourceParameters guestResourceParameters);
        Task<GuestDto?> GetGuestByIdAsync(int id);
        Task<GuestDto> CreateGuestAsync(GuestForCreateDto guestForCreateDto);
        Task UpdateGuestAsync(GuestForUpdateDto guestForUpdateDto);
        Task DeleteGuestAsync(int id);
    }
}
