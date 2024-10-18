using POS.Domain.Common.Models;

namespace POS.Domain.ItemAggregate.ValueObjects;

public class ItemId : AggregateRootId<Guid>
{
    public override Guid Value { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
    private ItemId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static ItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}