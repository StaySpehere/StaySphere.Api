using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class GuestService : IGuestService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;

        public GuestService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedList<GuestDto>> GetGuestsAsync(GuestResourceParameters guestResourceParameters)
        {
            var query = _context.Guests.AsQueryable();

            if (guestResourceParameters.DocumentId is not null)
            {
                query = query.Where(x => x.Id == guestResourceParameters.DocumentId);
            }

            if (!string.IsNullOrEmpty(guestResourceParameters.OrderBy))
            {
                query = guestResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "PhoneNumber" => query.OrderBy(x => x.PhoneNumber),
                    "PhoneNumberdesc" => query.OrderByDescending(x => x.PhoneNumber),
                    "Email" => query.OrderBy(x => x.Email),
                    "Emaildesc" => query.OrderByDescending(x => x.Email),
                    "DocumentId" => query.OrderBy(x => x.DocumentId),
                    "DocumentIddesc" => query.OrderByDescending(x => x.DocumentId),
                    _ => query.OrderBy(x => x.Email)
                };
            }

            var guests = await query.ToPaginatedListAsync(guestResourceParameters.PageSize, guestResourceParameters.PageNumber);
            var guestDtos = _mapper.Map<List<GuestDto>>(guests);

            return new PaginatedList<GuestDto>(guestDtos, guests.TotalCount, guests.CurrentPage, guests.PageSize);
        }

        public async Task<GuestDto?> GetGuestByIdAsync(int id)
        {
            var guests = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);

            if (guests is null)
            {
                throw new EntityNotFoundException($"Guest with id {id} not found!");
            }

            var guestDtos = _mapper.Map<GuestDto>(guests);
            return guestDtos;
        }

        public async Task<GuestDto> CreateGuestAsync(GuestForCreateDto guestForCreateDto)
        {
            var guestEntity = _mapper.Map<Guest>(guestForCreateDto);

            _context.Add(guestEntity);
            await _context.SaveChangesAsync();

            var guestDto = _mapper.Map<GuestDto>(guestEntity);
            return guestDto;
        }

        public async Task UpdateGuest(GuestForUpdateDto guestForUpdateDto)
        {
            var guestEntity = _mapper.Map<Guest>(guestForUpdateDto);

            _context.Add(guestEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuest(int id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);

            if (guest is not null)
                _context.Remove(guest);

            await _context.SaveChangesAsync();
        }
    }
}
