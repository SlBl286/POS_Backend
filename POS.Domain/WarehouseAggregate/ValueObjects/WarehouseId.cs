using POS.Domain.Common.Models;

namespace POS.Domain.WarehouseAggregate.ValueObjects;

public class WarehouseId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private WarehouseId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static WarehouseId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}