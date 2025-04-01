using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Posly.Api.Common.Http;

namespace Posly.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKey.Errors] = errors;

            var statusCode = errors.First().Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: errors.First().Description);
        }
    }
}
