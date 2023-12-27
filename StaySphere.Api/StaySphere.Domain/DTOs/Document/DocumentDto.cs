using StaySphere.Domain.DTOs.Guest;

namespace StaySphere.Domain.DTOs.Document
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Gender { get; set; }
        public ICollection<GuestDto> Guests { get; set; }
    }
}
