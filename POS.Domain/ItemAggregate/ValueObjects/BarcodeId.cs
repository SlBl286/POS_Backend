using POS.Domain.Common.Models;

namespace POS.Domain.ItemAggregate.ValueObjects;

public sealed class BarcodeId : ValueObject
{
       public Guid Value { get; private set; }

    private BarcodeId(Guid value)
    {
        Value = value;
    }

    public static BarcodeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static BarcodeId Create(Guid value)
    {
        return new(value);
    }
    public static BarcodeId Create(string? value)
    {
        var newGuid = Guid.NewGuid();
        if (Guid.TryParse(value, out newGuid))
        {
            newGuid = Guid.Parse(value);
            return new BarcodeId(newGuid);
        }
        else
            return new BarcodeId(Guid.Empty);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}