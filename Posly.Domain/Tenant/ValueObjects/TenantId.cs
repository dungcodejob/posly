using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posly.Domain.Models;

namespace Posly.Domain.Tenant.ValueObjects
{
    public sealed class TenantId : ValueObject
    {
        public Guid Value { get; set; }
        private TenantId(Guid value) {
            Value = value;
        }

        public static TenantId CreateUnique()
        {
            return new (Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents() {  
            yield return Value;
        }
    }
}
