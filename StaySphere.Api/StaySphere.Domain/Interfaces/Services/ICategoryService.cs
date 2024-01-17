using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<PaginatedList<CategoryDto>> GetCategoriesAsync(CategoryResourceParameters resourceParameters);
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdateDto);
        Task DeleteCategory(int id);
    }
}
