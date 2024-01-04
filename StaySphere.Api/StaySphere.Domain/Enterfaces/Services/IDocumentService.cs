using StaySphere.Domain.DTOs.Document;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IDocumentService
    {
        Task<DocumentDto> GetDocuments();
        Task<DocumentDto?> GetDocumentById(int id);
        Task<DocumentDto> CreateDocument(DocumentForCreateDto documentForCreateDto);
        Task UpdateDocument(DocumentForUpdateDto documentForUpdateDto);
        Task DeleteDocument(int id);
    }
}
