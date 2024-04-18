using Domain.DTOs.Dossiers.CreateDossier;
using WebApi.Dossiers.CreateDossier;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWebApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IOutputPort<CreateDossierResponse>, CreateDossierPresenter>();

        return services;
    }
}