using Domain.DTOs.Dossiers.CreateDossier;
using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;
using WebApi.Dossiers.CreateDossier;
using WebApi.OverallProcesses.GetAllOverallProcesses;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWebApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IOutputPort<CreateDossierResponse>, CreateDossierPresenter>();
        services.AddScoped<IOutputPort<List<GetAllOverallProcessesResponse>>, GetAllOverallProcessesPresenter>();

        return services;
    }
}