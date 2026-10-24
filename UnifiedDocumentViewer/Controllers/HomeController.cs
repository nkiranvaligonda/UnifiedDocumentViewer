using Microsoft.AspNetCore.Mvc;
using UnifiedDocumentViewer.Services;

namespace UnifiedDocumentViewer.Controllers
{
    public class HomeController : Controller
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
            try
            {
                if (string.IsNullOrWhiteSpace(vin))
                {
                    ModelState.AddModelError("vin", "VIN is required.");
                    return View();
                }
                var documents = await _apiClient.GetDocumentsAsync(vin);
                if (documents == null || !documents.Any())
                {
                    ViewBag.ErrorMessage = $"No documents found for VIN '{vin}'.";
                    return View("Index");
                }
                ViewBag.Vin = vin;

                return View(documents);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Unable to retrieve documents. Please try again.";
                return View("Index");
            }
        }
    }
}
