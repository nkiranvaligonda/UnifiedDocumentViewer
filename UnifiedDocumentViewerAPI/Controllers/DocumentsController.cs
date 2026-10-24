using Microsoft.AspNetCore.Mvc;
using UnifiedDocumentViewerAPI.Services;

namespace UnifiedDocumentViewerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentsController> _logger;
        public DocumentsController(IDocumentService documentService, ILogger<DocumentsController> logger)
        {
            _documentService = documentService;
            _logger = logger;
        }

        [HttpGet("{vin}")]
        public async Task<IActionResult> Get(string vin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vin))
                {
                    return BadRequest("VIN is required.");
                }

                var documents = await _documentService.GetAllDocumentsAsync(vin);

                if (documents == null || !documents.Any())
                {
                    return NotFound($"No documents found for VIN '{vin}'.");
                }

                return Ok(documents);
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex,
                    "Mock data file not found while retrieving documents for VIN {Vin}",
                    vin);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Document data source not found.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex,
                    "Error calling downstream system for VIN {Vin}",
                    vin);

                return StatusCode(
                    StatusCodes.Status502BadGateway,
                    "Unable to retrieve data from external systems.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unexpected error retrieving documents for VIN {Vin}",
                    vin);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred.");
            }
        }
    }
}
