using Gateways.Implementations.Courts;
using Gateways.Implementations.Persons;
using Gateways.Services.Courts;
using Gateways.Services.Persons;
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
        services.AddScoped<IGetAllOverallProcessesGateway, GetAllOverallProcessesGateway>();
        services.AddScoped<IGetAllCourtsGateway, GetAllCourtsGateway>();
        services.AddScoped<IGetAllPersonsGateway, GetAllPersonsGateway>();
        return services;
    }
}