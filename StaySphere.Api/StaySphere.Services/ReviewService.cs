using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
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

        public async Task<PaginatedList<ReviewDto>> GetReviews(ReviewResourceParameters reviewResourceParameters)
        {
            var query = _context.Reviews.AsQueryable();

            if (reviewResourceParameters.BookingId is not null)
            {
                query = query.Where(x => x.BookingId == reviewResourceParameters.BookingId);
            }

            if (reviewResourceParameters.Grade is not null)
            {
                query = query.Where(x => x.Grade == reviewResourceParameters.Grade);
            }

            if (reviewResourceParameters.GradeLessThan is not null)
            {
                query = query.Where(x => x.Grade < reviewResourceParameters.GradeLessThan);
            }

            if (reviewResourceParameters.GradeGreaterThan is not null)
            {
                query = query.Where(x => x.Grade > reviewResourceParameters.GradeGreaterThan);
            }

            if (!string.IsNullOrEmpty(reviewResourceParameters.OrderBy))
            {
                query = reviewResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "BookindId" => query.OrderBy(x => x.BookingId),
                    "BookindIddesc" => query.OrderByDescending(x => x.BookingId),
                    "Comment" => query.OrderBy(x => x.Comment),
                    "Commentdesc" => query.OrderByDescending(x => x.Comment),
                    "Grade" => query.OrderBy(x => x.Grade),
                    "Gradedesc" => query.OrderByDescending(x => x.Grade),
                    _ => query.OrderBy(x => x.Grade)
                };
            }

            var reviews = await query.ToPaginatedListAsync(reviewResourceParameters.PageSize, reviewResourceParameters.PageNumber);
            var reviewsDtos = _mapper.Map<List<ReviewDto>>(reviews);

            return new PaginatedList<ReviewDto>(reviewsDtos, reviews.TotalCount, reviews.CurrentPage, reviews.PageSize);
        }
    }
}
