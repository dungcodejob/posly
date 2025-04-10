using Posly.Domain.Common.Interfaces;
using Posly.Domain.Models;
using Posly.Domain.Product.Entities;
using Posly.Domain.Product.ValueObjects;

namespace Posly.Domain.Product
{
    public class Product : AggregateRoot<ProductId>, ITenantEntity, IAuditableEntity
    {
        private List<ProductVariant> _variants { get; set; } = new();
        private List<ProductAttribute> _attributes { get; set; } = new();
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public Guid? TenantId { get; set; }

        public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();
        public IReadOnlyList<ProductAttribute> Attributes => _attributes.AsReadOnly();

        public Product(ProductId id, string name, string code, string description, bool isDeleted, DateTime createdAtUtc, DateTime? updatedAtUtc, Guid? tenantId) : base(id)
        {
            Name = name;
            Code = code;
            Description = description;
            TenantId = tenantId;
            IsDeleted = isDeleted;
            CreatedAtUtc = createdAtUtc;
            UpdatedAtUtc = updatedAtUtc;
            TenantId = tenantId;
        }

        public static Product Create(string name, string code, string description, Guid? tenantId)
        {
            return new Product(ProductId.CreateUnique(), name, code, description, false, DateTime.UtcNow, null, tenantId);
        }
    }
}
