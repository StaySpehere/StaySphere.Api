﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly StaySphereDbContext _context;
        public BookingService(IMapper mapper,
           StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedList<BookingDto>> GetBookingsAsync(BookingResourceParameters bookingResourceParameters)
        {
            var query = _context.Bookings.AsQueryable();

            if (bookingResourceParameters.RoomId is not null)
            {
                query = query.Where(x => x.RoomId == bookingResourceParameters.RoomId);
            }

            if (bookingResourceParameters.EmployeeId is not null)
            {
                query = query.Where(x => x.EmployeeId == bookingResourceParameters.EmployeeId);
            }

            if (bookingResourceParameters.TotalPrice is not null)
            {
                query = query.Where(x => x.TotalPrice == bookingResourceParameters.TotalPrice);
            }

            if (bookingResourceParameters.TotalPriceLessThan is not null)
            {
                query = query.Where(x => x.TotalPrice < bookingResourceParameters.TotalPriceLessThan);
            }

            if (bookingResourceParameters.TotalPriceGreaterThan is not null)
            {
                query = query.Where(x => x.TotalPrice > bookingResourceParameters.TotalPriceGreaterThan);
            }

            if (!string.IsNullOrEmpty(bookingResourceParameters.OrderBy))
            {
                query = bookingResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "CheckInDate" => query.OrderBy(x => x.CheckInDate),
                    "CheckInDatedesc" => query.OrderByDescending(x => x.CheckInDate),
                    "CheckOutDate" => query.OrderBy(x => x.CheckOutDate),
                    "CheckOutDatedesc" => query.OrderByDescending(x => x.CheckOutDate),
                    "TotalPrice" => query.OrderBy(x => x.TotalPrice),
                    "TotalPricedesc" => query.OrderByDescending(x => x.TotalPrice),
                    _ => query.OrderBy(x => x.Id)
                };
            }

            var bookings = await query.ToPaginatedListAsync(bookingResourceParameters.PageSize, bookingResourceParameters.PageNumber);
            var bookingDtos = _mapper.Map<List<BookingDto>>(bookings);

            return new PaginatedList<BookingDto>(bookingDtos, bookings.TotalCount, bookings.CurrentPage, bookings.PageSize);
        }

        public async Task<BookingDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);

            if (booking == null)
            {
                throw new EntityNotFoundException($"Booking with id: {id} not found");
            }

            var bookingDto = _mapper.Map<BookingDto>(booking);
            return bookingDto;
        }

        public async Task<BookingDto> CreateBookingAsync(BookingForCreateDto bookingForCreateDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingForCreateDto);

            _context.Bookings.Add(bookingEntity);
            await _context.SaveChangesAsync();

            var bookingDto = _mapper.Map<BookingDto>(bookingEntity);

            return bookingDto;
        }
        public async Task UpdateBookingAsync(BookingForUpdateDto bookingForUpdateDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingForUpdateDto);

            _context.Bookings.Update(bookingEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (booking is not null)
            {
                _context.Bookings.Remove(booking);
            }
            await _context.SaveChangesAsync();
        }
    }
}
