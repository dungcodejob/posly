using Posly.Domain.Models;
using Posly.Domain.Product.ValueObjects;

namespace Posly.Domain.Product.Entities
{
    public class ProductAttribute : Entity<ProductAttributeId>
    {
        private readonly List<ProductAttributeValue> _values = new();

        public ProductId ProductId { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<ProductAttributeValue> Values => _values.AsReadOnly();
        private ProductAttribute(ProductAttributeId id, string name) : base(id)
        {
            Name = name;
        }

        public static ProductAttribute Create(string name)
        {
            return new ProductAttribute(ProductAttributeId.CreateUnique(), name);
        }

        public void AddValue(ProductAttributeValue value) { }
    }
}
