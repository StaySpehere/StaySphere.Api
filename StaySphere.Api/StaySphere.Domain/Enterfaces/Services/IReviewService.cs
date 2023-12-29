using StaySphere.Domain.DTOs.Review;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IReviewService
    {
        ReviewDto GetReviews();
        ReviewDto? GetReviewById(int id);
        ReviewDto CreateReview(ReviewForCreateDto reviewForCreateDto);
        void UpdateReview(ReviewForUpdateDto reviewForUpdateDto);
        void DeleteReview(int id);
    }
}
