using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddGatewaysDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        var webApiOptions = configuration
            .GetSection(WebApiOptions.SectionKey)
            .Get<WebApiOptions>();

        services.AddHttpClient(WebApiOptions.SectionKey, client =>
        {
            client.BaseAddress = new Uri(webApiOptions.BaseAddress);
            client.Timeout = TimeSpan.FromSeconds(webApiOptions.TimeOutInSeconds);
        });
        services.AddScoped<ICreateDossierGateway, CreateDossierGateway>();
        return services;
    }
}