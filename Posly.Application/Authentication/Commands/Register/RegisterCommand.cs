

using ErrorOr;
using MediatR;
using Posly.Application.Services.Authentication;

namespace Posly.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;