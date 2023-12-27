using StaySphere.Domain.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Room
{
    public class RoomDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int Number { get; set; }

        public int Floor { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }

    }
}
