using Posly.Domain.Models;
using Posly.Domain.Product.ValueObjects;

namespace Posly.Domain.Product.Entities
{
    public class ProductAttributeValue : Entity<ProductAttributeValueId>
    {
        public ProductAttributeId ProductAttributeId { get; set; }
        public string Value { get; set; }
        private ProductAttributeValue(ProductAttributeValueId id,string value) : base(id)
        {
            Value = value;
        }

        public static ProductAttributeValue Create(string value)
        {
            return new ProductAttributeValue(ProductAttributeValueId.CreateUnique(), value);
        }
    }
}
