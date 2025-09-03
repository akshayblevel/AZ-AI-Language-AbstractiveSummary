using AZ_AI_Language_AbstractiveSummary.Interfaces;
using AZ_AI_Language_AbstractiveSummary.Models;
using Azure;
using Azure.AI.TextAnalytics;
using Azure.Core;
using System.Threading;

namespace AZ_AI_Language_AbstractiveSummary.Services
{
    public class AnalysisService(TextAnalyticsClient textAnalytics) : IAnalysisService
    {
        public async Task<AbstractiveSummaryResponse> AbstractiveSummaryAnalysis(AbstractiveSummaryRequest abstractiveSummaryRequest)
        {
            var documents = abstractiveSummaryRequest.Documents.Select(d => d.Text).ToList();

            AbstractiveSummarizeOperation operation =
                await textAnalytics.AbstractiveSummarizeAsync(WaitUntil.Completed,documents,cancellationToken: default);

            var response = new AbstractiveSummaryResponse();

            int index = 0;
            await foreach (var page in operation.Value)
            {
                response.ModelVersion = page.ModelVersion;

                foreach (var doc in page)
                {
                    var inputDoc = abstractiveSummaryRequest.Documents.ElementAt(index++);
                    var documentResult = new AbstractiveSummaryDocument
                    {
                        Id = inputDoc.Id
                    };

                    foreach (var summary in doc.Summaries)
                    {
                        var sentence = new SummarySentence
                        {
                            Text = summary.Text,
                            Contexts = summary.Contexts
                                .Select(c => new ContextReference
                                {
                                    Offset = c.Offset,
                                    Length = c.Length
                                })
                                .ToList()
                        };

                        documentResult.Summaries.Add(sentence);
                    }

                    response.Documents.Add(documentResult);
                }
            }

            return response;
        }
    }
}
