using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Posly.Infrastructure.Services
{
    public class JwtSettingsSetup: IConfigureOptions<JwtSettingsSetup>
    {
        private const string SectionName = "JwtSettings";
        private readonly IConfiguration _configuration;

        public JwtSettingsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtSettingsSetup options)
        {
            _configuration.GetSection(SectionName).
        }
    }
}
