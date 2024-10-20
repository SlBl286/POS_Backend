using POS.Domain.Common.Models;

namespace POS.Domain.ItemAggregate.ValueObjects;

public class UnitId : ValueObject
{
    public Guid Value { get; set; }
    private UnitId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static UnitId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}