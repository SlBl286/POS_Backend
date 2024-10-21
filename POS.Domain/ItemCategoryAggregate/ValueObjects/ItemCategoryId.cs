using POS.Domain.Common.Models;

namespace POS.Domain.ItemCategoryAggregate.ValueObjects;

public class ItemCategoryId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private ItemCategoryId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static ItemCategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}