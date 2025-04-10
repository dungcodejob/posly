using Posly.Domain.Models;

namespace Posly.Domain.Product.ValueObjects
{
    public class ProductAttributeId : ValueObject
    {
        public Guid Value { get; set; }
        private ProductAttributeId(Guid value)
        {
            Value = value;
        }

        public static ProductAttributeId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
