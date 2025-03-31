namespace Posly.Application.Common.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string email, string passowrd)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "John",
            "Doe",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string passowrd)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            "token"
        );
    }
}