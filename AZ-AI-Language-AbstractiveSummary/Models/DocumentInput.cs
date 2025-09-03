namespace AZ_AI_Language_AbstractiveSummary.Models
{
    public class DocumentInput
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Language { get; set; } = "en";
        public string Text { get; set; } = string.Empty;
    }
}
