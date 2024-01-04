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
                 .ForMember(x => x.NumberOfRooms, r => r.MapFrom(x => x.Rooms.Count));
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
