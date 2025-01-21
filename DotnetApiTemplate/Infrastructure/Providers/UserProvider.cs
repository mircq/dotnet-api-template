using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Providers;

public class UserProvider
{
    public string? getTenant(string? token = null, string? apiKey = null)
    {
        Dictionary<string, Dictionary<string, string>> apiKeys = new Dictionary<string, Dictionary<string, string>>
        {
            { "tenant1", new Dictionary<string, string>{ {"group1", "key1" }, { "group2", "key2" } } },
            { "tenant2", new Dictionary<string, string>{ {"group1", "key1" }, { "group2", "key2" } } },
        };

        if (apiKey != null)
        {
            string? tenant = FindFirstLevelKeyForValue(apiKeys, apiKey);
        }

        if (token != null )
        {
            // Create a handler for JWT
            JwtSecurityTokenHandler handler = new();

            // Read and validate the token
            JwtSecurityToken decodedToken = handler.ReadJwtToken(token: token);

            // Extract a specific claim
            string? claimValue = decodedToken.Claims.FirstOrDefault(c => c.Type == "realm")?.Value;

            return claimValue;
        }

        return null;
    }
    public string? getGroup(string? token = null, string? apiKey = null)
    {
        Dictionary<string, Dictionary<string, string>> apiKeys = new Dictionary<string, Dictionary<string, string>>
        {
            { "tenant1", new Dictionary<string, string>{ {"group1", "key1" }, { "group2", "key2" } } },
            { "tenant2", new Dictionary<string, string>{ {"group1", "key1" }, { "group2", "key2" } } },
        };

        if (apiKey != null)
        {
            string? group = FindSecondLevelKeyForValue(apiKeys, apiKey);

            return group;
        }

        if (token != null)
        {
            // Create a handler for JWT
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Read and validate the token
            JwtSecurityToken decodedToken = handler.ReadJwtToken(token: token);

            // Extract a specific claim
            string? claimValue = decodedToken.Claims.FirstOrDefault(c => c.Type == "group")?.Value;

            return claimValue;
        }

        return null;
    }

    static string? FindFirstLevelKeyForValue(Dictionary<string, Dictionary<string, string>> dict, string value)
    {
        foreach (KeyValuePair<string, Dictionary<string, string>> outerKeyValuePair in dict)
        {
            // Check the inner dictionary for the search value
            foreach (KeyValuePair<string, string> innerKeyValuePair in outerKeyValuePair.Value)
            {
                if (innerKeyValuePair.Value == value)
                {
                    return outerKeyValuePair.Key;  // Return the first level key when value matches
                }
            }
        }

        return null;  // Return null if no match found
    }

    static string? FindSecondLevelKeyForValue(Dictionary<string, Dictionary<string, string>> dict, string value)
    {
        foreach (KeyValuePair<string, Dictionary<string, string>> outerKeyValuePair in dict)
        {
            // Check the inner dictionary for the search value
            foreach (KeyValuePair<string, string> innerKeyValuePair in outerKeyValuePair.Value)
            {
                if (innerKeyValuePair.Value == value)
                {
                    return innerKeyValuePair.Key;  // Return the first level key when value matches
                }
            }
        }

        return null;  // Return null if no match found
    }
}
