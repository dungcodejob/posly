
using Mapster;
using Posly.Application.Authentication.Queries.Login;
using Posly.Application.Services.Authentication;
using Posly.Contracts.Authentication;
using Posly.Application.Authentication.Commands.Register;



namespace Posly.Api.Common.Mapping;


public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest,LoginQuery>();
        config.NewConfig<RegisterRequest,RegisterCommand>();
        config.NewConfig<AuthenticationResult,AuthenticationResponse>().Map(
            dest => dest.Token,
            src => src.Token
        ).Map(dest => dest, src => src.User);
    }
}