using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class ReviewService : IReviewService
    {

        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<ReviewService> _logger;

        public ReviewService(IMapper mapper, StaySphereDbContext context, ILogger<ReviewService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
