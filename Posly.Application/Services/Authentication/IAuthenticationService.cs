namespace Posly.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string passowrd);

    AuthenticationResult Register(string firstName, string lastName, string email, string passowrd);
}