using AutoMapper;
using StaySphere.Domain.DTOs.Document;
using Document = StaySphere.Domain.Entities.Document;

namespace StaySphere.Domain.Mappings
{
    public class DocumentMappings : Profile
    {
        public DocumentMappings()
        {
            CreateMap<Document, DocumentDto>()
                .ForCtorParam(nameof(DocumentDto.FullName),
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<DocumentDto, Document>();
            CreateMap<DocumentForCreateDto, Document>();
            CreateMap<DocumentForUpdateDto, Document>();
        }
    }
}
