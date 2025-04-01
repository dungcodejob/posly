using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Posly.Application.Common.Errors;
namespace Posly.Api.Controllers;



public class ErrorsController : ControllerBase
{


    [HttpPost("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IError serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}