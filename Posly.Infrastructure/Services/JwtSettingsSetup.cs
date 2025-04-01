using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Posly.Infrastructure.Authentication;

namespace Posly.Infrastructure.Services;

public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private const string SectionName = "JwtSettings";
    private readonly IConfiguration _configuration;

    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}

