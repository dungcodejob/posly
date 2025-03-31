



using System.Security.Claims;
using Posly.Application.Common.interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt


using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Posly.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid tenantId, Guid userId, string firstName, string lastName)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("use-id",userId.ToString()),
            new Claim("tenant-id",tenantId.ToString()),
        };

        var token = new JwtSecurityToken(
        issuer: auth.Issuer,
        audience: auth.Audience,
        claims: claims,
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: credentials
    );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}