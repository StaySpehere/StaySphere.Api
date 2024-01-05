using StaySphere.Domain.DTOs.Guest;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IGuestService
    {
        Task<GuestDto> GetGuests();
        Task<GuestDto?> GetGuestById(int id);
        Task<GuestDto> CreateGuest(GuestForCreateDto guestForCreateDto);
        Task UpdateGuest(GuestForUpdateDto guestForUpdateDto);
        Task DeleteGuest(int id);
    }
}
