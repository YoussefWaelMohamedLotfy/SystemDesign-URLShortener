using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace URLShortener.SDK;

public static class SDKServiceRegistration
{
    public static void AddUrlShortener(this IServiceCollection services)
    {
        services.AddRefitClient<IUrlApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new("https://localhost:7261");
            });
    }
}
