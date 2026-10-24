using Microsoft.Extensions.Options;
using UnifiedDocumentViewer.Models;

namespace UnifiedDocumentViewer.Services
{
    public class DocumentApiClient : IDocumentApiClient
    {
        private readonly HttpClient _httpClient;
        public DocumentApiClient(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress =
          new Uri(options.Value.BaseUrl);
        }

        public async Task<List<Document>> GetDocumentsAsync(string vin)
        {
            try
            {

                var docs = await _httpClient.GetFromJsonAsync<List<Document>>
                (
                    $"api/documents/{vin}"
                );

                return docs ?? new List<Document>();
            }
            catch (HttpRequestException ex)
            {
                
                throw;
            }
            catch (TaskCanceledException ex)
            {
               
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
