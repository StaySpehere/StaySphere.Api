using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class ReviewService : IReviewService
    {

        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;

        public ReviewService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetReviewResponse> GetReviewsAsync(ReviewResourceParameters reviewResourceParameters)
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

            var paginatedReviews = new PaginatedList<ReviewDto>(reviewsDtos, reviews.TotalCount, reviews.CurrentPage, reviews.PageSize);

            var result = new GetReviewResponse()
            {
                Data = paginatedReviews.ToList(),
                HasNextPage = paginatedReviews.HasNext,
                HasPreviousPage = paginatedReviews.HasPrevious,
                PageNumber = paginatedReviews.CurrentPage,
                PageSize = paginatedReviews.PageSize,
                TotalPages = paginatedReviews.TotalPages
            };

            return result;
        }

        public async Task<ReviewDto?> GetReviewByIdAsync(int id)
        {
            var reviews = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (reviews is null)
            {
                throw new EntityNotFoundException($"Reviews with id {id} not found!");
            }

            var reviewDtos = _mapper.Map<ReviewDto>(reviews);
            return reviewDtos;
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewForCreateDto reviewForCreateDto)
        {
            var reviewEntity = _mapper.Map<Review>(reviewForCreateDto);

            _context.Add(reviewEntity);
            await _context.SaveChangesAsync();

            var reviewDto = _mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public async Task UpdateReviewAsync(ReviewForUpdateDto reviewForUpdateDto)
        {
            var reviewEntity = _mapper.Map<Review>(reviewForUpdateDto);

            _context.Add(reviewEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (review is not null)
                _context.Remove(review);

            await _context.SaveChangesAsync();
        }
    }
}
