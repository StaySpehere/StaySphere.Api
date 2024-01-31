using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IReviewService
    {
        Task<GetReviewResponse> GetReviewsAsync(ReviewResourceParameters reviewResourceParameters);
        Task<ReviewDto?> GetReviewByIdAsync(int id);
        Task<ReviewDto> CreateReviewAsync(ReviewForCreateDto reviewForCreateDto);
        Task UpdateReviewAsync(ReviewForUpdateDto reviewForUpdateDto);
        Task DeleteReviewAsync(int id);
    }
}
