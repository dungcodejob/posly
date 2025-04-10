using Posly.Domain.Models;

namespace Posly.Domain.Product.ValueObjects
{
    public class ProductAttributeValueId : ValueObject
    {
        public Guid Value { get; set; }
        private ProductAttributeValueId(Guid value)
        {
            Value = value;
        }

        public static ProductAttributeValueId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
