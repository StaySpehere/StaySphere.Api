using StaySphere.Domain.DTOs.Review;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IReviewService
    {
        Task<ReviewDto> GetReviews();
        Task<ReviewDto?> GetReviewById(int id);
        Task<ReviewDto> CreateReview(ReviewForCreateDto reviewForCreateDto);
        Task UpdateReview(ReviewForUpdateDto reviewForUpdateDto);
        Task DeleteReview(int id);
    }
}
