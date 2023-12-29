using StaySphere.Domain.DTOs.Category;

namespace StaySphere.Domain.Enterfaces.Services
{
    internal interface ICategoryService
    {
        CategoryDto GetCategories();
        CategoryDto? GetCategoryById(int id);
        CategoryDto CreateCategory(CategoryForCreateDto categoryForCreateDto);
        void UpdateCategory(CategoryForUpdateDto categoryForUpdateDto);
        void DeleteCategory(int id);
    }
}
