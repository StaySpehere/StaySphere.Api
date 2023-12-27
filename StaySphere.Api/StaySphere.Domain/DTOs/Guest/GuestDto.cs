using StaySphere.Domain.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Guest
{
    public class GuestDto
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
