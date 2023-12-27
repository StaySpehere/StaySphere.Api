using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Booking
{
    public record BookingForCreateDto(
        int GuestId,
        int EmployeeId,
        int RoomId);


}
