using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly StaySphereDbContext _context;

        public CategoryService(IMapper mapper,
           StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetCategoryResponse> GetCategoriesAsync(CategoryResourceParameters categoryResourceParameters)
        {
            var query = _context.Categories.AsQueryable();

            if (categoryResourceParameters.Price is not null)
            {
                query = query.Where(x => x.Price == categoryResourceParameters.Price);
            }

            if (categoryResourceParameters.PriceLessThan is not null)
            {
                query = query.Where(x => x.Price < categoryResourceParameters.PriceLessThan);
            }

            if (categoryResourceParameters.PriceGreaterThan is not null)
            {
                query = query.Where(x => x.Price > categoryResourceParameters.PriceGreaterThan);
            }

            if (!string.IsNullOrEmpty(categoryResourceParameters.OrderBy))
            {
                query = categoryResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    "price" => query.OrderBy(x => x.Price),
                    "pricedesc" => query.OrderByDescending(x => x.Price),
                    _ => query.OrderBy(x => x.Name)
                };
            }

            var categories = await query.ToPaginatedListAsync(categoryResourceParameters.PageSize, categoryResourceParameters.PageNumber);
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            var paginatedCategory = new PaginatedList<CategoryDto>(categoryDtos, categories.TotalCount, categories.CurrentPage, categories.PageSize);

            var result = new GetCategoryResponse()
            {
                Data = paginatedCategory.ToList(),
                HasNextPage = paginatedCategory.HasNext,
                HasPreviousPage = paginatedCategory.HasPrevious,
                PageNumber = paginatedCategory.CurrentPage,
                PageSize = paginatedCategory.PageSize,
                TotalPages = paginatedCategory.TotalPages
            };

            return result;
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null)
            {
                throw new EntityNotFoundException($"Category with id: {id} not found");
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryForCreateDto);

            _context.Categories.Add(categoryEntity);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);

            return categoryDto;
        }
        public async Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdateDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryForUpdateDto);

            _context.Categories.Update(categoryEntity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is not null)
            {
                _context.Categories.Remove(category);
            }
            await _context.SaveChangesAsync();
        }
    }
}
