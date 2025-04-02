

using ErrorOr;
using MediatR;
using Posly.Application.Common.Interfaces.Presentation;
using Posly.Application.Services.Authentication;
using Posly.Domain.Entities;
using Posly.Domain.Common.Errors;
using Posly.Application.Common.Interfaces.Authentication;

namespace Posly.Application.Authentication.Queries.Login;


public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != command.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
           token
        );
    }
}