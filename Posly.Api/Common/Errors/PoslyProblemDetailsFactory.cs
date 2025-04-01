using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using ErrorOr;
using Posly.Api.Common.Http;

namespace Posly.Api.Common.Errors;

public class PoslyProblemDetailsFactory : ProblemDetailsFactory
{

    private readonly ApiBehaviorOptions _options;

    public PoslyProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        statusCode ??= 500;
        var problemDetails = new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);


        return problemDetails;

    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        var validationproblemdetails = new ValidationProblemDetails
        {
            Status = statusCode,
        };
        return validationproblemdetails;
    }

    private void ApplyProblemDetailsDefault(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }


        var errors = httpContext?.Items[HttpContextItemKey.Errors] as List<Error>;
        if (errors is not null)
        {
            problemDetails.Extensions.Add("errorCode", errors.First().Code);
            problemDetails.Extensions.Add("errorCodes", errors.Select(error => error.Code));
        }

    }
}