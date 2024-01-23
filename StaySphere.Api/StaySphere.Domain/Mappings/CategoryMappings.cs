using AutoMapper;
using StaySphere.Domain.DTOs.Category;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryDto>()
                .ForCtorParam(nameof(CategoryDto.NumberOfRooms),
                    opt => opt.MapFrom(src => src.Rooms.Count()));
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
