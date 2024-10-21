using POS.Domain.Common.Models;

namespace POS.Domain.BillAggregate.ValueObjects;

public sealed class BillDetailId : ValueObject
{
    public Guid Value { get; private set; }

    private BillDetailId(Guid value)
    {
        Value = value;
    }
    public static BillDetailId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static BillDetailId Create(Guid value)
    {
        return new(value);
    }
    public static BillDetailId Create(string value)
    {
        return new(Guid.Parse(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}