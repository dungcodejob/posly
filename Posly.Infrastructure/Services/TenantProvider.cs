using Microsoft.AspNetCore.Http;
using Posly.Application.Common.Interfaces.Services;

namespace Posly.Infrastructure.Services;



public sealed class TenantProvider : ITenantProvider
{
    private const string TenantIdHeaderName = "X-TenantId";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    // TODO: check tenantId is not null
    public string TenantId => _httpContextAccessor
       .HttpContext
       .Request
       .Headers[TenantIdHeaderName];
}