using Domain.Result;
using Infrastructure.Errors;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Settings.Embedder;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.Embeddings;

namespace Infrastructure.Clients;

public class EmbedderClient: IEmbedderClient, ITextEmbeddingGeneration
{
    private readonly HttpClient _httpClient;
    private readonly string _ollamaUrl = "http://localhost:11434/api/embeddings";
        private readonly string _model;

        public OllamaEmbeddingService(HttpClient httpClient, string model = "nomic-embed-text")
        {
            _httpClient = httpClient;
            _model = model;
        }

        public async Task<IList<float>> GenerateEmbeddingAsync(string text)
        {
            var requestBody = new { model = _model, prompt = text };
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_ollamaUrl, content);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<OllamaEmbeddingResponse>(responseContent);

            return jsonResponse?.Embedding ?? new List<float>();
        }

        // Required for Semantic Kernel
        public async Task<IList<ReadOnlyMemory<float>>> GenerateEmbeddingsAsync(IList<string> texts)
        {
            var embeddings = new List<ReadOnlyMemory<float>>();
            foreach (var text in texts)
            {
                var embedding = await GenerateEmbeddingAsync(text);
                embeddings.Add(new ReadOnlyMemory<float>(embedding.ToArray()));
            }
            return embeddings;
        }

        private class OllamaEmbeddingResponse
        {
            public List<float>? Embedding { get; set; }
        }

}
