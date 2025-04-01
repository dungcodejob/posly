
using Posly.Domain.Entities;

namespace Posly.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}