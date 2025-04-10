using Microsoft.Extensions.DependencyInjection;
using Posly.Application.Common.Interfaces.Authentication;
using Posly.Application.Common.Interfaces.Presentation;
using Posly.Application.Common.Interfaces.Services;
using Posly.Infrastructure.Authentication;
using Posly.Infrastructure.Presentation;
using Posly.Infrastructure.Services;

namespace Posly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {



        services.AddAuth().AddPersistance();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<ITenantProvider, TenantProvider>();
        

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.ConfigureOptions<JwtSettingsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication().AddJwtBearer();

        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

}