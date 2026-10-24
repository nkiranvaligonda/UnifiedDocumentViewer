using UnifiedDocumentViewerAPI.Models;

namespace UnifiedDocumentViewerAPI.Services
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocumentsAsync(string vin);
    }
}