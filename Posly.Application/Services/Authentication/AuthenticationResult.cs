using Posly.Domain.Entities;

namespace Posly.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);