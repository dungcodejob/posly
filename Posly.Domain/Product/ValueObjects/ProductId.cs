
using Posly.Domain.Models;

namespace Posly.Domain.Product.ValueObjects
{
    public class ProductId: ValueObject
    {
        public Guid Value { get; set; }
        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
