namespace AZ_AI_Language_AbstractiveSummary.Models
{
    public class AbstractiveSummaryDocument
    {
        public string Id { get; set; } = string.Empty;
        public List<SummarySentence> Summaries { get; set; } = new();
    }
}
