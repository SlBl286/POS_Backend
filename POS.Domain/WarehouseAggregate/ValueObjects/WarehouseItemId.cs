using POS.Domain.Common.Models;

namespace POS.Domain.WarehouseAggregate.ValueObjects;

public sealed class WarehouseItemId : ValueObject
{
    public Guid Value { get; private set; }

    private WarehouseItemId(Guid value)
    {
        Value = value;
    }

    public static WarehouseItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static WarehouseItemId Create(Guid value)
    {
        return new(value);
    }
    public static WarehouseItemId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new WarehouseItemId(newGuid);
        }
        else
            return new WarehouseItemId(Guid.Empty);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}