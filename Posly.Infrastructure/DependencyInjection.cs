
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Posly.Application.Common.interfaces.Authentication;
using Posly.Application.Common.Interfaces.Services;
using Posly.Infrastructure.Authentication;

namespace Posly.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, IDateTimeProvider>();
        return services;
    }
}