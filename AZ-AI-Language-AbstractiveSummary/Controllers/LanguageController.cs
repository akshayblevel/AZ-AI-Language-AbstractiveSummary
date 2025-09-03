using AZ_AI_Language_AbstractiveSummary.Interfaces;
using AZ_AI_Language_AbstractiveSummary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AZ_AI_Language_AbstractiveSummary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController(IAnalysisService analysisService) : ControllerBase
    {
        [HttpPost("AbstractiveSummary")]
        public async Task<IActionResult> SentimentAnalysis([FromBody] AbstractiveSummaryRequest abstractiveSummaryRequest)
        {
            var result = await analysisService.AbstractiveSummaryAnalysis(abstractiveSummaryRequest);
            return Ok(result);
        }
    }
}
