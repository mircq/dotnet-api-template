using Domain.Result;
using Infrastructure.Errors;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Settings.Embedder;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.SemanticKernel;
using System.Text;
using OllamaSharp;
using Microsoft.SemanticKernel.Embeddings;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.Ollama;

namespace Infrastructure.Clients;

public class EmbedderClient: IEmbedderClient, IEmbeddingGenerator
{
#pragma warning disable SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    private readonly ITextEmbeddingGenerationService embeddingGenerationService;
#pragma warning restore SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

#pragma warning disable SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public EmbedderClient(ITextEmbeddingGenerationService embeddingService)
#pragma warning restore SKEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    {
           
        OllamaApiClient ollamaClient = new(
            uriString: "http://localhost:11434",    
            defaultModel: "nomic-embed-text"
        );

        embeddingGenerationService = ollamaClient.AsTextEmbeddingGenerationService();

    }

    public async Task<ReadOnlyMemory<float>> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
    {
        return await embeddingGenerationService.GenerateEmbeddingAsync(value: text, cancellationToken: cancellationToken);
    }
}
