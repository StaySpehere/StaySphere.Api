using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeDto(
        int Id,
        int PositionId,
        string FullName,
        string PhoneNumber,
        decimal Salary,
        ICollection<BookingDto> Bookings);
}

