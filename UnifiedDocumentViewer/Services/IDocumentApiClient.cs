using UnifiedDocumentViewer.Models;

namespace UnifiedDocumentViewer.Services
{
    public interface IDocumentApiClient
    {
        Task<List<Document>> GetDocumentsAsync(string vin);
    }
}
