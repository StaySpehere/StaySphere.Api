using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<PaginatedList<DocumentDto>>GetDocumentsAsync(DocumentResourceParameters documentResourceParameters);
        Task<DocumentDto?> GetDocumentById(int id);
        Task<DocumentDto> CreateDocument(DocumentForCreateDto documentForCreateDto);
        Task UpdateDocument(DocumentForUpdateDto documentForUpdateDto);
        Task DeleteDocument(int id);
    }
}
