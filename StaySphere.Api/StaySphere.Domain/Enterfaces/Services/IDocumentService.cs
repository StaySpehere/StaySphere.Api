using StaySphere.Domain.DTOs.Document;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IDocumentService
    {
        DocumentDto GetDocuments();
        DocumentDto? GetDocumentById(int id);
        DocumentDto CreateDocument(DocumentForCreateDto documentForCreateDto);
        void UpdateDocument(DocumentForUpdateDto documentForUpdateDto);
        void DeleteDocument(int id);
    }
}
