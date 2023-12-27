using StaySphere.Domain.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
      
    }
}
