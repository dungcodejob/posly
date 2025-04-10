using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posly.Domain.Common.Interfaces;
using Posly.Domain.Models;
using Posly.Domain.ValueObjects;

namespace Posly.Domain.Entities
{
    public class Branch : Entity<BrachId>, ITenantEntity, IAuditableEntity
    {

        public string Name { get; private set; }
        public string Code { get; private set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public Guid? TenantId { get; set; }

        public Branch(BrachId id) : base(id)
        {
        }
    }
}
