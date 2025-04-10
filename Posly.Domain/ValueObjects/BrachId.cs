using Posly.Domain.Models;


namespace Posly.Domain.ValueObjects
{
    public class BrachId: ValueObject
    {
        public Guid Value { get; set; }
        private BrachId(Guid value)
        {
            Value = value;
        }

        public static BrachId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<Object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
