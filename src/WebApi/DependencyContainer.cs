using Domain.DTOs.Courts.GetAllCourts;
using Domain.DTOs.Dossiers.CreateDossier;
using Domain.DTOs.Dossiers.GetDossierReport;
using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;
using Domain.DTOs.Persons.GetAllPersons;
using WebApi.Courts.GetAllCourts;
using WebApi.Dossiers.CreateDossier;
using WebApi.Dossiers.GetDossierReport;
using WebApi.OverallProcesses.GetAllOverallProcesses;
using WebApi.Persons.GetAllPersons;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWebApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IOutputPort<CreateDossierResponse>, CreateDossierPresenter>();
        services.AddScoped<IOutputPort<GetAllOverallProcessesResponse>, GetAllOverallProcessesPresenter>();
        services.AddScoped<IOutputPort<GetAllCourtsResponse>, GetAllCourtsPresenter>();
        services.AddScoped<IOutputPort<GetAllPersonsResponse>, GetAllPersonsPresenter>();
        services.AddScoped<IOutputPort<GetDossierReportResponse>, GetDossierReportPresenter>();

        return services;
    }
}