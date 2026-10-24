using UnifiedDocumentViewerAPI.Models;

namespace UnifiedDocumentViewerAPI.Services
{
    public class DocumentService: IDocumentService
    {
       private readonly SalesSystemClient _salesClient;
        private readonly ServiceSystemClient _serviceClient;

        public DocumentService(
            SalesSystemClient salesClient,
            ServiceSystemClient serviceClient)
        {
            _salesClient = salesClient;
            _serviceClient = serviceClient;
        }

        public async Task<List<Document>> GetAllDocumentsAsync(string vin)
        {
            var salesTask = _salesClient.GetDocumentsAsync(vin);
            var serviceTask = _serviceClient.GetDocumentsAsync(vin);

            await Task.WhenAll(salesTask, serviceTask);

            var result= salesTask.Result
                .Concat(serviceTask.Result)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
            return result;
        }

        
    }
}
