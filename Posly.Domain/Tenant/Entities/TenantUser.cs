using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posly.Domain.Common.Interfaces;
using Posly.Domain.Models;
using Posly.Domain.Tenant.ValueObjects;

namespace Posly.Domain.Tenant.Entities
{
    public class TenantUser : Entity<TenantUserId>, ITenantEntity, IAuditableEntity
    {
        public TenantUser(TenantUserId id) : base(id)
        {
        }

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public Guid? TenantId { get; set; }
    }
}
