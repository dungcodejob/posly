using Posly.Domain.Models;
using Posly.Domain.Product.ValueObjects;

namespace Posly.Domain.Product.Entities
{
    public class ProductVariant : Entity<ProductVariantId>
    {
        private List<ProductAttributeValue> _attributeValues { get; set; } = new();
        private List<ProductPriceTier> _priceTiers { get; set; } = new();

        public ProductId ProductId { get; set; }
        public string SKU { get; set; }

        public IReadOnlyList<ProductAttributeValue> AttributeValues => _attributeValues.AsReadOnly();
        public IReadOnlyList<ProductPriceTier> priceTiers => _priceTiers.AsReadOnly();
        private ProductVariant(ProductVariantId id, string sku) : base(id)
        {
            SKU = sku;
        }

        public static ProductVariant Create(string sku)
        {
            return new ProductVariant(ProductVariantId.CreateUnique(), sku);
        }
    }
}
