namespace Posly.Application.Common.Interfaces.Services;

public interface ITenantProvider
{
    string TenantId { get; }
}