using Domain.Result;
using Infrastructure.Errors;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.Clients;

public class KeycloakClient: IKeycloakClient
{
    private readonly HttpClient _httpClient;
    private readonly string _realmUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public KeycloakClient(HttpClient httpClient, KeycloakSettings settings)
    {
        _httpClient = httpClient;
        _realmUrl = settings.RealmUrl;
        _clientId = settings.ClientId;
        _clientSecret = settings.ClientSecret;
    }

    public async Task<Result<string>> GetTokenAsync(string username, string password)
    {
        FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", _clientId),
            new KeyValuePair<string, string>("client_secret", _clientSecret),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password)
        });

        HttpResponseMessage response = await _httpClient.PostAsync(requestUri: $"{_realmUrl}/protocol/openid-connect/token", content: content);

        if (!response.IsSuccessStatusCode)

            return KeycloakErrors.FailedTokenRetrievalError();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(json: jsonResponse);

        return tokenResponse["access_token"];
    }

    public async Task<Result<bool>> ValidateTokenAsync(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await _httpClient.GetAsync($"{_realmUrl}/protocol/openid-connect/userinfo");

        return response.IsSuccessStatusCode;
    }

}
