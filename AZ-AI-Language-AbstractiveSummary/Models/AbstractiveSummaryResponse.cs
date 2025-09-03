namespace AZ_AI_Language_AbstractiveSummary.Models
{
    public class AbstractiveSummaryResponse
    {
        public string ModelVersion { get; set; } = string.Empty;
        public List<AbstractiveSummaryDocument> Documents { get; set; } = new();
    }
}
