using Microsoft.AspNetCore.Mvc;
using Posly.Contracts.Authentication;
using Posly.Application.Services.Authentication;
using Posly.Domain.Common.Errors;


namespace Posly.Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
                );
        }

        return authResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
            );
    }

    [HttpPost("register")]
    public IActionResult Login(RegisterRequest request)
    {

        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
            );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
             authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
            );
    }

}