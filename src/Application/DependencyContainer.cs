using System.Reflection;
using Application.Dossiers.Commands.CreateDossier;
using Application.OverallProcesses.Queries.GetAllOverallProcesses;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IInputPort<CreateDossierInstance>, CreateDossierUseCase>();
        services.AddScoped<IInputPort, GetAllOverallProcessesUseCase>();
        
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