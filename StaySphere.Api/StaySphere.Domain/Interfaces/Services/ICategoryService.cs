using StaySphere.Domain.DTOs.Category;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategories();
        Task<CategoryDto?> GetCategoryById(int id);
        Task<CategoryDto> CreateCategory(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategory(CategoryForUpdateDto categoryForUpdateDto);
        Task DeleteCategory(int id);
    }
}
