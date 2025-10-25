using Microsoft.AspNetCore.Mvc;
using isgasoir.Services.ServiceApi;

namespace isgasoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LLMController : ControllerBase
    {
        private readonly LLMApi _llmApi;

        public LLMController(LLMApi llmApi)
        {
            _llmApi = llmApi;
        }

        // POST: api/LLM/generate
        [HttpPost("generate")]
        public async Task<ActionResult<object>> GenerateContent([FromBody] GenerateRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Prompt))
                {
                    return BadRequest("Prompt is required");
                }

                var generatedText = await _llmApi.GenerateTextAsync(request.Prompt);
                
                return Ok(new { generatedText = generatedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to generate content", details = ex.Message });
            }
        }
    }

    public class GenerateRequest
    {
        public string Prompt { get; set; } = string.Empty;
    }
}
