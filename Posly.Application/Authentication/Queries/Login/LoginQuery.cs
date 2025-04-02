

using ErrorOr;
using MediatR;
using Posly.Application.Services.Authentication;

namespace Posly.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email, 
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;