

using Application.Interfaces.Job;
using Application.Interfaces.Vector;
using Domain.Result;


namespace Application.Services.Vector;

class VectorService<T> : IVectorService<T>
{
    public Task<Result<T>> EmbedAsync(string text)
    {
        throw new NotImplementedException();

        // split text

        var paragraphs =
              TextChunker.SplitPlainTextParagraphs(
                  TextChunker.SplitPlainTextLines(
                      content,
                      128),
                  1024);

        // compute embeddings


        // store embeddings

    }
}