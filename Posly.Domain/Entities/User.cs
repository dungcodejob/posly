using Posly.Domain.Common.Interfaces;
using Posly.Domain.Models;
using Posly.Domain.ValueObjects;

namespace Posly.Domain.Entities;

public class User : Entity<BrachId>, ITenantEntity, IAuditableEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
    public Guid? TenantId { get; set; }

    public User(BrachId id) : base(id)
    {
    }
}