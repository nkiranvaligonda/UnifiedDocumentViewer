using System.Text.Json;
using UnifiedDocumentViewerAPI.Models;

namespace UnifiedDocumentViewerAPI.Services
{
    public class ServiceSystemClient
    {
        public async Task<List<Document>> GetDocumentsAsync(string vin)
        {
            try
            {
                var file = Path.Combine(
               Directory.GetCurrentDirectory(),
               "MockData",
               "service-documents.json");

                var json = await File.ReadAllTextAsync(file);

                var data = JsonSerializer.Deserialize<List<Document>>(json)
                           ?? new List<Document>();

                var serviceDocs = data.Where(x => x.Vin.ToUpper() == vin.ToUpper()).ToList();
                return serviceDocs;
            }
            catch (Exception ex) { throw; }
        }
    }
}
