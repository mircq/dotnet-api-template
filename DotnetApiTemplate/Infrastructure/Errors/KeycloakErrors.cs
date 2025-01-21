using Domain.Errors;

namespace Infrastructure.Errors;

public class KeycloakErrors
{
    public static Error FailedTokenRetrievalError()
    {
        return new Error(message: "Failed to retrieve token from Keycloak.", statusCode: 500);
    }
}
