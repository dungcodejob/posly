using Microsoft.AspNetCore.Mvc;
using Posly.Contracts.Authentication;
using Posly.Application.Services.Authentication;
using Posly.Application.Authentication.Queries.Login;

using Posly.Domain.Common.Errors;
using MediatR;
using Posly.Application.Authentication.Commands.Register;

namespace Posly.Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;


    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

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
    public async Task<IActionResult> Login(RegisterRequest request)
    {

        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        var authResult = await _mediator.Send(command);

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