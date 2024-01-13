using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IReviewService
    {
        Task<PaginatedList<ReviewDto>> GetReviews(ReviewResourceParameters reviewResourceParameters);
        Task<ReviewDto?> GetReviewById(int id);
        Task<ReviewDto> CreateReview(ReviewForCreateDto reviewForCreateDto);
        Task UpdateReview(ReviewForUpdateDto reviewForUpdateDto);
        Task DeleteReview(int id);
    }
}
