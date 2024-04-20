using MudBlazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddViewServices(this IServiceCollection services)
    {
        services.AddViewModels();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMudServices();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        var assemblies = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(s => s.Namespace != null && s.Namespace.Contains("ViewModels"))
            .ToList();

        assemblies.ForEach(viewModel => services.AddScoped(viewModel));
        return services;
    }
}