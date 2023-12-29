using StaySphere.Domain.DTOs.Guest;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IGuestService
    {
        GuestDto GetGuests();
        GuestDto? GetGuestById(int id);
        GuestDto CreateGuest(GuestForCreateDto guestForCreateDto);
        void UpdateGuest(GuestForCreateDto guestForCreateDto);
        void DeleteGuest(int id);
    }
}
