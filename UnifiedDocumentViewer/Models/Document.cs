namespace UnifiedDocumentViewer.Models
{
    public class Document
    {
        public string Id { get; set; } = string.Empty;

        public string Vin { get; set; } = string.Empty;

        public string DocumentName { get; set; } = string.Empty;

        public string SourceSystem { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
