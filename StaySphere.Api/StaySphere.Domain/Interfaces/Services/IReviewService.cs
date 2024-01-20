using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IReviewService
    {
        Task<PaginatedList<ReviewDto>> GetReviewsAsync(ReviewResourceParameters reviewResourceParameters);
        Task<ReviewDto?> GetReviewByIdAsync(int id);
        Task<ReviewDto> CreateReviewAsync(ReviewForCreateDto reviewForCreateDto);
        Task UpdateReviewAsync(ReviewForUpdateDto reviewForUpdateDto);
        Task DeleteReviewAsync(int id);
    }
}
