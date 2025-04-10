using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posly.Domain.Models;

namespace Posly.Domain.Product.ValueObjects
{
    public class ProductVariantId: ValueObject
    {
        public Guid Value { get; set; }
        private ProductVariantId(Guid value)
        {
            Value = value;
        }

        public static ProductVariantId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
