using Infrastructure.DataContext.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, Action<DbOptions> dbOptions)
    {
        services.Configure(dbOptions);
        services.AddDbContext<GovernmentContext>();
        services.AddScoped<GovernmentContextInitialiser>();
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        
        services.AddAuthorizationBuilder();
        
        services
            .AddIdentityCore<GovernmentUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GovernmentContext>()
            .AddApiEndpoints();

        return services;
    }
}