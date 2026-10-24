using Microsoft.AspNetCore.Mvc;
using UnifiedDocumentViewer.Services;

namespace UnifiedDocumentViewer.Controllers
{
    public class HomeController: Controller
    {
        
        private readonly IDocumentApiClient _apiClient;
        public HomeController(IDocumentApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string vin)
        {
            var documents = await _apiClient.GetDocumentsAsync(vin);

            ViewBag.Vin = vin;

            return View(documents);
        }
    }
}
