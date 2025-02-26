using Domain.Result;

namespace Infrastructure.Interfaces;

public interface IEmbedderClient
{

    public Task<Result<string>> EmbedAsync(string text);

}
