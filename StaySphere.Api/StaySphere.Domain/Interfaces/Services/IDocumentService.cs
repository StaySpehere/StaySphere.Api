using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<GetDocumentResponse> GetDocumentsAsync(DocumentResourceParameters documentResourceParameters);
        Task<DocumentDto?> GetDocumentByIdAsync(int id);
        Task<DocumentDto> CreateDocumentAsync(DocumentForCreateDto documentForCreateDto);
        Task UpdateDocumentAsync(DocumentForUpdateDto documentForUpdateDto);
        Task DeleteDocumentAsync(int id);
    }
}
