using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<PaginatedList<CategoryDto>> GetCategories(CategoryResourceParameters resourceParameters);
        Task<CategoryDto?> GetCategoryById(int id);
        Task<CategoryDto> CreateCategory(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategory(CategoryForUpdateDto categoryForUpdateDto);
        Task DeleteCategory(int id);
    }
}
