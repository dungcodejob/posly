
using Posly.Domain.Models;

namespace Posly.Domain.Tenant.ValueObjects
{
    public sealed class TenantUserId : ValueObject
    {
        public Guid Value { get; set; }
        private TenantUserId(Guid value)
        {
            Value = value;
        }

        public static TenantUserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
