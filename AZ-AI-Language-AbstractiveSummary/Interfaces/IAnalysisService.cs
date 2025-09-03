using AZ_AI_Language_AbstractiveSummary.Models;

namespace AZ_AI_Language_AbstractiveSummary.Interfaces
{
    public interface IAnalysisService
    {
        Task<AbstractiveSummaryResponse> AbstractiveSummaryAnalysis(AbstractiveSummaryRequest abstractiveSummaryRequest);
    }
}
