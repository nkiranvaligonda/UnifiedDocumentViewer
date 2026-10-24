using System.Text.Json;
using UnifiedDocumentViewerAPI.Models;

namespace UnifiedDocumentViewerAPI.Services
{
    public class SalesSystemClient
    {
        public async Task<List<Document>> GetDocumentsAsync(string vin)
        {
            try
            {
                var file = Path.Combine(
                   Directory.GetCurrentDirectory(),
                   "MockData",
                   "sales-documents.json");

                var json = await File.ReadAllTextAsync(file);

                var data = JsonSerializer.Deserialize<List<Document>>(json)
                           ?? new List<Document>();

                var salesDocs = data.Where(x => x.Vin.ToUpper() == vin.ToUpper()).ToList();
                return salesDocs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
