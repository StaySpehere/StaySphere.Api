using StaySphere.Domain.DTOs.Guest;

namespace StaySphere.Domain.DTOs.Document
{
    public record DocumentDto(
        int Id,
        int SerialNumber,
        string FullName,
        DateTime BirthDate,
        string Gender,
        ICollection<GuestDto> Guests);
}
