using Posly.Domain.Models;

namespace Posly.Domain.Product.ValueObjects
{
    public class ProductPriceTierId : ValueObject
    {
        public Guid Value { get; set; }
        private ProductPriceTierId(Guid value)
        {
            Value = value;
        }

        public static ProductPriceTierId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
