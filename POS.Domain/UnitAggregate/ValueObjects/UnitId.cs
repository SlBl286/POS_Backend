using POS.Domain.Common.Models;

namespace POS.Domain.UnitAggregate.ValueObjects;

public class UnitId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
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
    public static UnitId Create(string Id)
    {
        return new(Guid.Parse(Id));
    }

    public static UnitId Create(Guid? Id)
    {
        return new(Id ?? Guid.NewGuid());
    }
    public static UnitId? CreateNullable(Guid? Id)
    {
        return new(Id ?? Guid.NewGuid());
    }
}