using System.Reflection;
using Application.Courts.Queries.GetAllCourts;
using Application.Dossiers.Commands.CreateDossier;
using Application.Dossiers.Queries.GetDossierReport;
using Application.OverallProcesses.Queries.GetAllOverallProcesses;
using Application.Persons.Queries.GetAllPersons;
using Domain.DTOs.Courts.GetAllCourts;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IInputPort<CreateDossierInstance>, CreateDossierUseCase>();
        services.AddScoped<IInputPort<GetAllOverallProcessesInstance>, GetAllOverallProcessesUseCase>();
        services.AddScoped<IInputPort<GetAllCourtsInstance>, GetAllCourtsUserCase>();
        services.AddScoped<IInputPort<GetAllPersonsInstance>, GetAllPersonsUseCase>();
        services.AddScoped<IInputPort<GetDossierReportInstance>, GetDossierReportUseCase>();
        
        return services;
    }
    
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        var assemblies = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(s => s is { IsAbstract: false, BaseType.IsGenericType: true } &&
                        s.BaseType.GetGenericTypeDefinition() == typeof(Handler<>))
            .ToList();

        assemblies.ForEach(handler => services.AddScoped(handler));

        return services;
    }
}