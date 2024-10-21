using POS.Domain.Common.Models;

namespace POS.Domain.ItemCategoryAggregate.ValueObjects;

public sealed class ItemItemCategoryId : ValueObject
{
    public Guid Value { get; private set; }

    private ItemItemCategoryId(Guid value)
    {
        Value = value;
    }

    public static ItemItemCategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static ItemItemCategoryId Create(Guid value)
    {
        return new(value);
    }
    public static ItemItemCategoryId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new ItemItemCategoryId(newGuid);
        }
        else
            return new ItemItemCategoryId(Guid.Empty);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}