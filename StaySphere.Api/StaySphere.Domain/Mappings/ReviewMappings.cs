using AutoMapper;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class ReviewMappings : Profile
    {
        public ReviewMappings()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewForCreateDto, Review>();
            CreateMap<ReviewForUpdateDto, Review>();
        }
    }
}
