using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse> GetCategoriesAsync(CategoryResourceParameters resourceParameters);
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdateDto);
        Task DeleteCategoryAsync(int id);
    }
}
