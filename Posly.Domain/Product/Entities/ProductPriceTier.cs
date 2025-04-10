using Posly.Domain.Models;
using Posly.Domain.Product.ValueObjects;

namespace Posly.Domain.Product.Entities
{
    public class ProductPriceTier : Entity<ProductPriceTierId>
    {
        public Guid ProductVariantId { get; set; }
        public int MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        private ProductPriceTier(ProductPriceTierId id, int minQuantity, int? maxQuantity, decimal price, string currency) : base(id)
        {
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
            Price = price;
            Currency = currency;
        }

        public static ProductPriceTier Create(int minQuantity, int? maxQuantity, decimal price, string currency)
        {
            return new ProductPriceTier(
                ProductPriceTierId.CreateUnique(),
                minQuantity,
                maxQuantity,
                price,
                currency
                );
        }

    }
}
