using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OtelOtomasyonu.Services
{
    public class GeminiChatService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly JavaScriptSerializer _serializer;

        public GeminiChatService()
        {
            _apiKey = ConfigurationManager.AppSettings["GeminiApiKey"];
            _model = string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["GeminiModel"])
                ? "gemini-1.5-flash"
                : ConfigurationManager.AppSettings["GeminiModel"];

            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new InvalidOperationException("Gemini API anahtarı App.config içinde tanımlanmalıdır.");
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://generativelanguage.googleapis.com/")
            };

            _serializer = new JavaScriptSerializer();
        }

        public async Task<string> AskAsync(string userMessage, string contextPrompt = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                throw new ArgumentException("Kullanıcı mesajı boş olamaz.", nameof(userMessage));
            }

            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new
                            {
                                text = BuildPrompt(userMessage, contextPrompt)
                            }
                        }
                    }
                }
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"v1beta/models/{_model}:generateContent?key={_apiKey}")
            {
                Content = new StringContent(_serializer.Serialize(payload), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request, cancellationToken);
            var raw = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini API hatası: {response.StatusCode} - {raw}");
            }

            var geminiResponse = _serializer.Deserialize<GeminiResponse>(raw);
            var answer = geminiResponse?.candidates?
                .FirstOrDefault()?
                .content?.parts?
                .FirstOrDefault()?
                .text;

            return string.IsNullOrWhiteSpace(answer)
                ? "Şu anda yanıt üretemiyorum, lütfen daha sonra tekrar deneyin."
                : answer.Trim();
        }

        private static string BuildPrompt(string userMessage, string contextPrompt)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(contextPrompt))
            {
                sb.AppendLine(contextPrompt.Trim());
                sb.AppendLine();
            }

            sb.AppendLine("Kullanıcı sorusu:");
            sb.AppendLine(userMessage.Trim());
            sb.AppendLine();
            sb.AppendLine("Yanıt formatı:");
            sb.AppendLine("- Türkçe yanıt ver.");
            sb.Append("- Otel otomasyonu kurallarına göre kısa ve net ol.");

            return sb.ToString();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    internal class GeminiResponse
    {
        public Candidate[] candidates { get; set; }
    }

    internal class Candidate
    {
        public Content content { get; set; }
    }

    internal class Content
    {
        public Part[] parts { get; set; }
    }

    internal class Part
    {
        public string text { get; set; }
    }
}
