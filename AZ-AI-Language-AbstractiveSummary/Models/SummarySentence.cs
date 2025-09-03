namespace AZ_AI_Language_AbstractiveSummary.Models
{
    public class SummarySentence
    {
        public string Text { get; set; } = string.Empty;
        public List<ContextReference> Contexts { get; set; } = new();
    }
}
