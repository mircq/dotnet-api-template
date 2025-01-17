using Carter;

namespace Presentation;

public static class Presentation
{
    public static void InitializePresentation(this IServiceCollection services)
    {
        services.AddCarter();
    }
}
