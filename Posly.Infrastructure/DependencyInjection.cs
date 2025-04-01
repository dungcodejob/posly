using Microsoft.Extensions.DependencyInjection;
using Posly.Application.Common.Interfaces.Authentication;
using Posly.Application.Common.Interfaces.Presentation;
using Posly.Application.Common.Interfaces.Services;
using Posly.Infrastructure.Authentication;
using Posly.Infrastructure.Presentation;
using Posly.Infrastructure.Services;

namespace Posly.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {

        services.ConfigureOptions<JwtSettingsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<ITenantProvider, TenantProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();



        services.AddScoped<IUserRepository,UserRepository>();
        
        return services;
    }
}