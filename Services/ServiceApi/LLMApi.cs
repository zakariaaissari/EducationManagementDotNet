namespace isgasoir.Services.ServiceApi
{
    public class LLMApi
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public LLMApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<string> GenerateTextAsync(string prompt)
        {
            var apiKey = _configuration["LLMApi:ApiKey"];
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };
            var requestContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);

            var response = await _httpClient.PostAsync("https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent", requestContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            using var jsonDoc = System.Text.Json.JsonDocument.Parse(responseContent);
            var generatedText = jsonDoc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return generatedText ?? string.Empty;
        }
    }
}
