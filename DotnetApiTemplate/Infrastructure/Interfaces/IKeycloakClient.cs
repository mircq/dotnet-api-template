using Domain.Result;

namespace Infrastructure.Interfaces;

public interface IKeycloakClient
{

    public Task<Result<string>> GetTokenAsync(string username, string password);

    public Task<Result<bool>> ValidateTokenAsync(string token);
}
