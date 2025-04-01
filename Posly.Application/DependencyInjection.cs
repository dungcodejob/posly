
using Microsoft.Extensions.DependencyInjection;
using Posly.Application.Services.Authentication;

namespace Posly.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddScoped<IAuthenticationService,AuthenticationService>();
        return services;
    }
}