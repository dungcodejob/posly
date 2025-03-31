
namespace Posly.Application.Common.interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid tenant, Guid userId, string firstName, string lastName);
}