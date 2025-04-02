using Microsoft.AspNetCore.Mvc.Infrastructure;
using Posly.Api.Common.Errors;
using Posly.Api.Common.Handlers;
using Posly.Api.Common.Mapping;


namespace Posly.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddTransient<ProblemDetailsFactory, PoslyProblemDetailsFactory>();
        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddMappings();
        return services;
    }
}