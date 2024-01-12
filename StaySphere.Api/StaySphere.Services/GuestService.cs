using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class GuestService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<GuestService> _logger;

        public GuestService(IMapper mapper, StaySphereDbContext context, ILogger<GuestService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PaginatedList<GuestDto>> GetGuests(GuestResourceParameters guestResourceParameters)
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
    }
}
