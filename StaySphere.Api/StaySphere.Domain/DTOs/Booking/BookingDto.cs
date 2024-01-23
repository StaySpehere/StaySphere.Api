﻿using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.DTOs.Booking
{
    public record BookingDto(
        int Id,
        int GuestId,
        int EmployeeId,
        DateTime StayDuration,
        decimal TotalPrice,
        ICollection<ReviewDto> Reviews);
}