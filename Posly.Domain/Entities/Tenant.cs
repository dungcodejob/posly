using Posly.Domain.Common.Interfaces;
using Posly.Domain.Models;
using Posly.Domain.Tenant.Entities;
using Posly.Domain.Tenant.ValueObjects;

namespace Posly.Domain.Entities
{
    public class Tenant : AggregateRoot<TenantId>, IAuditableEntity
    {

        public Tenant(TenantId id) : base(id)
        {
        }


        private readonly List<TenantUser> _users = new();
        public Guid OwnerId { get; private set; }
        public TenantUser Owner { get; private set; }
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public int MaxUsers { get; private set; } = 3;
        public int MaxBranches { get; private set; } = 1;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }

        public IReadOnlyCollection<TenantUser> Users => _users.AsReadOnly();
    }
}
