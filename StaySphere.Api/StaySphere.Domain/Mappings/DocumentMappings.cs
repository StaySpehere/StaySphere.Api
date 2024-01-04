using AutoMapper;
using StaySphere.Domain.DTOs.Document;
using Document = StaySphere.Domain.Entities.Document;

namespace StaySphere.Domain.Mappings
{
    public class DocumentMappings : Profile
    {
        public DocumentMappings()
        {
            CreateMap<Document,DocumentDto>()
                .ForMember(x => x.FullName, r => r.MapFrom(x => x.FirstName + "" + x.LastName));
            CreateMap<DocumentDto, Document>();
            CreateMap<DocumentForCreateDto, Document>();
            CreateMap<DocumentForUpdateDto, Document>();
        }
    }
}
